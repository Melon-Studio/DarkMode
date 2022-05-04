using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMode
{
    delegate string EventHandler();
    internal class Subject
    {
        public event EventHandler Output;
        public string Notify()
        {
            string res = "";
            if (Output != null)
            {
                res = Output();
            }
            return res;
        }
    }

    //声明委托
    

}
