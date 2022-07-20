using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text;

namespace DarkMode
{
    internal class IPAddress
    {
        public string IP()
        {
            string url = "https://www.ip.cn/api/index?ip=&type=0";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json;charset=UTF-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            JObject json = JObject.Parse(retString);
            string ip = (string)json["ip"];
            return ip;
        }

        public string Address()
        {
            string url = "https://www.ip.cn/api/index?ip=&type=0";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json;charset=UTF-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            JObject json = JObject.Parse(retString);
            string address = (string)json["address"];
            address = address.Replace("移动", "");
            address = address.Replace("电信", "");
            address = address.Replace("联通", "");
            address = address.Replace("铁通", "");
            address = address.Replace("鹏博士", "");
            address = address.Replace("教育网", "");
            address = address.Replace("长城", "");
            address = address.Replace(" ", "");
            address = address.Replace("省", "");
            address = address.Replace("市", "");
            address = address.Replace("区", "");
            address = address.Replace("县", "");
            return address;
        }
    }
}
