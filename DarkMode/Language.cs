using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMode
{
    internal class Language
    {
        public static void Languages()
        {
            string lang = System.Globalization.CultureInfo.InstalledUICulture.Name;
            NowLanguage(lang);
        }

        public static string NowLanguage(string lang)
        {
            switch (lang)
            {
                case "zh-TW":
                    return @"Resource.zh_TW";
                    break;

                case "en-US":
                    return "Resource.en-US";
                    break;

                case "ja-JP":
                    return "Resource.ja-JP";
                    break;

                default :
                    return "Resource.zh_CN";
                    break;

            }
        }
    }
}
