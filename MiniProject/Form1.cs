using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class Form1 : Form
    {
        enum Operators
        {
            None,
            Add,
            Subtract,
            Multiply,
            Divide,
            Equl,

        }

        Operators currentOperator = Operators.None; // 열거형 변수 : currentOperator, 변수 초기화 = Operators.Non


        public Form1()
        {
            InitializeComponent();
        }

        /* 버튼 1 클릭 후
         * string strNumber = textBox_result.Text += "1"; // strNumber에 저장
         *  int intNumber = Int32.Parse(strNumber) // int32.Parse() : 스타일의 숫자 문자열 표현을 32비트 부호 있는 정수로 변환
         *  textBox_result.Text = intNumber.ToString();
         *  
         */
         

    }
}
