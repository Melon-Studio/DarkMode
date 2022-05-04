using System;
using System.Management;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DarkMode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者：XiaoFans（一只小凡凡）, Melon Studio\n本程序独家首发于吾爱破解论坛，完全免费！", "关于");
        }

        private void 开机自启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //设置开机自启
            try
            {
                if ((sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked)
                {
                    string path = Application.ExecutablePath;
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.SetValue("DarkMode", path);
                    rk2.Close();
                    rk.Close();
                }
                else
                {
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.DeleteValue("DarkMode", false);
                    rk2.Close();
                    rk.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("设置失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //获取操作系统版本
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            string sCPUSerialNumber = "";
            foreach (ManagementObject mo in searcher.Get())
            {
                sCPUSerialNumber = mo["Name"].ToString().Trim();//获取操作系统名称
            }
            string a = sCPUSerialNumber.Substring(10, 10);
            //判断是否为Windows 11操作系统
            if(a != "Windows 11")
            {
                DialogResult error = MessageBox.Show("本程序仅支持Windows 11操作系统，请升级为Windows 11后使用。", "暂不支持您的电脑", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(error == DialogResult.OK)
                {
                    //结束程序
                    Application.ExitThread();
                }
            }
            //判断是否设置开机自启
            try{
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                if(rk2 != null)
                {
                    //如果存在启动项，则修改菜单选项为选中状态
                    开机自启ToolStripMenuItem.Checked = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("判断失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //判断系统主题是否为自定义模式
            bool judge = judgeSystemColor();
            if (judge == true)
            {
                DialogResult error = MessageBox.Show("检测到系统设置了系统主题模式为自定义模式，这将无法正常使用本程序，请将自定义模式改为”深色“或”浅色“后再打开本程序 。", "设置错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (error == DialogResult.OK)
                {
                    //结束程序
                    Application.ExitThread();
                }
            }
            //启动计时器和定时器
            timer1.Interval = 1000;
            timer1.Start();
        }

        protected bool getTimeSpan(string timeStr)
        {
            //判断当前时间是否不在工作时间段内
            string _strWorkingDayAM = "08:00";//非工作时间上午08:00
            string _strWorkingDayPM = "19:00";//非工作时间下午19:00
            TimeSpan dspWorkingDayAM = DateTime.Parse(_strWorkingDayAM).TimeOfDay;
            TimeSpan dspWorkingDayPM = DateTime.Parse(_strWorkingDayPM).TimeOfDay;

            DateTime t1 = Convert.ToDateTime(timeStr);

            TimeSpan dspNow = t1.TimeOfDay;
            if (dspNow > dspWorkingDayAM && dspNow < dspWorkingDayPM)
            {
                return false;
            }
            return true;
        }

        private bool getSystemColor()
        {
            RegistryKey hkml = Registry.CurrentUser;
            RegistryKey personalize = hkml.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            string registDataOne = personalize.GetValue("AppsUseLightTheme").ToString();
            //检测当前是什么模式（深色）
            if(registDataOne == "0x00000000")
            {
                return false;
            }
            return true;
        }
        private bool judgeSystemColor()
        {
            //判断系统主题是否为自定义模式
            RegistryKey hkml = Registry.CurrentUser;
            RegistryKey personalize = hkml.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            string registDataOne = personalize.GetValue("AppsUseLightTheme").ToString();
            string registDataTwo = personalize.GetValue("SystemUsesLightTheme").ToString();
            if (registDataOne != registDataTwo)
            {
                return true;
            }
            return false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //获取当前主题色是否对应（接口）
            //bool nowColor = getSystemColor();
            //获取当前时间是否在区间
            bool Now = getTimeSpan(DateTime.Now.ToShortTimeString().ToString());
            //判断修改主题色
            if (Now == true)
            {
                RegistryKey hkml = Registry.CurrentUser;
                RegistryKey personalize = hkml.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
                personalize.SetValue("AppsUseLightTheme", 0x00000000);
                personalize.SetValue("SystemUsesLightTheme", 0x00000000);
            }
            else
            {
                RegistryKey hkml = Registry.CurrentUser;
                RegistryKey personalize = hkml.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
                personalize.SetValue("AppsUseLightTheme", 0x00000001);
                personalize.SetValue("SystemUsesLightTheme", 0x00000001);
            }
        }
    }
}
