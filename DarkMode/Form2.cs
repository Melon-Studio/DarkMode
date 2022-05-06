using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DarkMode
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Language.NowLanguage().ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //写入时间数据到注册表
            string startTime = dateTimePicker1.Text.ToString();
            string endTime = dateTimePicker2.Text.ToString();
            RegistryKey time = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);
            time.SetValue("startTime", startTime);
            time.SetValue("endTime", endTime);
            time.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(StringText("String1"), StringText("String2"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //写入语言数据到注册表
            RegistryKey lang = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);
            if (radioButton1.Checked == true)
            {
                lang.SetValue("Language", "zh-CN");
            }
            if (radioButton2.Checked == true)
            {
                lang.SetValue("Language", "zh-TW");
            }
            if (radioButton3.Checked == true)
            {
                lang.SetValue("Language", "ja-JP");
            }
            if (radioButton4.Checked == true)
            {
                lang.SetValue("Language", "en-US");
            }
            lang.Close();
            Process.Start(Application.ExecutablePath);
            Process.GetCurrentProcess().Kill();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //初始化组件获取注册表值
            RegistryKey key;
            key = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);
            dateTimePicker1.Text = key.GetValue("startTime").ToString();
            dateTimePicker2.Text = key.GetValue("endTime").ToString();
            if(key.GetValue("Language").ToString() == "zh-CN")
            {
                radioButton1.Checked = true;
            }
            if(key.GetValue("Language").ToString() == "zh-TW")
            {
                radioButton2.Checked = true;
            }
            if(key.GetValue("Language").ToString() == "ja-JP")
            {
                radioButton3.Checked = true;
            }
            if(key.GetValue("Language").ToString() == "en-US")
            {
                radioButton4.Checked = true;
            }
            key.Close();
        }
        //语言类
        public static string StringText(string str)
        {
            string language = new System.Globalization.CultureInfo(Language.NowLanguage().ToString()).ToString();
            if (language == "zh-CN" && str == "String1")
            {
                return "点击确定后，重启程序生效。";
            }
            if(language == "zh-TW" && str == "String1")
            {
                return "點擊確定後，重啓程式生效。";
            }
            if(language == "ja-JP" && str == "String1")
            {
                return "[OK]をクリックした後、ソフトウェアを再起動して有効にします。";
            }
            if(language == "en-US" && str == "String1")
            {
                return "After clicking OK, restart the software to take effect.";
            }

            if (language == "zh-CN" && str == "String2")
            {
                return "提示";
            }
            if (language == "zh-TW" && str == "String2")
            {
                return "提示";
            }
            if (language == "ja-JP" && str == "String2")
            {
                return "ソフト";
            }
            if (language == "en-US" && str == "String2")
            {
                return "Tips";
            }
            return "null";
        }
    }
}
