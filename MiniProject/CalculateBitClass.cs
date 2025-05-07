using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    internal class CalculateBitClass
    {
        // 사칙 연산 및 Bit Shift, Logic Gate 연산 Fucntion
        public string CalculateWithOperation(string str, Base @base)
        {
            ConvertBaseClass cb = new ConvertBaseClass();
            string[] tokenizeString = TokenizeExpression(str);

            try
            {
                string operaterString = tokenizeString[1];

                int leftOperand = int.Parse(cb.ConvertBase(@base, Base.DEC, tokenizeString[0]));
                int rightOperand = int.Parse(cb.ConvertBase(@base, Base.DEC, tokenizeString[2]));

                var calResult = 0;
                switch (operaterString)
                {
                    case "+":
                        calResult = leftOperand + rightOperand;
                        break;
                    case "-":
                        calResult = leftOperand - rightOperand;
                        break;
                    case "×":
                        calResult = leftOperand * rightOperand;
                        break;
                    case "÷":
                        calResult = leftOperand / rightOperand;
                        break;
                    case "%":
                        calResult = leftOperand % rightOperand;
                        break;
                    case "<<":
                        calResult = leftOperand << rightOperand;
                        break;
                    case ">>":
                        calResult = leftOperand >> rightOperand;
                        break;
                    case "AND":
                        calResult = leftOperand & rightOperand;
                        break;
                    case "OR":
                        calResult = leftOperand | rightOperand;
                        break;
                    case "NAND":
                        calResult = ~(leftOperand & rightOperand);
                        break;
                    case "XOR":
                        calResult = leftOperand ^ rightOperand;
                        break;
                    case "NOR":
                        calResult = ~(leftOperand | rightOperand);
                        break;
                }
                //Console.WriteLine($"Result {leftOperand} {operaterString} {rightOperand} = {calResult}");
                return cb.ConvertBase(Base.DEC, @base, calResult.ToString());
            }
            catch(IndexOutOfRangeException)
            {
                return "IndexOutOfRange";
            }
            
        }

        // NOT Gate 연산 Function
        public string CalculateNotGateOoperation(string str, Base @base)
        {
            ConvertBaseClass cb = new ConvertBaseClass();
            long result = ~long.Parse(cb.ConvertBase(@base, Base.DEC, str));
            return result.ToString();
        }

        // 계산식을 토큰으로 분리 Function
        private string[] TokenizeExpression(string str)
        {
            StringBuilder sb = new StringBuilder();
            List<string> tokens = new List<string>();
            bool? prevIsDigit = null;

            // 1. 문자열을 한 글자씩 순회.
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                bool isDigit = Char.IsDigit(c); // 2. 

                if (prevIsDigit != null && isDigit != prevIsDigit)
                {
                    tokens.Add(sb.ToString());
                    sb.Clear();
                }

                sb.Append(c);
                prevIsDigit = isDigit;
            }

            if (sb.Length > 0)
            {
                tokens.Add(sb.ToString());
            }

            string[] result = tokens.ToArray();

            return result;
        }

        // BitArray 값을 TabControl 내부의 버튼 Text로 적용하는 Function
        // BitArray -> 비트 키패드
        public void UpdateBitArrayBtn(TabControl tabCtrl, BitArray bitArr)
        {

            /* 1. 텍스트 박스가 변경되면
             * 2. 각진법에 알맞게 변환이 된다
             * 3. string의 n번째 값을 n번째 버튼의 Text로 변경
             * 3-1. string의 n번째 값을 bitArray의 n번에 저장
             * 단, 4비트라 가정했을때 string[0]은 4번 비트를 나타낸다
             * string을 반대로 뒤집으면?
             */
            string convertedBIN = BitArrayToString(bitArr, Base.BIN); // 2진법으로 변환 된 값의 String
            string reversedBIN = new string(convertedBIN.Reverse().ToArray()); // String을 반대로 뒤집어 bitIndex와 stringIndex를 맞춘다
            int len = convertedBIN.Length;
            foreach (Control ctrl in tabCtrl.TabPages[1].Controls)
            {
                if (ctrl is Button btn)
                {
                    string btnNum = new string(btn.Name.Where(char.IsDigit).ToArray()); // string에서 정수만 취한 후 저장
                    int bitIndex = int.Parse(btnNum); // string을 int로 parse

                    if (bitIndex < len) // 배열 범위 이내라면 값 복사
                    {
                        btn.Text = reversedBIN[bitIndex].ToString();
                        bitArr[bitIndex] = reversedBIN[bitIndex] == '0' ? false : true;

                    }
                    else // 배열 범위 밖이라면 무조건 0으로 처리
                    {
                        btn.Text = "0";
                        bitArr[bitIndex] = false;
                    }
                }
            }
        }

        // BitArray를 String으로 변환하는 Function
        // BitArray -> String
        public string BitArrayToString(BitArray bitArray, Base @base)
        {
            ConvertBaseClass cb = new ConvertBaseClass();
            int len = bitArray.Length;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                str.Append(bitArray[i] ? "1" : "0");
            }
            string reversedStr = new string(str.ToString().Reverse().ToArray());

            if (@base == Base.BIN) return reversedStr.TrimStart('0'); // 선택된 진법이 이미 2진법인 경우 변환한 값을 그냥 반환
            else return cb.ConvertBase(Base.BIN, @base, reversedStr.TrimStart('0')); // 아니라면 해당하는 진법으로 변환하여 값 반환
        }

        // 비트 키패드의 현재 값을 bitArray에 적용하는 Function
        // 비트 키패드 -> bitArray
        public BitArray KeypadValueToBitArray(TabControl tabCtrl, BitArray bitArr)
        {
            foreach (Control ctrl in tabCtrl.TabPages[1].Controls)
            {
                if (ctrl is Button btn)
                {
                    string btnName = btn.Name.ToString(); // 클릭된 버튼의 Name 속성을 string으로 변환
                    string btnNum = new string(btn.Name.Where(char.IsDigit).ToArray()); // string에서 정수만 취한 후 저장
                    int bitIndex = int.Parse(btnNum); // string을 int로 parse

                    switch (btn.Text)
                    {
                        case "0":
                            bitArr[bitIndex] = false;
                            break;
                        case "1":
                            bitArr[bitIndex] = true;
                            break;
                    }
                }
            }

            return bitArr;
        }

        // BitArray를 Console에 출력하는 Function
        // !!!! USE ONLY DEBUG !!!!
        public void PrintBitArray(BitArray bitArray)
        {
            StringBuilder sb = new StringBuilder(bitArray.Length);
            for (int i = 0; i < bitArray.Length; i++)
            {
                sb.Append(bitArray[i] ? '1' : '0');
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
