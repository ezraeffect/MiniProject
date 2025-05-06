using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    enum Base:int
    {
        BIN = 2,    // 2진수
        OCT = 8,    // 8진수
        DEC = 10,   // 10진수
        HEX = 16    // 16진수
    }
    internal class ConvertBase
    {
        public string BaseConvert(Base from, Base to, string inputValue)
        {
            int fromValue = (int)from;
            int decimalValue = Convert.ToInt32(inputValue, fromValue);
            return Convert.ToString(decimalValue, (int)to);
        }
    }
}
