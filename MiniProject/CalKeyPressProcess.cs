using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    /// <summary>
    /// 계산기 key 입력 처리 Class
    /// </summary>
    public class CalKeyPressProcess
    {
        /// <summary>
        /// 바로 전단계 계산식 History를 표시하는 문자 Text
        /// textBox_veiw
        /// </summary>
        string strCalHistory { get; set; } = "";

        /// <summary>
        /// 현재 계산된 결과값을 표시하는 문자 Text
        /// textBox_result
        /// </summary>
        string strCalResult { get; set; } = "";

        /// <summary>
        /// 현재 입력된 숫자 및 소숫점을 표시하는 문자 Text
        /// textBox_result
        /// </summary>
        string strInputNumber { get; set; } = "";

        #region 1. C, CE 초기화를 처리하는 Method

        
        /// <summary>
        /// 계산기 전체 초기화 작업
        /// 1) 계산기 Form이 처음 실행될 때 호출됨
        /// 2) C을 눌렀을 때 호출됨
        /// </summary>
        /// <param name="dispCallBack"></param>
        public void ResetCalculation(Action<string, string>dispCallBack)
        {
            strCalHistory = "";
            strCalResult = "";
            strInputNumber = "0";

            Calc2NumberClass.ClearCalculation();

            // 화면 정보를 Call Back 함수로 갱신한다.
            dispCallBack(strCalHistory, strInputNumber);
        }


        /// <summary>
        /// CE - 방금 입력한 값 초기화 키 입력시 호출되는 Method
        /// </summary>
        /// <param name="strCalHistory"></param>
        /// <param name="strInputNumber"></param>
        public void ClearLastInput(Action<string, string> dispCallBack)
        {
            // 방금 입력한 값을 초기화한다.
            strInputNumber = "0";

            // 화면 정보를 Call Back 함수로 갱신한다.
            dispCallBack(strCalHistory, strInputNumber);
        }

        #endregion

        #region 2. 숫자키 0~9, 소숫점, 백스페이스 키 입력을 처리하는 Method
        /// <summary>
        /// 키패드 숫자 '0'~'9' 가 입력되면 호출되는 Method
        /// </summary>
        /// <param name="strNum"></param>
        /// <param name="dispCallBack"></param>
        public void AddNumber(string strNum, Action<string, string> dispCallBack)
        {
            // 계산기 초기화 이후 최초 입력시에는 strInputText에는 방금 입력한 값만 대입한다. 
            if (strInputNumber == "0" || is4kindOperatorTriggeredOn == true)
            {
                // 현재 입력된 숫자를 입력 문자로 설정한다.
                strInputNumber = strNum;

                if(is4kindOperatorTriggeredOn == true)
                {
                    // 사칙연산자 flag가 true로 설정되어 있으면 False로 초기화한다.
                    is4kindOperatorTriggeredOn = false;
                }
            }
            else
            {
                strInputNumber += strNum;
            }

            dispCallBack(strCalHistory, strInputNumber);
        }


        /// <summary>
        /// 소숫점 입력시 호출되는 Method
        /// </summary>
        /// <param name="dispCallBack"></param>
        public void AddDot(Action<string, string> dispCallBack)
        {
            // 사칙연산자가 눌린 이후 소숫점을 입력할 경우에는
            // 입력 화면에 '0.' 으로 표시한다.
            if (is4kindOperatorTriggeredOn == true)
            {
                strInputNumber = "0";

                //사칙연산자 flag가 true로 설정되어 있으면 false로 초기화한다.
                is4kindOperatorTriggeredOn = false;
            }

            // 소숫점이 이미 있으면 아무 동작도 하지 않고 종료한다.
            if (strInputNumber.Contains("."))
            {
                return; // 더이상 하지마
            }
            else
            {
                // 현재 값이 "0"이면 "0" + "."을 표기한다.
                if(strInputNumber == "0")
                {
                    strInputNumber = "0.";
                }
                else
                {
                    // 현재 값에 소숫점을 추가한다.
                    strInputNumber += ".";
                }
            }
            dispCallBack(strCalHistory, strInputNumber);
        }

        /// <summary>
        /// 백스페이스키 입력시 호출되는 Method
        /// </summary>
        /// <param name="dispCallBack"></param>
        public void BackspaceProcess(Action<string, string> dispCallBack)
        {
            if (strInputNumber == "0" || strInputNumber == "" || strInputNumber.Length == 1)
            {
                strInputNumber = "0";
            }
            else
            {
                strInputNumber = strInputNumber.Substring(0, strInputNumber.Length - 1);
            }
            dispCallBack(strCalHistory, strInputNumber);
        }

        #endregion

        #region 3. 사칙연산 키 입력을 처리하는 Method (-, +. *, /0

        // 현재 입력된 연산자 Tag를 체크하여 계산에 사용될 Operator를 얻어온다.
        _CalcOperator GetOperator(string strOperator) 
        {
            _CalcOperator result = _CalcOperator._none;

            switch (strOperator)
            {
                case "_plus":
                    result = _CalcOperator._pluse;
                    break;

                case "_minus":
                    result = _CalcOperator._minus;
                    break;

                case "_multiple":
                    result = _CalcOperator._multiple;
                    break;

                case "_divide":
                    result = _CalcOperator._divide;
                    break;
            }

            return result;
        }

        /// <summary>
        /// 현재 설정된 연산자를 화면에 표시하기 위해 문자(기호)를 얻어온다.
        /// </summary>
        /// <param name="calOperator"></param>
        /// <returns></returns>
        string GetOperatorString(_CalcOperator calOperator)
        {
            string result = "";
            switch (calOperator)
            {
                case _CalcOperator._pluse:
                    result = "+";
                    break;
                case _CalcOperator._minus:
                    result = "-";
                    break;
                case _CalcOperator._multiple:
                    result = "*";
                    break;
                case _CalcOperator._divide:
                    result = "/";
                    break;
            }

            return result;
        }

        /// <summary>
        /// 키패드에서 사칙연산자를 눌렀을 경우 호출되는 Method
        /// </summary>
        /// <param name="strCalOperator"></param>
        /// <param name="dispCallBack"></param>
        public void CalcOperatorInput(string strCalOperator, Action<string, string> dispCallBack)
        {

            // 현재 입력된 연산자를 계산기 Class에 설정한다.
            Calc2NumberClass.SetOperator(GetOperator(strCalOperator));


            // 연속으로 사칙 연산자를 입력하지 않은 경우에만 계산을 진행한다.
            if (is4kindOperatorTriggeredOn == false)
            {
                is4kindOperatorTriggeredOn = true;
                // 연산자 계산 처리를 이곳에서 해야 한다.
                bool result = CalculationProcess();
            }

            
            // 방금 입력한 계산식 정보를 Text로 생성
            strCalHistory = string.Format("{0} {1}", Calc2NumberClass.calResult, GetOperatorString(Calc2NumberClass.currentCalcOperator));

            // 방금 입력한 값 또는 계산 결과를 Text로 생성
            strInputNumber = Calc2NumberClass.calResult.ToString();

            // 화면정보를 Call Back 함수로 갱신한다.
            dispCallBack(strCalHistory, strInputNumber);
        }

        /// <summary>
        /// 사칙연산자 버튼이 눌렸는지의 여부 확인
        /// 1. 설정 : 사칙연산자 입력시 True로 설정됨
        /// 2. 해제 : 숫자 "0" ~ "9", 소숫점, 이퀄(=), C(클리어) 입력되면 해제된다.
        /// </summary>
        bool is4kindOperatorTriggeredOn { get; set; } = false;

        /// <summary>
        /// 사칙연산을 수행함.
        /// </summary>
        /// <returns></returns>
        bool CalculationProcess()
        {
            // 최초 입력 연산자가 아닐 경우 
            // 연산자 입력시 이전 연산자와 틀릴경우에는 마지막으로 입력된 사칙 연산자를 이용해서 먼저 계산한다.
            if (Calc2NumberClass.LastCalcOperator != _CalcOperator._none && Calc2NumberClass.LastCalcOperator != Calc2NumberClass.currentCalcOperator)
            {
                Calc2NumberClass clnc = GetCalculationMethod(Calc2NumberClass.LastCalcOperator);
                if (clnc != null)
                {
                    decimal inputNumber = 0;
                    if (decimal.TryParse(strInputNumber, out inputNumber))
                    {
                        clnc.Calculation(inputNumber);
                        return true;
                    }
                }
            }
            else
            {
                Calc2NumberClass clnc = GetCalculationMethod(Calc2NumberClass.currentCalcOperator);

                decimal inputNumber = 0;
                if (decimal.TryParse(strInputNumber, out inputNumber))
                {
                    clnc.Calculation(inputNumber);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 전달된 사칙연산자의 종류에 따라 계산을 진행할 자식 Class Instance를 생성해서 얻어옴.
        /// </summary>
        /// <param name="calcOperator"></param>
        /// <returns></returns>
        Calc2NumberClass GetCalculationMethod(_CalcOperator calcOperator)
        {
            Calc2NumberClass clnc = null;
            switch(calcOperator)
            {
                case _CalcOperator._pluse:
                    clnc = new Plus();
                    break;
                case _CalcOperator._minus:
                    clnc = new Minus();
                    break;
                case _CalcOperator._multiple:
                    clnc = new Multiple();
                    break;
                case _CalcOperator._divide:
                    clnc = new Divide();
                    break;
            }    
            return clnc;
        }

        #endregion

        #region 4. 이퀄(=) Assign 연산자를 처리하는 Method

        /// <summary>
        /// 이퀄(=) 연산자가 입력될 경우 호출되는 Method
        /// </summary>
        /// <param name="dispCallBack"></param>
        public void EqualAssignOperatorInput(Action<string, string> dispCallBack)
        {
            dispCallBack(strCalHistory, strInputNumber);
        }

        #endregion

    }
}
