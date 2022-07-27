using Microsoft.Win32;
using System;
using System.Device.Location;
using System.Diagnostics;
using System.Threading.Tasks;
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
            //语言设置
            tabPage1.Text = Language.Form2Lang("String1");
            label1.Text = Language.Form2Lang("String2");
            label2.Text = Language.Form2Lang("String3");
            label4.Text = Language.Form2Lang("String4");
            tabPage2.Text = Language.Form2Lang("String5");
            label3.Text = Language.Form2Lang("String6");
            tabPage3.Text = Language.Form2Lang("String7");
            groupBox1.Text = Language.Form2Lang("String8");
            label7.Text = Language.Form2Lang("String9");
            label8.Text = Language.Form2Lang("String10");
            label10.Text = Language.Form2Lang("String9");
            label9.Text = Language.Form2Lang("String10");
            groupBox2.Text = Language.Form2Lang("String11");
            label12.Text = Language.Form2Lang("String12");
            button3.Text = Language.Form2Lang("String13");
            button4.Text = Language.Form2Lang("String13");
            button5.Text = Language.Form2Lang("String13");
            button6.Text = Language.Form2Lang("String13");
            button1.Text = Language.Form2Lang("String14");
            button2.Text = Language.Form2Lang("String14");
            button7.Text = Language.Form2Lang("String14");
            Text = Language.Form2Lang("String15");


            //初始化组件获取注册表值
            RegistryKey key;
            key = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);
            dateTimePicker1.Text = key.GetValue("startTime").ToString();
            dateTimePicker2.Text = key.GetValue("endTime").ToString();
            textBox1.Text = key.GetValue("light_ys").ToString();
            textBox2.Text = key.GetValue("dark_ys").ToString();
            textBox3.Text = key.GetValue("light_we").ToString();
            textBox4.Text = key.GetValue("dark_we").ToString();
            if (key.GetValue("SunRiseSet").ToString() == "True")
            {
                bool x = true;
                checkBox1.Checked = x;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                bool x = false;
                checkBox1.Checked = x;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
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
            string language = Registry.GetValue("HKEY_CURRENT_USER\\Software\\DarkMode", "Language", "").ToString();
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
            if (language == "zh-CN" && str == "String6")
            {
                return "地址：";
            }
            if (language == "zh-TW" && str == "String6")
            {
                return "地址：";
            }
            if (language == "ja-JP" && str == "String6")
            {
                return "住所：";
            }
            if (language == "en-US" && str == "String6")
            {
                return "Address: ";
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
        
        async void PrintPosition(double Latitude, double Longitude)
        {
            IPAddress iP = new IPAddress();
            SunTimeResult result = SunTimes.GetSunTime(DateTime.Now, double.Parse(Longitude.ToString()), double.Parse(Latitude.ToString()));
            RegistryKey set = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);
            await Task.Run(() =>
            {
                label5.Text = StringText("String3") + Longitude.ToString() + "\n" + StringText("String4") + Latitude.ToString() + "\n" + "IP: " + iP.IP() + "\n" + StringText("String6") + iP.Address();
                watcher.Dispose();
                set.SetValue("startTime", result.SunriseTime.ToString("HH:mm:ss"));
                set.SetValue("endTime", result.SunsetTime.ToString("HH:mm:ss"));
                dateTimePicker1.Text = set.GetValue("startTime").ToString();
                dateTimePicker2.Text = set.GetValue("endTime").ToString();
            });
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

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.jpg;*.jpeg;*.bmp;*.dib;*.png;*.jfif;*.jpe;*.gif;*.tif;*.tiff;*.wdp;*.heic;*.heif;*.heics;*.heifs;*.hif;*.avci;*.avcs;*.avif;*.avifs;";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
            else
            {
                textBox1.Text = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.jpg;*.jpeg;*.bmp;*.dib;*.png;*.jfif;*.jpe;*.gif;*.tif;*.tiff;*.wdp;*.heic;*.heif;*.heics;*.heifs;*.hif;*.avci;*.avcs;*.avif;*.avifs;";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
            }
            else
            {
                textBox2.Text = null;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "json文件|*.json;";
            ofd.InitialDirectory = CmdCommit.WallpaperPath();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = ofd.FileName;
            }
            else
            {
                textBox4.Text = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "json文件|*.json;";
            ofd.InitialDirectory = CmdCommit.WallpaperPath();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = ofd.FileName;
            }
            else
            {
                textBox3.Text = null;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //原生壁纸设置
            RegistryKey Wallpaper = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);
            if(textBox1.Text != "")
            {
                Wallpaper.SetValue("light_ys", textBox1.Text);
            }
            if(textBox2.Text != "")
            {
                Wallpaper.SetValue("dark_ys", textBox2.Text);
            }
            //Wallpaper Engine壁纸设置
            RegistryKey WE = Registry.CurrentUser.OpenSubKey(@"Software\DarkMode", true);
            if (textBox1.Text != "")
            {
                WE.SetValue("light_we", textBox3.Text);
            }
            if (textBox2.Text != "")
            {
                WE.SetValue("dark_we", textBox4.Text);
            }
            
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/Melon-Studio/DarkMode/wiki/wallpaper-engine%E5%A3%81%E7%BA%B8%E8%AE%BE%E7%BD%AE");
        }
    }
}
