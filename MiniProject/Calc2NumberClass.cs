using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{

    /// <summary>
    /// 사칙연산자 열거형 변수 선언
    /// </summary>
    public enum _CalcOperator
    {
        _none, // 초기값
        _pluse,
        _minus,
        _multiple,
        _divide
    }

    /// <summary>
    /// 계산기에서 실질적인 계산을 수행하는 부모 Class 이다.
    /// abstract : 추상클래스 // 반드시 상속받아서 구현가능
    /// </summary>

    public abstract class Calc2NumberClass
    {
        #region 전역변수 선언 및 초기화

        // 계산결과를 저장하는 전역변수(= static)
        // 현재 계산된 값을 저장하는 결과값 - 전역변수
        public static decimal calResult { get; set; } = 0;  // decimal : 어마어마하게 큰 고정 소수점 숫자

        /// <summary>
        /// 이퀄(=) 연산자를 2번 이상 누를 경우 계산될 베이스값 - 마지막 입력 숫자, 계산기 History에서 우측에 배치 된다.
        /// </summary>
        public static _CalcOperator fixedBaseNumber { get; set; } = _CalcOperator._none;

        /// <summary>
        /// 현재 입력된 사칙연산자 오퍼레이터
        /// </summary>
        public static _CalcOperator currentCalcOperator { get; set; } = _CalcOperator._none;

        /// <summary>
        /// 바로 이전에 입력되거나 수정된 사칙 연산자 오퍼레이터
        /// </summary>
        public static _CalcOperator LastCalcOperator { get; set; } = _CalcOperator._none;

        /// <summary>
        /// 계산기 전역 변수 초기화 함수
        /// </summary>
        public static void ClearCalculation()
        {
            calResult = 0;
            fixedBaseNumber = 0;
            LastCalcOperator = 0;
            currentCalcOperator = 0;
        }

        #endregion

        /// <summary>
        /// 계산기에서 현재 계산을 진행할 연산자 오퍼레이터를 설정하는 Method
        /// </summary>
        /// <param name="calcOperator">계산기에서 누른 연산자</param>
        public static void SetOperator(_CalcOperator calcOperator)
        {
            // 바로 이전 연산자를 현재 연산자 값으로 설정한다.
            LastCalcOperator = calcOperator;

            // 현재 연산자를 파라메터로 전달된 연산자로 설정한다.
            currentCalcOperator = calcOperator;
        }

        #region 추상 Class Method - 상속 받아서 반드시 구현해야 하는 Method
        // 연산자만 입력한 경우 계산하는 경우
        public abstract bool Calculation();

        // 숫자 입력 후 연산자를 입력한 경우 계산하는 경우
        public abstract bool Calculation(decimal leftNumberA);

        // 숫자 -> 연산자 -> 숫자 입력후 이퀄(=) 누를 경우 계산하는 함수
        public abstract bool Calculation(decimal leftNumberA, decimal rightNumberB);

        #endregion
    }

    #region 1. 더하기 (+) Class 구현
    // 더하기(+) 기능 클래스 (Calc2NumberClass 부모 클래스를 상속받겠다.)
    public class Plus : Calc2NumberClass
    {
        // override : 상속받는 예약어
        // 연산자만 입력한 경우 계산하는 경우
        public override bool Calculation()
        {
            try
            {
                // 아무일도 하지 않는다.
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 숫자 입력 후 연산자를 입력한 경우 계산하는 경우
        public override bool Calculation(decimal leftNumberA)
        {
            try
            {
                calResult += leftNumberA;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 숫자 -> 연산자 -> 숫자 입력후 이퀄(=) 누를 경우 계산하는 함수
        public override bool Calculation(decimal leftNumberA, decimal rightNumberB)
        {
            try
            {
                calResult = leftNumberA + rightNumberB;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    #endregion

    #region 2. 빼기 (-) Class 구현
    public class Minus : Calc2NumberClass
    {
        // override : 상속받는 예약어
        // 연산자만 입력한 경우 계산하는 경우
        public override bool Calculation()
        {
            try
            {
                // 아무일도 하지 않는다.
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 숫자 입력 후 연산자를 입력한 경우 계산하는 경우
        public override bool Calculation(decimal leftNumberA)
        {
            try
            {
                if (LastCalcOperator == _CalcOperator._none && calResult == 0)
                {
                    // 계산기 초기화 후 최초로 연산자가 입력된 경우, 해당 입력 값을 계산값으로 설정함.
                    calResult = leftNumberA;
                }
                else
                {
                    calResult -= leftNumberA;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 숫자 -> 연산자 -> 숫자 입력후 이퀄(=) 누를 경우 계산하는 함수
        public override bool Calculation(decimal leftNumberA, decimal rightNumberB)
        {
            try
            {
                calResult = leftNumberA - rightNumberB;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    #endregion

    #region 3. 곱하기 (*) 기능 Class
    public class Multiple : Calc2NumberClass
    {
        // override : 상속받는 예약어
        // 연산자만 입력한 경우 계산하는 경우
        public override bool Calculation()
        {
            try
            {
                // 아무일도 하지 않는다.
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 숫자 입력 후 연산자를 입력한 경우 계산하는 경우
        public override bool Calculation(decimal leftNumberA)
        {
            try
            {
                calResult *= leftNumberA;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 숫자 -> 연산자 -> 숫자 입력후 이퀄(=) 누를 경우 계산하는 함수
        public override bool Calculation(decimal leftNumberA, decimal rightNumberB)
        {
            try
            {
                calResult = leftNumberA * rightNumberB;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    #endregion

    #region 4. 나누기(/) 기능 Class
    public class Divide : Calc2NumberClass
    {
        // override : 상속받는 예약어
        // 연산자만 입력한 경우 계산하는 경우
        public override bool Calculation()
        {
            try
            {
                // 아무일도 하지 않는다.
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 숫자 입력 후 연산자를 입력한 경우 계산하는 경우
        public override bool Calculation(decimal leftNumberA)
        {
            try
            {
                calResult /= leftNumberA;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 숫자 -> 연산자 -> 숫자 입력후 이퀄(=) 누를 경우 계산하는 함수
        public override bool Calculation(decimal leftNumberA, decimal rightNumberB)
        {
            try
            {
                calResult = leftNumberA / rightNumberB;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    #endregion
}
