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
    internal class KeyboardInputHandler
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

            // 상단 숫자키, 넘패드를 통한 숫자 처리
            else if ((numKeys.Contains(e.KeyCode) || numPadKeys.Contains(e.KeyCode)) && !e.Shift) // 만약 입력된 KeyValue가 배열에 존재한다면
            {
                int number = Array.IndexOf(numKeys, e.KeyCode); // 우선 상단 숫자키 배열에서 Index를 가져온다
                if (number == -1) number = Array.IndexOf(numPadKeys, e.KeyCode); // 상단 숫자키 배열에서 Index를 찾지 못한다면, 넘패드 배열에서 Index를 가져온다
                Console.WriteLine(number);
                return number.ToString();
            }
            else return string.Empty;
        }
    }
}
