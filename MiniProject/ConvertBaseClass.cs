using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{

    internal class ConvertBaseClass
    {
        public string ConvertBase(Base from, Base to, string inputValue)
        {
            int fromValue = (int)from;
            if (inputValue == null || inputValue == "0" || inputValue == "")
            {
                return "0";
            }
            else
            {
                int decimalValue = Convert.ToInt32(inputValue, fromValue); // OverflowException 예외 처리 필요
                return Convert.ToString(decimalValue, (int)to);
            }
        }

        public string[] ConvertAllBase(Base from, string inputValue)
        {
            string[] result = new string[4];

            result[0] = ConvertBase(from, Base.HEX, inputValue);
            result[1] = ConvertBase(from, Base.DEC, inputValue);
            result[2] = ConvertBase(from, Base.OCT, inputValue);
            result[3] = ConvertBase(from, Base.BIN, inputValue);
            
            return result;
        }
    }
}
