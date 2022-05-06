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
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Language.NowLanguage().ToString());
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Language.StringText("String1"), Language.StringText("String2"));
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
                MessageBox.Show(Language.StringText("String3") + ex.Message, Language.StringText("String4"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string language = new System.Globalization.CultureInfo(Language.NowLanguage().ToString()).ToString();
            if (language == "zh-CN")
            {
                SettingsToolStripMenuItem.Text = "设置";
                SelfOnToolStripMenuItem.Text = "开机自启";
                AboutToolStripMenuItem.Text = "关于";
                ExitToolStripMenuItem.Text = "退出";
            }
            if (language == "zh-TW")
            {
                SettingsToolStripMenuItem.Text = "設定";
                SelfOnToolStripMenuItem.Text = "開機自啟";
                AboutToolStripMenuItem.Text = "關於";
                ExitToolStripMenuItem.Text = "登出";
            }
            if (language == "ja-JP")
            {
                SettingsToolStripMenuItem.Text = "設定";
                SelfOnToolStripMenuItem.Text = "自動スタート";
                AboutToolStripMenuItem.Text = "約";
                ExitToolStripMenuItem.Text = "終了する";
            }
            if (language == "en-US")
            {
                SettingsToolStripMenuItem.Text = "Settings";
                SelfOnToolStripMenuItem.Text = "Automatic start";
                AboutToolStripMenuItem.Text = "About";
                ExitToolStripMenuItem.Text = "Exit";
            }

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
                DialogResult error = MessageBox.Show(Language.StringText("String5"), Language.StringText("String6"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(error == DialogResult.OK)
                {
                    //结束程序
                    Application.ExitThread();
                }
            }
            //注册表初始化
            try
            {
                RegistryKey pan;
                RegistryKey key;
                pan = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode");
                
                if (pan == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(@"Software\DarkMode");
                    key = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);
                    key.SetValue("startTime", "08:00");
                    key.SetValue("endTime", "19:00");
                    key.SetValue("Language", "zh-CN");
                    key.Close();//关闭连接
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(Language.StringText("String7") + ex.Message, Language.StringText("String4"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            //获取界面语言
            try
            {
                RegistryKey key;
                key = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);

                string lang = key.GetValue("Language").ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(Language.StringText("String8") + ex.Message, Language.StringText("String4"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //判断是否设置开机自启
            try{
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                string exist = rk.GetValue("DarkMode").ToString();
                if(exist != "")
                {
                    //如果存在启动项，则修改菜单选项为选中状态
                    SelfOnToolStripMenuItem.Checked = true;
                }

            }catch
            {
                
            }
            
            //判断系统主题是否为自定义模式
            bool judge = judgeSystemColor();
            if (judge == true)
            {
                MessageBox.Show(Language.StringText("String9"), Language.StringText("String10"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //启动计时器和定时器
            timer1.Interval = 1000;
            timer1.Start();
        }

        protected bool getTimeSpan(string timeStr)
        {
            //获取设置的时间
            RegistryKey set = Registry.CurrentUser;
            RegistryKey set2 = set.OpenSubKey(@"Software\DarkMode");
            string start = set2.GetValue("startTime").ToString();
            string finish = set2.GetValue("endTime").ToString();
            //判断当前时间是否不在工作时间段内
            string _strWorkingDayAM = start;//非工作时间上午08:00
            string _strWorkingDayPM = finish;//非工作时间下午19:00
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
            //检测当前是什么模式（深色返回true）
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

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
