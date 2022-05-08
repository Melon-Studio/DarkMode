using Microsoft.Win32;
using System;
using System.Device.Location;
using System.Diagnostics;
using System.Windows.Forms;


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
            string SunRiseSet = checkBox1.Checked.ToString();
            RegistryKey set = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);
            set.SetValue("startTime", startTime);
            set.SetValue("endTime", endTime);
            set.SetValue("SunRiseSet", SunRiseSet);
            set.Close();
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
            if (key.GetValue("SunRiseSet").ToString() == "True")
            {
                bool x = true;
                checkBox1.Checked = x;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else
            {
                bool x = false;
                checkBox1.Checked = x;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            if (key.GetValue("Language").ToString() == "zh-CN")
            {
                radioButton1.Checked = true;
            }
            if (key.GetValue("Language").ToString() == "zh-TW")
            {
                radioButton2.Checked = true;
            }
            if (key.GetValue("Language").ToString() == "ja-JP")
            {
                radioButton3.Checked = true;
            }
            if (key.GetValue("Language").ToString() == "en-US")
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
            if (language == "zh-TW" && str == "String1")
            {
                return "點擊確定後，重啓程式生效。";
            }
            if (language == "ja-JP" && str == "String1")
            {
                return "[OK]をクリックした後、ソフトウェアを再起動して有効にします。";
            }
            if (language == "en-US" && str == "String1")
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
            if (language == "zh-CN" && str == "String3")
            {
                return "经度：";
            }
            if (language == "zh-TW" && str == "String3")
            {
                return "經度：";
            }
            if (language == "ja-JP" && str == "String3")
            {
                return "経度：";
            }
            if (language == "en-US" && str == "String3")
            {
                return "Longitude: ";
            }
            if (language == "zh-CN" && str == "String4")
            {
                return "纬度：";
            }
            if (language == "zh-TW" && str == "String4")
            {
                return "緯度：";
            }
            if (language == "ja-JP" && str == "String4")
            {
                return "緯度：";
            }
            if (language == "en-US" && str == "String4")
            {
                return "Latitude: ";
            }
            //5
            if (language == "zh-CN" && str == "String5")
            {
                return "获取超时";
            }
            if (language == "zh-TW" && str == "String5")
            {
                return "獲取超時";
            }
            if (language == "ja-JP" && str == "String5")
            {
                return "タイムアウト";
            }
            if (language == "en-US" && str == "String5")
            {
                return "Time out";
            }
            return "null";
        }


        GeoCoordinateWatcher watcher;

        public void GetLocationEvent()
        {
            watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            bool started = watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));
            if (!started)
            {
                label5.Text = StringText("String5");
            }
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            PrintPosition(e.Position.Location.Latitude, e.Position.Location.Longitude);

        }

        void PrintPosition(double Latitude, double Longitude)
        {
            label5.Text = StringText("String3") + Longitude.ToString() + "\n" + StringText("String4") + Latitude.ToString();
            watcher.Dispose();
            SunTimeResult result = SunTimes.GetSunTime(DateTime.Now, double.Parse(Longitude.ToString()), double.Parse(Latitude.ToString()));
            RegistryKey set = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);
            set.SetValue("startTime", result.SunriseTime.ToString("HH:mm:ss"));
            set.SetValue("endTime", result.SunsetTime.ToString("HH:mm:ss"));
            dateTimePicker1.Text = set.GetValue("startTime").ToString();
            dateTimePicker2.Text = set.GetValue("endTime").ToString();

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                GetLocationEvent();
            }
            else
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                label5.Text = null;
            }


        }
    }
}
