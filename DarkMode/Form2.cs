using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DarkMode
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
    }
}
