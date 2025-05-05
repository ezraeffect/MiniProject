using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*   키보드 입력 처리 Class 
    - 키보드 입력과 관련된 기능을 처리합니다
 */
namespace MiniProject
{
    public class KeyboardInputHandler
    {
        // GetKeyString(KeyEventArgs e);  
        // - KeyEventArgs 객체를 인자로 하는 메서드  
        // - KeyValue를 비교하여 알맞은 String을 반환한다.  
        // - KeyValue 값은 Notion 문서 "Keyboard 입력을 위한 KeyValue 정리" 참고  
        public string GetKeyString(KeyEventArgs e)
        {
            // Using Only Debug  
            //Console.WriteLine("Pressed: " + e.KeyCode);  
            //Console.WriteLine("Shift: " + e.Shift);  

            // Keys 열거형을 배열로 선언  
            Keys[] numKeys = { Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 };
            Keys[] numPadKeys = { Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9 };

            // 상단 숫자키로 부호 처리  
            if (e.KeyCode == Keys.Oemplus && e.Shift) return "+";           // + 반환 | Shift + Oemplus  
            else if (e.KeyCode == Keys.OemMinus && !e.Shift) return "-";    // - 반환 | OemMinus  
            else if (e.KeyCode == Keys.D8 && e.Shift) return "*";           // * 반환 | Shift + D8  
            else if (e.KeyCode == Keys.OemQuestion && !e.Shift) return "/"; // / 반환 | Shift + OemQuestion  

            // 넘패드로 부호 처리  
            else if (e.KeyCode == Keys.Add) return "+";                     // + 반환 | Add  
            else if (e.KeyCode == Keys.Subtract) return "-";                // - 반환 | Subtract  
            else if (e.KeyCode == Keys.Multiply) return "*";                // * 반환 | Multiply  
            else if (e.KeyCode == Keys.Divide) return "/";                  // / 반환 | Divide  

            // 괄호 처리  
            else if (e.KeyCode == Keys.D9 && e.Shift) return "(";           // ( 반환 | Shift + D9  
            else if (e.KeyCode == Keys.D0 && e.Shift) return ")";           // ) 반환 | Shift + D0  

            // 엔터 처리  
            else if (e.KeyCode == Keys.Return) return "=";                  // / 반환 | Return  

            // Backspace 처리  
            else if (e.KeyCode == Keys.Back) return "BS";                   // BS 반환 | Back  

            // 상단 숫자키, 넘패드를 통한 숫자 처리  
            else if ((numKeys.Contains(e.KeyCode) || numPadKeys.Contains(e.KeyCode)) && !e.Shift) // 만약 입력된 KeyCode가 배열에 존재한다면  
            {
                int number = Array.IndexOf(numKeys, e.KeyCode); // 우선 상단 숫자키 배열에서 Index를 가져온다  
                if (number == -1) number = Array.IndexOf(numPadKeys, e.KeyCode); // 상단 숫자키 배열에서 Index를 찾지 못한다면, 넘패드 배열에서 Index를 가져온다  
                return number.ToString();
            }
            else return string.Empty;
        }

        // GetHexString(KeyEventArgs e);  
        // - KeyEventArgs 객체를 인자로 하는 메서드  
        // - KeyValue를 비교하여 알맞은 String을 반환한다.  
        // - 16진수 계산을 위한 A,B,C,D,E,F 추가  

        public enum Base // 진법을 지정합니다.
        {
            BIN,
            OCT,
            DEC,
            HEX
        }

        public string GetBaseKeyString(KeyEventArgs e, Base @base)
        {
            // Using Only Debug  
            //Console.WriteLine("Pressed: " + e.KeyCode);  
            //Console.WriteLine("Shift: " + e.Shift);  
            string[] returnStrArray = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"};

            Keys[] charArray = null;

            switch (@base)
            {
                case Base.BIN: // 2진수일때 입력
                    charArray = new Keys[] { Keys.D0, Keys.D1 };
                    break;
                case Base.OCT: // 8진수일때 입력
                    charArray = new Keys[] { Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7 };
                    break;
                case Base.DEC: // 10진수일때 입력
                    charArray = new Keys[] { Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 };
                    break;
                case Base.HEX: // 16진수일때 입력
                    charArray = new Keys[] { Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F };
                    break;
                default: // 기본 값은 10진수
                    charArray = new Keys[] { Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 };
                    break;
            }

            // 상단 숫자키로 부호 처리  
            if (e.KeyCode == Keys.Oemplus && e.Shift) return "+";           // + 반환 | Shift + Oemplus  
            else if (e.KeyCode == Keys.OemMinus && !e.Shift) return "-";    // - 반환 | OemMinus  
            else if (e.KeyCode == Keys.D8 && e.Shift) return "*";           // * 반환 | Shift + D8  
            else if (e.KeyCode == Keys.OemQuestion && !e.Shift) return "/"; // / 반환 | Shift + OemQuestion  

            // 넘패드로 부호 처리  
            else if (e.KeyCode == Keys.Add) return "+";                     // + 반환 | Add  
            else if (e.KeyCode == Keys.Subtract) return "-";                // - 반환 | Subtract  
            else if (e.KeyCode == Keys.Multiply) return "*";                // * 반환 | Multiply  
            else if (e.KeyCode == Keys.Divide) return "/";                  // / 반환 | Divide  

            // 괄호 처리  
            else if (e.KeyCode == Keys.D9 && e.Shift) return "(";           // ( 반환 | Shift + D9  
            else if (e.KeyCode == Keys.D0 && e.Shift) return ")";           // ) 반환 | Shift + D0  

            // 엔터 처리  
            else if (e.KeyCode == Keys.Return) return "=";                  // / 반환 | Return  

            // Backspace 처리  
            else if (e.KeyCode == Keys.Back) return "BS";                   // BS 반환 | Back  


            else if (charArray.Contains(e.KeyCode) && !e.Shift){ // 만약 입력된 KeyCode가 배열에 존재, 그리고 Shift가 눌리지 않았다면
                int charIndex = Array.IndexOf(charArray, e.KeyCode); // 입력된 KeyCode 값이 배열의 어느 Index에 위치하는지 가져온다
                return returnStrArray[charIndex]; 
            }

            else return string.Empty;
        }
    }
}
