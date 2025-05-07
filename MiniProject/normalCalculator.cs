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
    public partial class normalCalculator : Form
    {
        private Timer timer = new Timer();

        /// <summary>
        /// 계산기 키 입력을 처리하는 Class
        /// 숫자패드 0~9, 소숫점, 사책연산, 이퀄, C, CE 초기화
        /// </summary>
        CalKeyPressProcess calkeypressprocess = new CalKeyPressProcess();
        public normalCalculator()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form1_Load);
            timer1.Tick += new EventHandler(timer1_Tick);

            calkeypressprocess.ResetCalculation(DisplayCallBack);


            // 초기화
            //textBox_view.Text = string.Empty;
            //textBox_result.Text = "0";
        }

        #region 1. 숫자키 '0'~'9', 소수점, 백스페이스 키 이벤트 처리 루틴

        ///<summary>
        // 숫자키 "0"~"9"가 눌렸을 때 처리되는 이벤트 함수
        void NumberKeyPress_0to9_Event(object sender, EventArgs e)
        {
            string strNumber = "";
            strNumber = (sender as Button).Text;  // sender가 버튼으로 "as" 형변환

            calkeypressprocess.AddNumber(strNumber, DisplayCallBack);
        }

        /// <summary>
        /// 소수점이 입력되었을 때 처리되는 이벤트 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_writeDot_Click(object sender, EventArgs e)
        {
            calkeypressprocess.AddDot(DisplayCallBack);
        }

        /// <summary>
        /// BackSpace 키가 눌렸을 때 처리되는 이벤트 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_backspace_Click(object sender, EventArgs e)
        {
            calkeypressprocess.BackspaceProcess(DisplayCallBack);
        }
        private void button_percent_Click(object sender, EventArgs e)
        {
            //calkeypressprocess.PercentProcess(DisplayCallBack);
        }

        #endregion

        #region 2. 사칙연산자 키 '+', '-', '*', '/', '%'키 이벤트 처리 루틴

        // 사칙연산 키 "+", "-", "*", "/" 눌렸을 때 처리되는 이벤트 함수
        void button4kindOperatorPress_Event(object sender, EventArgs e)
        {
            string strOperator = "";
            strOperator = (string)(sender as Button).Tag; //Tag를 사용할거다. 

            calkeypressprocess.CalcOperatorInput(strOperator, DisplayCallBack);
        }

        #endregion

        #region 3. 이퀄(=) 연산자 키 이벤트 처리 루틴

        /// <summary>
        /// 이퀄(=) Assign 연산자 키를 눌렸을 때 처리되는 이벤트 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_equl_Click(object sender, EventArgs e)
        {
            calkeypressprocess.EqualAssignOperatorInput(DisplayCallBack);
        }

        #endregion

        #region 4. C-계산기 초기화, CE-방금 입력한 값 초기화 키 처리 이벤트

        /// <summary>
        /// "C" - Clear 키가 입력되었을 때 처리되는 이벤트 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_clear_Click(object sender, EventArgs e)
        {
            calkeypressprocess.ResetCalculation(DisplayCallBack);
        }

        /// <summary>
        /// "CE" - Clear Last, 입력된 마지막 값을 초기화하는 키를 눌렸을 때 처리되는 이벤트 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_clearEntry_Click(object sender, EventArgs e)
        {
            calkeypressprocess.ClearLastInput(DisplayCallBack);
        }

        #endregion


        /// <summary>
        /// 키 입력후 계산기 화면 정보를 Display하는 CallBack 함수
        /// 1) 계산 진행중인 바로 전 단계의 History 정보
        /// 2) 현재 입력중인 값 또는 계산 결과값 표시
        /// </summary>
        /// <param name="calHistory"></param> 1) 계산 진행중인 바로 전 단계의 History 정보
        /// <param name="calDisplayInfo"></param> 2) 현재 입력중인 값 또는 계산 결과 값 표시
        void DisplayCallBack(string calHistory, string calDisplayInfo)
        {
            textBox_result.Text = calDisplayInfo;
            textBox_view.Text = calHistory;

            #region 입력한 숫자의 길이별로 화면에 표시되는 Font의 크기를 조정한다.
            if (textBox_result.Text.Length <= 12)
            {
                if (textBox_result.Font.Size != 30)
                {
                    textBox_result.Font = new System.Drawing.Font("Arial", 30);
                }
            }
            else if (textBox_result.Text.Length >= 13 && textBox_result.Text.Length <= 16)
            {
                if (textBox_result.Font.Size != 25)
                {
                    textBox_result.Font = new System.Drawing.Font("Arial", 25);
                }
            }
            else
            {
                if (textBox_result.Font.Size != 18)
                {
                    textBox_result.Font = new System.Drawing.Font("Arial", 18);
                }
            }

            #endregion

        }

        #region 현재 날짜 시간 표시
        void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString();  // lblTimer에 현재 날짜시간 표시,
        }
        #endregion

        

    }


}

