using System;
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
            string language = new System.Globalization.CultureInfo(Language.NowLanguage().ToString()).ToString();
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
    }
    
}
