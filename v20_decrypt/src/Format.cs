namespace v20_decrypt
{
        internal struct CookieFormat
        {
            internal string Host;

            internal string Name;

            internal string Path;

            internal string Cookie;

            internal string Expiry;

            internal CookieFormat(string host, string name, string path, string cookie, string expiry)
            {
                Host = host;
                Name = name;
                Path = path;
                Cookie = cookie;
                Expiry = expiry;
            }
        }
}
