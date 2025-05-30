using System;
using System.Collections.Generic;
using System.Linq;
namespace v20_decrypt
{
    internal class writer
    {
        public static async Task WriteCookies(CookieFormat[] cookies, string key)
        {
            string cookiesFilePath = $"Cookies_{key}.txt";
            using (StreamWriter cookieWriter = new StreamWriter(cookiesFilePath))
            {
                foreach (var cookie in cookies)
                {
                    await cookieWriter.WriteLineAsync($"{cookie.Host}\tTRUE\t{cookie.Path}\tFALSE\t{cookie.Expiry}\t{cookie.Name}\t{cookie.Cookie}\r\n");
                }
            }
        }
    }
}
