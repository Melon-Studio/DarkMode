using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DarkMode
{
    internal class Observer
    {
        /// <summary>
        /// 执行事件A
        /// </summary>
        /// <returns></returns>
        public string DoA()
        {
            //创建 NotifyIcon 实例
            NotifyIcon fyIcon = new NotifyIcon();
            fyIcon.BalloonTipText = "已自动切换到深色模式";/*必填提示内容*/
            fyIcon.BalloonTipTitle = "已自动切换到深色模式";
            fyIcon.Visible = true;/*必须设置显隐，因为默认值是 false 不显示通知*/
            fyIcon.ShowBalloonTip(0);
            RegistryKey key = Registry.CurrentUser;
            RegistryKey software = key.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            software.SetValue("SystemUsesLightTheme", 0);
            return "时间到了，执行事件A~~";
        }

        /// <summary>
        ///执行事件B
        /// </summary>
        /// <returns></returns>
        public string DoB()
        {
            //创建 NotifyIcon 实例
            NotifyIcon fyIcon = new NotifyIcon();
            fyIcon.BalloonTipText = "已自动切换到浅色模式";/*必填提示内容*/
            fyIcon.BalloonTipTitle = "已自动切换到浅色模式";
            fyIcon.Visible = true;/*必须设置显隐，因为默认值是 false 不显示通知*/
            fyIcon.ShowBalloonTip(0);
            RegistryKey key = Registry.CurrentUser;
            RegistryKey software = key.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            software.SetValue("SystemUsesLightTheme", 1);
            return "时间到了，执行事件B~~";
        }
    }
    
}
