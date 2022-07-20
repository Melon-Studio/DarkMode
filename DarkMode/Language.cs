using Microsoft.Win32;

namespace DarkMode
{
    internal class Language
    {
        public static string NowLanguage()
        {
            RegistryKey set = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode");
            string lang = set.GetValue("Language").ToString();
            return lang;
        }
        //语言类
        public static string StringText(string str)
        {
            string language = Registry.GetValue("HKEY_CURRENT_USER\\Software\\DarkMode", "Language", "").ToString();
            //zh-CN
            if (language == "zh-CN" && str == "String1")
            {
                return "作者：Melon Studio - XiaoFans";
            }
            if (language == "zh-CN" && str == "String2")
            {
                return "关于";
            }
            if (language == "zh-CN" && str == "String3")
            {
                return "设置失败：";
            }
            if (language == "zh-CN" && str == "String4")
            {
                return "错误";
            }
            if (language == "zh-CN" && str == "String5")
            {
                return "本程序仅支持Windows 11操作系统，请升级为Windows 11后使用。";
            }
            if (language == "zh-CN" && str == "String6")
            {
                return "暂不支持您的电脑";
            }
            if (language == "zh-CN" && str == "String7")
            {
                return "注册表初始化失败。错误信息：";
            }
            if (language == "zh-CN" && str == "String8")
            {
                return "读取注册表语言失败。错误信息：";
            }
            if (language == "zh-CN" && str == "String9")
            {
                return "检测到系统设置了系统颜色模式为自定义，软件将修改您的自定义模式。";
            }
            if (language == "zh-CN" && str == "String10")
            {
                return "提示";
            }
            //zh-TW
            if (language == "zh-TW" && str == "String1")
            {
                return "作者：Melon Studio - XiaoFans";
            }
            if (language == "zh-TW" && str == "String2")
            {
                return "關於";
            }
            if (language == "zh-TW" && str == "String3")
            {
                return "設定失敗：";
            }
            if (language == "zh-TW" && str == "String4")
            {
                return "錯誤";
            }
            if (language == "zh-TW" && str == "String5")
            {
                return "本程式僅支持Windows 11作業系統，請陞級為Windows 11後使用。";
            }
            if (language == "zh-TW" && str == "String6")
            {
                return "暫不支持您的電腦";
            }
            if (language == "zh-TW" && str == "String7")
            {
                return "電腦資料庫初始化失敗。 錯誤資訊：";
            }
            if (language == "zh-TW" && str == "String8")
            {
                return "讀取電腦資料庫語言失敗。 錯誤資訊：";
            }
            if (language == "zh-TW" && str == "String9")
            {
                return "檢測到系統設置了系統顏色模式為自定義，軟體將修改您的自定義模式。";
            }
            if (language == "zh-TW" && str == "String10")
            {
                return "提示";
            }
            //ja-JP
            if (language == "ja-JP" && str == "String1")
            {
                return "作成者：Melon Studio - XiaoFans";
            }
            if (language == "ja-JP" && str == "String2")
            {
                return "について";
            }
            if (language == "ja-JP" && str == "String3")
            {
                return "設定に失敗しました:";
            }
            if (language == "ja-JP" && str == "String4")
            {
                return "エラー";
            }
            if (language == "ja-JP" && str == "String5")
            {
                return "本プログラムはWindows 11オペレーティングシステムのみをサポートしておりますので、Windows 11にアップグレードしてご利用ください。";
            }
            if (language == "ja-JP" && str == "String6")
            {
                return "お客様のPCのサポートは保留中です";
            }
            if (language == "ja-JP" && str == "String7")
            {
                return "レジストリの初期化に失敗しました。エラーメッセージ:";
            }
            if (language == "ja-JP" && str == "String8")
            {
                return "レジストリ言語の読み取りに失敗しました。エラーメッセージ:";
            }
            if (language == "ja-JP" && str == "String9")
            {
                return "システムのカラーモードがカスタムに設定されていることが検出され、ソフトウェアはカスタムモードを変更します。";
            }
            if (language == "ja-JP" && str == "String10")
            {
                return "ヒント";
            }
            //en-US
            if (language == "en-US" && str == "String1")
            {
                return "Author: Melon Studio - XiaoFans";
            }
            if (language == "en-US" && str == "String2")
            {
                return "About";
            }
            if (language == "en-US" && str == "String3")
            {
                return "Setting failed: ";
            }
            if (language == "en-US" && str == "String4")
            {
                return "Error";
            }
            if (language == "en-US" && str == "String5")
            {
                return "This program only supports windows 11 operating system. Please upgrade to windows 11 before using.";
            }
            if (language == "en-US" && str == "String6")
            {
                return "Your computer is temporarily not supported";
            }
            if (language == "en-US" && str == "String7")
            {
                return "Registry initialization failed. Error message:";
            }
            if (language == "en-US" && str == "String8")
            {
                return "Failed to read registry language. Error message:";
            }
            if (language == "en-US" && str == "String9")
            {
                return "It is detected that the system has set the system color mode as custom, and the software will modify your custom mode.";
            }
            if (language == "en-US" && str == "String10")
            {
                return "Tips";
            }
            return "null";
        }
        public static string Form2Lang(string str)
        {
            string language = Registry.GetValue("HKEY_CURRENT_USER\\Software\\DarkMode", "Language", "").ToString();
            //zh-CN
            if (language == "zh-CN" && str == "String1")
            {
                return "时间";
            }
            if (language == "zh-CN" && str == "String2")
            {
                return "开始时间（浅色模式）";
            }
            if (language == "zh-CN" && str == "String3")
            {
                return "结束时间（浅色模式）";
            }
            if (language == "zh-CN" && str == "String4")
            {
                return "日出日落模式";
            }
            if (language == "zh-CN" && str == "String5")
            {
                return "语言";
            }
            if (language == "zh-CN" && str == "String6")
            {
                return "部分翻译为机器翻译";
            }
            if (language == "zh-CN" && str == "String7")
            {
                return "壁纸";
            }
            if (language == "zh-CN" && str == "String8")
            {
                return "原生壁纸";
            }
            if (language == "zh-CN" && str == "String9")
            {
                return "浅色时";
            }
            if (language == "zh-CN" && str == "String10")
            {
                return "深色时";
            }
            if (language == "zh-CN" && str == "String11")
            {
                return "Wallpaper Engine 壁纸";
            }
            if (language == "zh-CN" && str == "String12")
            {
                return "设置文档";
            }
            if (language == "zh-CN" && str == "String13")
            {
                return "浏览";
            }
            if (language == "zh-CN" && str == "String14")
            {
                return "保存";
            }
            if (language == "zh-CN" && str == "String15")
            {
                return "设置";
            }
            //zh-TW
            if (language == "zh-TW" && str == "String1")
            {
                return "時間";
            }
            if (language == "zh-TW" && str == "String2")
            {
                return "開始時間（淺色模式）";
            }
            if (language == "zh-TW" && str == "String3")
            {
                return "結束時間（淺色模式）";
            }
            if (language == "zh-TW" && str == "String4")
            {
                return "日出日落模式";
            }
            if (language == "zh-TW" && str == "String5")
            {
                return "語言";
            }
            if (language == "zh-TW" && str == "String6")
            {
                return "部分翻譯為機器翻譯";
            }
            if (language == "zh-TW" && str == "String7")
            {
                return "壁紙";
            }
            if (language == "zh-TW" && str == "String8")
            {
                return "原生壁紙";
            }
            if (language == "zh-TW" && str == "String9")
            {
                return "淺色時";
            }
            if (language == "zh-TW" && str == "String10")
            {
                return "深色時";
            }
            if (language == "zh-TW" && str == "String11")
            {
                return "Wallpaper Engine 壁紙";
            }
            if (language == "zh-TW" && str == "String12")
            {
                return "設定文檔";
            }
            if (language == "zh-TW" && str == "String13")
            {
                return "瀏覽";
            }
            if (language == "zh-TW" && str == "String14")
            {
                return "保存";
            }
            if (language == "zh-TW" && str == "String15")
            {
                return "設定";
            }
            //ja-JP
            if (language == "ja-JP" && str == "String1")
            {
                return "時間";
            }
            if (language == "ja-JP" && str == "String2")
            {
                return "開始時間（ライトモード）";
            }
            if (language == "ja-JP" && str == "String3")
            {
                return "終了時間（ライトモード）";
            }
            if (language == "ja-JP" && str == "String4")
            {
                return "サンライズサンセットモード";
            }
            if (language == "ja-JP" && str == "String5")
            {
                return "言語";
            }
            if (language == "ja-JP" && str == "String6")
            {
                return "部分的に機械翻訳に翻訳";
            }
            if (language == "ja-JP" && str == "String7")
            {
                return "壁紙";
            }
            if (language == "ja-JP" && str == "String8")
            {
                return "ネイティブ壁紙";
            }
            if (language == "ja-JP" && str == "String9")
            {
                return "明色時";
            }
            if (language == "ja-JP" && str == "String10")
            {
                return "暗色時";
            }
            if (language == "ja-JP" && str == "String11")
            {
                return "Wallpaper Engine 壁紙";
            }
            if (language == "ja-JP" && str == "String12")
            {
                return "セットアップドキュメント";
            }
            if (language == "ja-JP" && str == "String13")
            {
                return "検索";
            }
            if (language == "ja-JP" && str == "String14")
            {
                return "保存";
            }
            if (language == "ja-JP" && str == "String15")
            {
                return "設定";
            }
            //en-US
            if (language == "en-US" && str == "String1")
            {
                return "Time";
            }
            if (language == "en-US" && str == "String2")
            {
                return "Start time(light mode)";
            }
            if (language == "en-US" && str == "String3")
            {
                return "End time(dark mode)";
            }
            if (language == "en-US" && str == "String4")
            {
                return "Sunrise Sunset Mode";
            }
            if (language == "en-US" && str == "String5")
            {
                return "Language";
            }
            if (language == "en-US" && str == "String6")
            {
                return "Partial machine translation";
            }
            if (language == "en-US" && str == "String7")
            {
                return "wallpaper";
            }
            if (language == "en-US" && str == "String8")
            {
                return "native wallpaper";
            }
            if (language == "en-US" && str == "String9")
            {
                return "light";
            }
            if (language == "en-US" && str == "String10")
            {
                return "dark";
            }
            if (language == "en-US" && str == "String11")
            {
                return "Wallpaper Engine";
            }
            if (language == "en-US" && str == "String12")
            {
                return "setup document";
            }
            if (language == "en-US" && str == "String13")
            {
                return "sea...";
            }
            if (language == "en-US" && str == "String14")
            {
                return "Save";
            }
            if (language == "en-US" && str == "String15")
            {
                return "Settings";
            }
            return null;
        }
    }

}
