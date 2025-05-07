# MiniProject


# Form1

## CallBack 함수 사용
키 입력후 계산기 화면 정보를 Display하는 CallBack 함수
**계산 결과나 입력값을 화면에 표시**
-  calHistory - 계산 진행중인 바로 전 단계의 History 정보 (textBox_View)
-  calDisplayInfo - 현재 입력중인 값 또는 계산 결과 값 표시 (textBox_Result)

> void DisplayCallBack(string calHistory, string calDisplayInfo)
  {
    textBox_result.Text = calDisplayInfo;
    textBox_view.Text = calHistory;
  }

💡생성된 함수
1) 숫자키 '0'~'9'
2) 소수점
3) 백스페이스
4) 소수점
5) 사칙연산자('+', '-', '*', '/')
6) 이퀄(=)
7) C-계산기 초기화, CE-방금 입력한 값 초기화 키

 "CalKeyPressProcess 클래스에 생성된 함수를 DisplayCallBack 함수로 폼 화면에 표시

> 예시) 소수점이 입력되었을 때 처리되는 이벤트 함수
   private void button_writeDot_Click(object sender, EventArgs e)
 {
     calkeypressprocess.AddDot(DisplayCallBack);
 }

---

## Calc2NumberClass 클래스
계산기에서 실질적인 계산을 수행하는 부모 Class

### 사칙연산 enum

> public enum _CalcOperator
{
    _none, // 초기값
    _plus,
    _minus,
    _multiple,
    _divide,
}

### 전역변수 선언 및 초기화

**- 전역변수 선언**
1. 현재 계산된 값을 저장하는 결과값

> public static decimal **calResult** { get; set; } = 0;

2. 이퀄(=) 연산자를 2번 이상 누를 경우 계산될 베이스값 - 마지막 입력 숫자, 계산기 History에서 우측에 배치 된다.

> public static decimal **fixedBaseNumber** { get; set; } = 0;

3. 현재 입력된 사칙연산자 오퍼레이터

> public static _CalcOperator **currentCalcOperator** { get; set; } = _CalcOperator._none;

4. 바로 이전에 입력되거나 수정된 사칙 연산자 오퍼레이터

> public static _CalcOperator **lastCalcOperator** { get; set; } = _CalcOperator._none;

**- 초기화**
>  public static void ClearCalculation()
 {
     calResult = 0;
     fixedBaseNumber = 0;
     lastCalcOperator = 0;
     currentCalcOperator = 0;
 }

### 추상 Class Method
- 상속 받아서 반드시 구현해야 하는 Method

 1) 연산자만 입력한 경우 계산하는 경우
 > public abstract bool Calculation();

 2)  숫자 입력 후 연산자를 입력한 경우 계산하는 경우
 >public abstract bool Calculation(decimal leftNumberA);

 3)  숫자 -> 연산자 -> 숫자 입력후 이퀄(=) 누를 경우 산하는 함수
 >public abstract bool Calculation(decimal leftNumberA, decimal rightNumberB);

> ** ex) 더하기 구현** 
>>  public class Plus : Calc2NumberClass
 {
     // override : 추상Class 구현하는 예약어
     ** // 연산자만 입력한 경우 계산하는 경우**
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
     
  >> ** //숫자 입력 후 연산자를 입력한 경우 계산하는 경우**
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

>> ** //숫자 -> 연산자 -> 숫자 입력후 이퀄(=) 누를 경우 계산하는 함수**
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
     
<span style="color:indianRed"> 뺄셈(-), 곱셉(*), 나눗셈(/) 이하 동일</span>

---
## CalKeyPressProcess 클래스
  
  계산기 key 입력 처리 Class
  
- 변수 3개 생성
1. 바로 전단계 계산식 History를 표시하는 문자 Text

> string **strCalHistory** { get; set; } = "";

2. 현재 계산된 결과값을 표시하는 문자 Text

> string **strCalResult** { get; set; } = "";

3. 현재 입력된 숫자 및 소수점을 표시하는 문자 Text

> string **strInputNumber** { get; set; } = "";


### 1. C, CE 초기화를 처리하는 Method
>**1-1 C : 계산기 전체 초기화 작업**
>>public void ResetCalculation(Action<string, string>dispCallBack) 
<span style="color:green">//dispCallBack - Deligate 인자로 선언</span>
{
    strCalHistory = "";
    strCalResult = "";
    strInputNumber = "0";
 Calc2NumberClass.ClearCalculation();
<span style="color:green">// 화면 정보를 Call Back 함수로 갱신한다.</span>
    if (dispCallBack != null)
    {
    dispCallBack(strCalHistory, strInputNumber);
    }
    }
    
> **1-2 CE : 방금 입력한 값 초기화**
>>  public void ClearLastInput(Action<string, string> dispCallBack)
 {
     <span style="color:green">// 방금 입력한 값을 초기화한다.</span>
     strInputNumber = "0";
     <span style="color:green">// 화면 정보를 Call Back 함수로 갱신한다.</span>
     dispCallBack(strCalHistory, strInputNumber);
 }
 
 ### 2. 숫자키 0~9, 소숫점, 백스페이스 키 입력을 처리하는 Method
 
 > **2-1 키패드 숫자 '0'~'9' 가 입력**
 >> public void AddNumber(string strNum, Action<string, string> dispCallBack)
{
    <span style="color:green">// 이퀄(=) 버튼이 눌린 적 있는 지 확인 (눌렸다면 새 계산을 위해 초기화) </span>
    if(isEqualAssignTriggerdOn == true)
    {
        <span style="color:green">// 계산기를 초기화 한다(누적값, 연산자 등) - 1 cycle 계산 완료</span>
        ResetCalculation(null);
        <span style="color:green">// 이퀄(=) 입력 체크 Flag는 초기화한다.</span>
        isEqualAssignTriggerdOn = false;
    }
    <span style="color:green">// 계산기 초기화 이후 현재 입력 숫자가 "0"이거나, 사칙연산 버튼을 눌렸다면, strInputText에 방금 입력한 값 대입한다. </span>
    if (strInputNumber == "0" || is4kindOperatorTriggeredOn == true)
    {
        <span style="color:green">// 현재 입력된 숫자를 입력 문자로 설정한다.</span>
        strInputNumber = strNum;
        <span style="color:green">// 사칙 연산 버튼 눌림 여부 체크</span>
        if(is4kindOperatorTriggeredOn == true)
        {
            <span style="color:green">// 다음 입력을 위해 연산자 입력 Flag를 꺼줌.</span>
            is4kindOperatorTriggeredOn = false;
        }
    }
    <span style="color:green">// 그렇지 않을 경우 숫자 이어붙이기 </span>
    else
    {
        strInputNumber += strNum;
    }
    <span style="color:green">// strCalHistroy : 지금까지 계산식, strInputNumber : 현재 입력 중인 숫자</span>
    dispCallBack(strCalHistory, strInputNumber);
}

> **2-2 소수점 입력**
>>  public void AddDot(Action<string, string> dispCallBack)
 {
     <span style="color:green">// 사칙연산자를 누른 후 소수점을 입력할 경우에는 입력 화면에 '0.' 으로 표시한다.</span>
     if (is4kindOperatorTriggeredOn == true || isEqualAssignTriggerdOn == true)
     {
         strInputNumber = "0";
         <span style="color:green">//사칙연산자 flag가 true로 설정되어 있으면 false로 초기화한다.</span>
         if(isEqualAssignTriggerdOn == true)
         {
             is4kindOperatorTriggeredOn = false;
         }
         <span style="color:green">// 이퀄(=) 입력 flag가 True면 초기화</span>
         if (isEqualAssignTriggerdOn == true)
         {
         <span style="color:green">// 계산기를 초기화 한다 - 1cycle 계산완료</span>
             ResetCalculation(null);
             isEqualAssignTriggerdOn = false;
         }
     }
     <span style="color:green">// 소숫점이 이미 있으면 아무 동작도 하지 않고 종료한다.</span>
     if (strInputNumber.Contains("."))
     {
         return; // 더이상 하지마
     }
     else
     {
         <span style="color:green">// 현재 값이 "0"이면 "0" + "."을 표기한다.</span>
         if(strInputNumber == "0")
         {
             strInputNumber = "0.";
         }
         else
         {
             <span style="color:green">// 현재 값에 소숫점을 추가한다.</span>
             strInputNumber += ".";
         }
     }
     dispCallBack(strCalHistory, strInputNumber);
 }
 
 > **2-3 백스페이스키 입력**
 >> public void BackspaceProcess(Action<string, string> dispCallBack)
{
    <span style="color:green">// 이퀄(=) 눌러 계산이 완료된 상태일 경우, 이전 strCalHistroy를 지운다.</span>
    if (isEqualAssignTriggerdOn == true)
    {
        strCalHistory = "";
    }
    <span style="color:green">// "0" : 기본 상태, "" : 아무 숫자도 없음, 길이가 1 : 숫자 한자리 -> 백스페이스로 지울 필요 없이 "0"으로 유지함 </span>
    if (strInputNumber == "0" || strInputNumber == "" || strInputNumber.Length == 1)
    {
        strInputNumber = "0";
    }
    else
    {
    <span style="color:green">// 입력된 숫자가 2자리 이상일 때, 맨 끝 한자리 제거 </span>
        strInputNumber = strInputNumber.Substring(0, strInputNumber.Length - 1);
    }
    dispCallBack(strCalHistory, strInputNumber);
}

### 3. 사칙연산 키 입력을 처리하는 Method (-, +. *, /)

> **3-1 계산에 사용될 Operator를 얻어온다.**
>>  _CalcOperator GetOperator(string strOperator) 
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
         case "_percent":
             result = _CalcOperator._percent;
             break;
     }
return result;
 }

> **3-2 현재 설정된 연산자를 화면에 표시하기 위해 문자(기호)를 얻어온다.**
>> string GetOperatorString(_CalcOperator calOperator)
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
        case _CalcOperator._percent:
            result = "%";
            break;
    }
    return result;
}

> **3-3 키패드에서 사칙연산자를 눌렀을 경우 호출되는 Method**
>>  public void CalcOperatorInput(string strCalcOperator, Action<string, string> dispCallBack)
 {
    <span style="color:green">// strCalcOperator 문자열 (현재 입력된 연산자)을 내부 열거형(enum) 연산자로 변환하고 계산기 Class에 설정한다.</span>
     Calc2NumberClass.SetOperator(GetOperator(strCalcOperator));
<span style="color:green">// 연속으로 사칙 연산자를 입력하지 않은 경우에만 계산을 진행한다.</span>
     if (is4kindOperatorTriggeredOn == false)
     {
         is4kindOperatorTriggeredOn = true;
         <span style="color:green">// CalculationProcess() 호출해 이전에 입력된 숫자와 연산자를 이용해 중간 계산을 미리 수행</span>
         bool result = CalculationProcess();
     }
 <span style="color:green">// 이퀄(=) 입력 flag가 True면 초기화</span>
     if (isEqualAssignTriggerdOn == true)
     {
         isEqualAssignTriggerdOn = false;
     }
 <span style="color:green">// 방금 입력한 계산식 정보를 화면 상단에 보여줄 계산 히스토리 Text로 생성</span>
     strCalHistory = string.Format("{0} {1}", Calc2NumberClass.calResult, GetOperatorString(Calc2NumberClass.currentCalcOperator));
  <span style="color:green">// 방금 입력한 값 또는 계산 결과를 Text로 생성</span>
     strInputNumber = Calc2NumberClass.calResult.ToString();
 <span style="color:green">// 화면정보를 Call Back 함수로 갱신한다.</span>
     dispCallBack(strCalHistory, strInputNumber);
 }
 
 > **3-4 사칙연산 수행**
 >>  bool CalculationProcess()
<span style="color:green"> 사칙연산 버튼이 눌릴 때 중간 계산을 수행하는 핵심 로직</span>
 {
     <span style="color:green">// 방금 전에 이퀄(=) 연산자가 입력되었다면 계산이 끝난 상태이므로 해당 Flag만 해제하고 연산작업은 수행하지 않는다. - 부호만 바꾼다.</span>
     if (isEqualAssignTriggerdOn == true)
     {
         isEqualAssignTriggerdOn = false;
     }
 <span style="color:green"> // 이전 연산자 (lastCalcOperator)가 존재하고 현재 연산자(currentCalcOperator)와 다르다면, 이전 연산자 기준으로 먼저 계산 수행함 </span>
     else if (Calc2NumberClass.lastCalcOperator != _CalcOperator._none && Calc2NumberClass.lastCalcOperator != Calc2NumberClass.currentCalcOperator)
     {
         Calc2NumberClass clnc = GetCalculationMethod(Calc2NumberClass.lastCalcOperator);
         <span style="color:green"> strInputNumber를 숫자로 변환 후 clnc.Calculation()을 호출해 실제 연산 수행</span>
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
     <span style="color:green"> 현재 연산자와 이전 연산자가 같거나, 이전 연산자가 _none 일 경우, 현재 연산자를 기준으로 연산 진행 </span>
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
 
 
### 4. 이퀄(=) Assign 연산자를 처리하는 Method

> **4-1 이퀄(=) 연산자가 바로 이전에 입력되었는지 체크하는 flag**
>> bool isEqualAssignTriggerdOn { get; set; } = false;

> **4-2 이퀄(=) 연산자가 입력될 경우 호출되는 Method**
>>public void EqualAssignOperatorInput(Action<string, string> dispCallBack)
{
<span style="color:green"> // 실제 계산 수행</span>
    EqualCalProcess();
<span style="color:green"> // 화면 정보를 Call Back 함수로 갱신한다.</span>
    dispCallBack(strCalHistory, strInputNumber);
 isEqualAssignTriggerdOn = true;
}

> **4-3 이퀄(=) 연산자를 처리하는 함수**
/// </summary>
void EqualCalProcess()
{
    <span style="color:green">// 현재 계산을 진행할 연산자에 맞는 계산 클래스 인스턴스를 가져옴</span>
    Calc2NumberClass clnc = GetCalculationMethod(Calc2NumberClass.currentCalcOperator);
<span style="color:green"> // 연산자 클래스가 유효한지, 아무 연산자 없이 숫자만 입력된 경우인지 조건 확인</span>
if (clnc != null || Calc2NumberClass.currentCalcOperator == _CalcOperator._none)
    {
    <<span style="color:green"> // 현재 입력된 문자열 숫자 strInputNumber를 decimal로 변환</span>
        decimal inputnumber = 0;
        if (decimal.TryParse(strInputNumber, out inputnumber))
        {
            <span style="color:green">// 1. 숫자 변환이 성공 되었으면 이퀄(=) 계산을 진행한다.</span>
            <span style="color:green">// 1-1. 계산 History 식 왼쪽에 표시될 숫자 - 현재 계산이 완료된 값 (초기에는 0) </span>
            decimal beforeCalcResult = Calc2NumberClass.calResult;
<span style="color:green"> // 1-2. 계산 History 식 오른쪽에 표시될 숫자 - 현재 입력한 값 </span>
            decimal currentInputNumber = 0;
<span style= "color:green">// 이퀄(=) 연속으로 2번이상 누를 경우에는 이전 현재값에 입력된 값을 이용해서 계산한다.</span>
            if (isEqualAssignTriggerdOn == true)
            {
                currentInputNumber = Calc2NumberClass.fixedBaseNumber;
            }
            else
            {
                <span style="color:green">// 이퀄(=) 최초 1회 입력할 경우 현재 입력값으로 설정한다.</span>
                currentInputNumber = inputnumber;
                <span style="color:green">// 그리고 그 값을 백업한다. -> 추후에 이퀄(=) 연속으로 입력할 경우 History 계산식 우측에 표기되는 값</span>
                Calc2NumberClass.fixedBaseNumber = currentInputNumber;
            }
            <span style="color:green">// 1-3. 연산자 없이 이퀄(=) 누른 경우와 연산자를 입력 후 누른 경우로 구분해서 처리함.</span>
            if(Calc2NumberClass.currentCalcOperator == _CalcOperator._none)
            {
                <span style="color:green">// 현재 입력값을 결과 값으로 설정한다.</span>
                Calc2NumberClass.calResult = currentInputNumber;
                <span style="color:green">// 계산식 History에 표기할 문자를 만든다.</span>
                strCalHistory = string.Format("{0} =", currentInputNumber);
            }
            else
            {
                <span style="color:green">// 계산을 진행한다 : beforeCalcResult + 연산자 + currentInputNumber => Calc2NumberClass.calResult 로 들어간다.</span>
                bool result = clnc.Calculation(beforeCalcResult, currentInputNumber);
                <span style="color:green">// 계산식 History에 표기할 문자를 만든다.</span>
                strCalHistory = string.Format("{0} {1} {2} =", beforeCalcResult, GetOperatorString(Calc2NumberClass.currentCalcOperator), currentInputNumber);
            }
            strInputNumber = Calc2NumberClass.calResult.ToString();
        }
    }
}
