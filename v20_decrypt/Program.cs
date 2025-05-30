//coder: @MAMOHTOP

namespace v20_decrypt
{
    class Program
    {
        
        static async Task Main()
        {
            Console.WriteLine("""
                All browsers:

                Google
                Yandex
                Edge
                Opera
                Opera GX
                Brave
                Chromium
                Dragon
                EpicPrivacy
                Iridium
                Slimjet
                UR-Browser
                Vivaldi
                Google(x86)
                MapleStudio
                7Star
                CentBrowser
                Chedot
                Kometa
                Elements Browser
                Uran
                Amigo
                Atom
                Torch
                360Browser
                """);
            Console.WriteLine("Browser name: ");
            string browser = Console.ReadLine()?.Trim();
            string pathToBrowser = PathsCV20.pathsBRWSRs[browser];
            if (pathToBrowser != null)
            {
                var cookies = await V20Collect.GetCookiesFromBrowser(pathToBrowser, browser);
                await writer.WriteCookies(cookies, browser);
                Console.WriteLine($"The cookies were written to the file 'Cookies_{browser}.txt'!");
            }
            else
            {
                Console.WriteLine("This browser is not listed!");
            }
        }
    }
}