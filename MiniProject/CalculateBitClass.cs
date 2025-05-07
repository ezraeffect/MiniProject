using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    internal class CalculateBitClass
    {
        public string CalculateWithOperation(string str, Base @base)
        {
            ConvertBaseClass cb = new ConvertBaseClass();
            string[] tokenizeString = TokenizeExpression(str);

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

        public string CalculateNotGateOoperation(string str, Base @base)
        {
            ConvertBaseClass cb = new ConvertBaseClass();
            long result = ~long.Parse(cb.ConvertBase(@base, Base.DEC, str));
            return result.ToString();
        }

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
    }
}
