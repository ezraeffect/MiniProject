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
            // a진수를 10진수 String으로 변환
            // String에서 다시 b진수로 변환
            int fromValue = (int)from;
            string tempDECString = Convert.ToInt32(inputValue, (int)from).ToString();
            /*switch (from)
            {
                case Base.BIN: // 2진수에서
                    tempDECString = Convert.ToInt32(inputValue, 2).ToString();
                    break;
                case Base.OCT: // 8진수에서
                    tempDECString = Convert.ToString 
                    break;
                case Base.DEC: // 10진수에서

                    break;
                case Base.HEX: // 16진수에서

                    break;
            }*/
            return string.Empty;
        }
    }
}
