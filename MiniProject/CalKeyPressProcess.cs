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
        /// 현재 입력된 숫자 및 소수점을 표시하는 문자 Text
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
        public void ResetCalculation(Action<string, string>dispCallBack) //dispCallBack - Deligate 인자로 선언
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
            //// 사칙연산자가 눌린 이후 소숫점을 입력할 경우에는
            //// 입력 화면에 '0.' 으로 표시한다.
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

        #region 3. 사칙연산 키 입력을 처리하는 Method (-, +. *, /)

        // 현재 입력된 연산자 Tag를 체크하여 계산에 사용될 Operator를 얻어온다.
        _CalcOperator GetOperator(string strOperator) 
        {
            _CalcOperator result = _CalcOperator._none;

            switch (strOperator)
            {
                case "_plus":
                    result = _CalcOperator._plus;
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
                case _CalcOperator._plus:
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
        /// <param name="strCalcOperator"></param>
        /// <param name="dispCallBack"></param>
        public void CalcOperatorInput(string strCalcOperator, Action<string, string> dispCallBack)
        {

            // 현재 입력된 연산자를 계산기 Class에 설정한다.
            Calc2NumberClass.SetOperator(GetOperator(strCalcOperator));


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
        /// 사칙연산자 버튼을 눌렸는지의 여부 확인
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
            if (Calc2NumberClass.lastCalcOperator != _CalcOperator._none && Calc2NumberClass.lastCalcOperator != Calc2NumberClass.currentCalcOperator)
            {
                //Calc2NumberClass 부모 class를 사용하면 상속받은 디바이스 모두 사용가능
                Calc2NumberClass clnc = GetCalculationMethod(Calc2NumberClass.lastCalcOperator);
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
                case _CalcOperator._plus:
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
        /// 이퀄(=) 연산자가 바로 이전에 입력되었는지 체크하는 flag
        /// </summary>
        bool isEqualAssignTriggerdOn { get; set; } = false;

        /// <summary>
        /// 이퀄(=) 연산자가 입력될 경우 호출되는 Method
        /// </summary>
        /// <param name="dispCallBack"></param>
        public void EqualAssignOperatorInput(Action<string, string> dispCallBack)
        {
            EqualCalProcess();

            // 화면 정보를 Call Back 함수로 갱신한다.
            dispCallBack(strCalHistory, strInputNumber);

            isEqualAssignTriggerdOn = true;
        }

        /// <summary>
        /// 이퀄(=) 연산자를 처리하는 함수
        /// </summary>
        void EqualCalProcess()
        {
            // 현재 계산을 진행할 연산자 Class를 얻어온다.
            Calc2NumberClass clnc = GetCalculationMethod(Calc2NumberClass.currentCalcOperator);

            // 아래 2가지 조건 중 하나만 만족하면 이퀄(=) 연산자 처리를 수행한다.
            // 1. Null이 아니면 사칙연산자 중에 한개의 작업을 진행한다 - clnc Class Ref => +,-,/,*
            // 2. 숫자만 입력한 후, 또는 아무것도 하지않고 이퀄(=)만 입력한 경우
            if (clnc != null || Calc2NumberClass.currentCalcOperator == _CalcOperator._none)
            {
                decimal inputnumber = 0;
                if (decimal.TryParse(strInputNumber, out inputnumber))
                {
                    // 1. 숫자 변환이 성공 되었으면 이퀄(=) 계산을 진행한다.

                    // 1-1. 계산 History 식 왼쪽에 표시될 숫자 - 현재 계산이 완료된 값 (초기에는 0)
                    decimal beforeCalcResult = Calc2NumberClass.calResult;

                    // 1-2. 계산 History 식 오른쪽에 표시될 숫자 - 현재 입력한 값
                    decimal currentInputNumber = 0;

                    if (isEqualAssignTriggerdOn == true)
                    {
                        // 이퀄(=) 연속으로 2번이상 누를 경우에는 이전 현재값에 입력된 값을 이용해서 계산한다.
                        currentInputNumber = Calc2NumberClass.fixedBaseNumber;
                    }
                    else
                    {
                        // 이퀄(=) 최초 1회 입력할 경우 현재 입력값으로 설정한다.
                        currentInputNumber = inputnumber;

                        // 그리고 그 값을 백업한다. -> 추후에 이퀄(=) 연속으로 입력할 경우 History 계산식 우측에 표기되는 값
                        Calc2NumberClass.fixedBaseNumber = currentInputNumber;
                    }


                    // 1-3. 연산자 없이 이퀄(=) 누른 경우와 연산자를 입력 후 누른 경우로 구분해서 처리함.
                    if(Calc2NumberClass.currentCalcOperator == _CalcOperator._none)
                    {
                        // 현재 입력값을 결과 값으로 설정한다.
                        Calc2NumberClass.calResult = currentInputNumber;

                        // 계산식 History에 표기할 문자를 만든다.
                        strCalHistory = string.Format("{0} =", currentInputNumber);
                    }
                    else
                    {
                        // 계산을 진행한다 : beforeCalcResult + 연산자 + currentInputNumber => Calc2NumberClass.calResult 로 들어간다.
                        bool result = clnc.Calculation(beforeCalcResult, currentInputNumber);

                        // 계산식 History에 표기할 문자를 만든다.
                        strCalHistory = string.Format("{0} {1} {2} =", beforeCalcResult, GetOperatorString(Calc2NumberClass.currentCalcOperator), currentInputNumber);
                    }

                    strInputNumber = Calc2NumberClass.calResult.ToString();
                }
            }
        }

        #endregion

    }
}
