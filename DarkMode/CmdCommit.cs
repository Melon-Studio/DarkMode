using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static void CmdCommandLight()
        {
            //TEST
            string s = "\"D:\\Program Files (x86)\\Steam\\steamapps\\common\\wallpaper_engine\\wallpaper64.exe\"";
            string ss = "\"D:\\Program Files (x86)\\Steam\\steamapps\\workshop\\content\\431960\\1884904087\\project.json\"";
            string zhilin = s + " -control openWallpaper -file " + ss;
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
