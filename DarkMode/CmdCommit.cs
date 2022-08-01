using Microsoft.Win32;
using System;
using System.IO;

namespace DarkMode
{
    internal class CmdCommit
    {
        public static string WallpaperEnginePath()
        {
            try
            {
                string wallpaperEnginePath = Registry.GetValue("HKEY_CURRENT_USER\\Software\\WallpaperEngine", "installPath", "").ToString();
                if (File.Exists(wallpaperEnginePath))
                {
                    return wallpaperEnginePath;
                }
                return "false";
            }
            catch
            {
                return "false";
            }
            
        }

        public static string WallpaperPath()
        {
            string wallpaperEnginePath = WallpaperEnginePath();
            if(wallpaperEnginePath == "false")
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            string workshop = wallpaperEnginePath.Substring(0, wallpaperEnginePath.IndexOf("\\common")) + @"\workshop\content";
            return workshop;
        }

        public static void CmdCommandLight(string mingling)
        {
            RegistryKey key;
            key = Registry.CurrentUser.OpenSubKey(@"Software\WallpaperEngine", true);
            string s = key.GetValue("installPath").ToString();
            
            string zhilin = "\"" + s + "\"" + " -control openWallpaper -file " + "\"" + mingling + "\"";
            //执行cmd命令
            System.Diagnostics.Process process = new System.Diagnostics.Process()
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            process.StandardInput.WriteLine(zhilin);
            process.StandardInput.WriteLine("exit");
            process.StandardInput.AutoFlush = true;
            process.WaitForExit(); 

        }
    }
}
