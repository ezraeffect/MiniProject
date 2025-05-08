# KDT 스마트팩토리 SW 개발 단기 5기 미니 프로젝트

---

## 팀원 별 역할 분배

| 팀원 | 역할 |
| --- | --- |
| 👩‍💻 남주현 | 일반 계산기, Form 디자인 |
| 🧑‍💻 이정훈 | 프로그래밍 계산기, 테마 기능 |

## 기능 목록

### 🔢 일반 계산기

- 사칙연산
    - 더하기
    - 빼기
    - 곱하기
    - 나누기
- 키보드 입력
    - 숫자
- 백분율 계산
- Clear
- Clear Entry
- 현재 시각 표시
- 테마 변경 기능

### 💻 프로그래머 계산기

- 사칙연산
    - 더하기
    - 빼기
    - 곱하기
    - 나누기
    - 나머지
- 논리 연산
    - AND (논리곱)
    - OR (논리합)
    - NOT (부정)
    - NAND (Not AND, 부정 논리곱)
    - XOR (Exclusive OR, 배타적 논리합)
    - NOR (Not OR, 부정 논리합)
- 비트 시프트
    - Shift left *(주어진 길이 n만큼 비트를 앞으로 옮김)*
    - Shift right *(주어진 길이 n만큼비트를 뒤로 옮김)*
- 실시간 진수 변환
    - 2진수
    - 8진수
    - 10진수
    - 16진수
- 비트 전환 키패드
- 키보드 입력
    - 숫자 (0~9, A~F)
    - 연산자
- 데이터 자료형 변경
    - Byte (8 bit)
    - Word (16 bit)
    - Dword (32 bit)
    - Qword (64 bit)
- 테마 변경 기능

---

# normalCalculator

## CallBack 함수 사용

키 입력후 계산기 화면 정보를 Display하는 CallBack 함수
**계산 결과나 입력값을 화면에 표시**
- calHistory - 계산 진행중인 바로 전 단계의 History 정보 (textBox_View)
- calDisplayInfo - 현재 입력중인 값 또는 계산 결과 값 표시 (textBox_Result)

```csharp
void DisplayCallBack(string calHistory, string calDisplayInfo)
{
   textBox_result.Text = calDisplayInfo;
   textBox_view.Text = calHistory;
}
```

<aside>
💡

생성된 함수
1) 숫자키 ‘0’~‘9’
2) 소수점
3) 백스페이스
4) 소수점
5) 사칙연산자(‘+’, ‘-’, ’*‘,’/’)
6) 이퀄(=)
7) C-계산기 초기화, CE-방금 입력한 값 초기화 키

</aside>

`CalKeyPressProcess 클래스`에 생성된 함수를 `DisplayCallBack 함수`로 폼 화면에 표시

> 예시) 소수점이 입력되었을 때 처리되는 이벤트 함수
> 

```csharp
private void button_writeDot_Click(object sender, EventArgs e)
{
          calkeypressprocess.AddDot(DisplayCallBack);
}
```

---

## Calc2NumberClass 클래스

계산기에서 실질적인 계산을 수행하는 부모 Class

### 사칙연산 enum

```csharp
public enum _CalcOperator
{
     _none, // 초기값
     _plus,
     _minus,
     _multiple,
     _divide
}
```

### 전역변수 선언 및 초기화

- **전역변수 선언**
1. 현재 계산된 값을 저장하는 결과값

```csharp
public static decimal calResult { get; set; } = 0;
```

1. 이퀄(=) 연산자를 2번 이상 누를 경우 계산될 베이스값 - 마지막 입력 숫자, 계산기 History에서 우측에 배치 된다.

```csharp
public static decimal fixedBaseNumber { get; set; } = 0;
```

1. 현재 입력된 사칙연산자 오퍼레이터

```csharp
public static _CalcOperator currentCalcOperator { get; set; } = _CalcOperator._none;
```

1. 바로 이전에 입력되거나 수정된 사칙 연산자 오퍼레이터

```csharp
public static _CalcOperator lastCalcOperator { get; set; } = _CalcOperator._none;
```

- **변수 초기화**

```csharp
public static void ClearCalculation()
{
	calResult = 0;
	fixedBaseNumber = 0;
	lastCalcOperator = 0;
	currentCalcOperator = 0;
}
```

### 추상 Class Method

- 상속 받아서 반드시 구현해야 하는 Method
1. 연산자만 입력한 경우 계산하는 경우

```csharp
public abstract bool Calculation();
```

1. 숫자 입력 후 연산자를 입력한 경우 계산하는 경우

```csharp
public abstract bool Calculation(decimal leftNumberA);
```

1. 숫자 -> 연산자 -> 숫자 입력 후 이퀄(=) 누를 경우 계산하는 함수

```csharp
public abstract bool Calculation(decimal leftNumberA, decimal rightNumberB);
```

 

ex) 더하기 구현

```csharp
public class Plus : Calc2NumberClass
{
   // override : 추상Class 구현하는 예약어
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
    
 //숫자 입력 후 연산자를 입력한 경우 계산하는 경우
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

   //숫자 -> 연산자 -> 숫자 입력후 이퀄(=) 누를 경우 계산하는 함수
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
```

뺄셈(-), 곱셉(*), 나눗셈(/) 이하 동일

---

## CalKeyPressProcess 클래스

계산기 key 입력 처리 Class

- 변수 3개 생성
1. 바로 전 단계 계산식 History를 표시하는 문자 Text

```csharp
string strCalHistory { get; set; } = ““;
```

1. 현재 계산된 결과 값을 표시하는 문자 Text

```csharp
string strCalResult { get; set; } = ““;
```

1. 현재 입력된 숫자 및 소수점을 표시하는 문자 Text

```csharp
string strInputNumber { get; set; } = ““;
```

### 1. C, CE 초기화를 처리하는 Method

**1-1 C : 계산기 전체 초기화 작업**

```csharp
public void ResetCalculation(Action<string, string>dispCallBack)
//dispCallBack - Deligate 인자로 선언
{
		strCalHistory = ““;
		strCalResult =”“;
		strInputNumber =”0”;
		Calc2NumberClass.ClearCalculation();

	 // 화면 정보를 Call Back 함수로 갱신한다.
		if (dispCallBack != null)
		{
				dispCallBack(strCalHistory, strInputNumber);
		}
}
```

**1-2 CE : 방금 입력한 값 초기화**

```csharp
public void ClearLastInput(Action<string, string> dispCallBack)
{
		// 방금 입력한 값을 초기화한다.
		strInputNumber = “0”;
		// 화면 정보를 Call Back 함수로 갱신한다.
		dispCallBack(strCalHistory, strInputNumber);
}
```

### 2. 숫자키 0~9, 소숫점, 백스페이스 키 입력을 처리하는 Method

**2-1 키패드 숫자 ‘0’~‘9’ 가 입력**

```csharp
public void AddNumber(string strNum, Action<string, string> dispCallBack)

{
    // 이퀄(=) 버튼이 눌린 적 있는 지 확인 (눌렸다면 새 계산을 위해 초기화)
    if(isEqualAssignTriggerdOn == true)
    {
        // 계산기를 초기화 한다(누적값, 연산자 등) - 1 cycle 계산 완료
        ResetCalculation(null);
        // 이퀄(=) 입력 체크 Flag는 초기화한다.
        isEqualAssignTriggerdOn = false;
    }

    // 계산기 초기화 이후 현재 입력 숫자가 "0"이거나, 사칙연산 버튼을 눌렸다면, 
    // strInputText에 방금 입력한 값 대입한다.

    if (strInputNumber == "0" || is4kindOperatorTriggeredOn == true)
    {
       // 현재 입력된 숫자를 입력 문자로 설정한다.
       strInputNumber = strNum;
       // 사칙 연산 버튼 눌림 여부 체크
       if(is4kindOperatorTriggeredOn == true)
       {
         // 다음 입력을 위해 연산자 입력 Flag를 꺼줌.
           is4kindOperatorTriggeredOn = false;
       }
    }
   // 그렇지 않을 경우 숫자 이어붙이기 
   else
   {
       strInputNumber += strNum;
   }
    // strCalHistroy : 지금까지 계산식, strInputNumber : 현재 입력 중인 숫자
    dispCallBack(strCalHistory, strInputNumber);
}
```

**2-2 소수점 입력**

```csharp
public void AddDot(Action<string, string> dispCallBack)
 {
     // 사칙연산자를 누른 후 소수점을 입력할 경우에는 입력 화면에 '0.' 으로 표시한다.
    if (is4kindOperatorTriggeredOn == true || isEqualAssignTriggerdOn == true)
     {
         strInputNumber = "0";
         //사칙연산자 flag가 true로 설정되어 있으면 false로 초기화한다.
         if(isEqualAssignTriggerdOn == true)
         {
             is4kindOperatorTriggeredOn = false;
         }
         // 이퀄(=) 입력 flag가 True면 초기화
         if (isEqualAssignTriggerdOn == true)
         {
         // 계산기를 초기화 한다 - 1cycle 계산완료
             ResetCalculation(null);
             isEqualAssignTriggerdOn = false;
         }
    }

     // 소수점이 이미 있으면 아무 동작도 하지 않고 종료한다.
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
```

**2-3 백스페이스키 입력**

```csharp
public void BackspaceProcess(Action<string, string> dispCallBack)
{
    // 이퀄(=) 눌러 계산이 완료된 상태일 경우, 이전 strCalHistroy를 지운다.</span>
    if (isEqualAssignTriggerdOn == true)
    {
        strCalHistory = "";
    }
    // "0" : 기본 상태, "" : 아무 숫자도 없음, 길이가 1 : 숫자 한자리 
    // ㄴ 백스페이스로지울 필요 없이 "0"으로 유지함
    if (strInputNumber == "0" || strInputNumber == "" || strInputNumber.Length == 1)
    {
        strInputNumber = "0";
    }
    else
    {
       // 입력된 숫자가 2자리 이상일 때, 맨 끝 한자리 제거
        strInputNumber = strInputNumber.Substring(0, strInputNumber.Length - 1);
    }
    dispCallBack(strCalHistory, strInputNumber);
}
```

### 3. 사칙연산 키 입력을 처리하는 Method (-, +. *, /)

**3-1 계산에 사용될 Operator를 얻어온다.**

```csharp
CalcOperator GetOperator(string strOperator) 
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
```

**3-2 현재 설정된 연산자를 화면에 표시하기 위해 문자(기호)를 얻어온다.**

```csharp
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
				case _CalcOperator._percent:
					result = "%";
					break;
		}
		return result;
}
```

**3-3 키패드에서 사칙연산자를 눌렀을 경우 호출되는 Method**

```csharp
public void CalcOperatorInput(string strCalcOperator, Action<string, string> dispCallBack)
{
		// strCalcOperator 문자열 (현재 입력된 연산자)을 내부 열거형(enum) 연산자로 변환하고
		// 계산기 Class에 설정한다.
		Calc2NumberClass.SetOperator(GetOperator(strCalcOperator));

		// 연속으로 사칙 연산자를 입력하지 않은 경우에만 계산을 진행한다.
		if (is4kindOperatorTriggeredOn == false)
		{
		    is4kindOperatorTriggeredOn = true;
		 // CalculationProcess() 호출해 이전에 입력된 숫자와 연산자를 이용해 중간 계산을 미리 수행
		    bool result = CalculationProcess();
		}
		// 이퀄(=) 입력 flag가 True면 초기화
		if (isEqualAssignTriggerdOn == true)
		{
		    isEqualAssignTriggerdOn = false;
		}
// 방금 입력한 계산식 정보를 화면 상단에 보여줄 계산 히스토리 Text로 생성
		strCalHistory = string.Format("{0} {1}", Calc2NumberClass.calResult, GetOperatorString(Calc2NumberClass.currentCalcOperator));

		// 방금 입력한 값 또는 계산 결과를 Text로 생성
		strInputNumber = Calc2NumberClass.calResult.ToString();

		// 화면정보를 Call Back 함수로 갱신한다.
		dispCallBack(strCalHistory, strInputNumber);
}
```

**3-4 사칙연산 수행**

```csharp
// 이퀄(=) 연산자가 바로 이전에 입력되었는지 체크하는 flag
bool isEqualAssignTriggerdOn { get; set; } = false;

// 사칙연산 버튼이 눌릴 때 중간 계산을 수행하는 핵심 로직
bool CalculationProcess()
{
// 방금 전에 이퀄(=) 연산자가 입력되었다면 계산이 끝난 상태이므로 해당 Flag만 해제하고
// 연산작업은 수행하지 않는다. - 부호만 바꾼다.
		if (isEqualAssignTriggerdOn == true)
		{
				isEqualAssignTriggerdOn = false;
		}

// 이전 연산자 (lastCalcOperator)가 존재하고 현재 연산자(currentCalcOperator)와 다르다면
// 이전 연산자 기준으로 먼저 계산 수행함
		else if (Calc2NumberClass.lastCalcOperator != _CalcOperator._none && Calc2NumberClass.lastCalcOperator != Calc2NumberClass.currentCalcOperator)
		{
		    Calc2NumberClass clnc = GetCalculationMethod(Calc2NumberClass.lastCalcOperator);
    // strInputNumber를 숫자로 변환 후 clnc.Calculation()을 호출해 실제 연산 수행
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
// 현재 연산자와 이전 연산자가 같거나, 이전 연산자가 _none 일 경우, 현재 연산자를 기준으로
// 연산 진행
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
```

### 4. 이퀄(=) Assign 연산자를 처리하는 Method

**4-1 이퀄(=) 연산자가 바로 이전에 입력되었는지 체크하는 flag**

```csharp
bool isEqualAssignTriggerdOn { get; set; } = false;
```

**4-2 이퀄(=) 연산자가 입력될 경우 호출되는 Method**

```csharp
public void EqualAssignOperatorInput(Action<string, string> dispCallBack)
{
		// 실제 계산 수행
	   EqualCalProcess();
		// 화면 정보를 Call Back 함수로 갱신한다.
	   dispCallBack(strCalHistory, strInputNumber);
		 isEqualAssignTriggerdOn = true;
}
```

**4-3 이퀄(=) 연산자를 처리하는 함수**

```csharp
void EqualCalProcess()
{
		// 현재 계산을 진행할 연산자에 맞는 계산 클래스 인스턴스를 가져옴
		Calc2NumberClass clnc = GetCalculationMethod(Calc2NumberClass.currentCalcOperator);

		// 연산자 클래스가 유효한지, 아무 연산자 없이 숫자만 입력된 경우인지 조건 확인
		if (clnc != null || Calc2NumberClass.currentCalcOperator == _CalcOperator._none)
		{

		// 현재 입력된 문자열 숫자 strInputNumber를 decimal로 변환
		   decimal inputnumber = 0;
		   if (decimal.TryParse(strInputNumber, out inputnumber))
		   {
   // 1. 숫자 변환이 성공 되었으면 이퀄(=) 계산을 진행한다.
   // 1-1. 계산 History 식 왼쪽에 표시될 숫자 - 현재 계산이 완료된 값 (초기에는 0)
		       decimal beforeCalcResult = Calc2NumberClass.calResult;

    // 1-2. 계산 History 식 오른쪽에 표시될 숫자 - 현재 입력한 값
		       decimal currentInputNumber = 0;

   // 이퀄(=) 연속으로 2번이상 누를 경우에는 이전 현재값에 입력된 값을 이용해서 계산한다.
		       if (isEqualAssignTriggerdOn == true)
		       {
		           currentInputNumber = Calc2NumberClass.fixedBaseNumber;
		       }
		       else
		       {

					   // 이퀄(=) 최초 1회 입력할 경우 현재 입력값으로 설정한다.
		           currentInputNumber = inputnumber;

       // 그리고 그 값을 백업한다. -> 추후에 이퀄(=) 연속으로 입력할 경우 History 계산식
       // 우측에 표기되는 값
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

           // 계산을 진행한다 : beforeCalcResult + 연산자 + currentInputNumber
           // => Calc2NumberClass.calResult 로 들어간다.
		           bool result = clnc.Calculation(beforeCalcResult, currentInputNumber);

           // 계산식 History에 표기할 문자를 만든다.
		           strCalHistory = string.Format("{0} {1} {2} =", beforeCalcResult, GetOperatorString(Calc2NumberClass.currentCalcOperator), currentInputNumber);
		       }
		       strInputNumber = Calc2NumberClass.calResult.ToString();
		   }
		}
}
```

---

## programmerCalculator Form

프로그래밍에 필요한 비트 단위 연산 위주 기능 구현

### 구현한 기능 소개

- 사칙연산
    
    기본적인 사칙연산 기능 구현
    10진수가 아닌 2진수, 8진수, 10진수 간 사칙연산 기능 구현
    
- 키보드 입력
    
    KeyDown Event Handler에서 KeyCode 열거형 조건 비교하여 키 별 기능 할당
    
- 비트 연산 및 논리 연산
    
    & (AND), | (OR), ~ (NOT), << (Shift left), >> (Shift right) 등 연산자 사용해 비트 연산 및 논리 연산 기능 구현
    
- 비트 키패드
    
    BitArray를 Button을 사용해 직접 수정해서 사용 하도록 기능 구현
    

### 설계 방법 및 사용한 기술 설명

기능별로 함수 및 Class 분리하였습니다.

- programerCalculator (프로그래머 계산기 Form)
    - Button, radioBox, textBox 같은 Control 요소들 event 처리
    - 테마 변경을 위한 함수
- ConvertBaseClass (진법 변환 Class)
    
    ```csharp
    public string ConvertBase(Base from, Base to, string inputValue)
    public string[] ConvertAllBase(Base from, string inputValue)
    ```
    
    - **ConvertBase**
        
        진법 변환을 위한 함수입니다. Base 열거형에 정수 2, 8, 10, 16을 할당 후 입력 된 String의 진법과 변환 하고자 하는 진법의 열거형을 파라메터로 입력 받아 진법을 변환합니다.
        변환 된 값은 string 자료형으로 반환됩니다.
        
    - **ConvertAllBase**
        
        입력된 string 변수의 값을 모든 진법으로 변환합니다.
        변환 된 값은 string 배열로 반환됩니다.
        
- **CalculateBitClass**
    
    ```csharp
     public string CalculateWithOperation(string str, Base @base)
     public string CalculateNotGateOoperation(string str, Base @base)
     private string[] TokenizeExpression(string str)
     public void UpdateBitArrayBtn(TabControl tabCtrl, BitArray bitArr)
     public string BitArrayToString(BitArray bitArray, Base @base)
     public BitArray KeypadValueToBitArray(TabControl tabCtrl, BitArray bitArr)
     public void PrintBitArray(BitArray bitArray)
    ```
    
    - **CalculateWithOperation**
        
        입력된 계산식을 TokenizeExpression 함수를 호출 하여 Token으로 분리 후 사칙연산 및 비트 연산 수행 후 결과를 string 자료형으로 반환하는 함수입니다.
        
    - CalculateNotGateOperation
        
        입력 된 string 값에 NOT 논리 연산 후 값을 string 자료형으로 반환하는 함수입니다.
        
    - TokenizeExpression
        
        계산식을 Token으로 분리해 string 배열로 반환하는 함수입니다.
        입력 값 : **72+39**
        출력 값 : **{”72”,”+”,”39”}**
        
    - **UpdateBitArrayBtn**
        
        BittArray 값을 받아 TabControl 내부에 존재하는 버튼의 Text를 변경하는 함수입니다.
        
    - **KeypadValueToBitArray**
        
        TabControl 내부에 존재하는 버튼들의 값을 받아 BitArray에 대입 후 반환하는 함수입니다.
        
    - **PrintBitArray**
        
        BitArray 자료형 배열의 값을 Console에 출력하는 함수입니다. 디버깅 용도로 제작되었습니다.
        

---

- **계산식 인식**
    - StringBuilder를 이용한 계산식 Tokenizer
        
        Token = 문법적으로 더 이상 나눌 수 없는 기본적인 언어 요소
        
        ```csharp
                private string[] TokenizeExpression(string str)
                {
                    StringBuilder sb = new StringBuilder();
                    List<string> tokens = new List<string>();
                    bool? prevIsDigit = null; // 이전 순회 값이 숫자인지 여부
        
                    // 1. 문자열을 한 글자씩 순회.
                    for (int i = 0; i < str.Length; i++)
                    {
                        char c = str[i];
                        bool isDigit = Char.IsDigit(c); // 2. 문자열의 n번 인덱스가 숫자인지 검사
        
        								// 이전 순회 값이 null이 아니고 n번 인덱스와 n-1번 인덱스가 서로 숫자가 아닌 경우
        								// 분리 기준 판단
                        if (prevIsDigit != null && isDigit != prevIsDigit)
                        {
                            tokens.Add(sb.ToString()); // List<string>에 토큰 저장
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
        ```
        
        - 문자열을 한 글자씩 순회.
        - 숫자(0~9)인지 여부 확인.
        - 숫자가 연속되면 하나의 숫자 문자열로 그룹화.
        - 숫자가 아닌 경우 문자(한글)를 계속 이어붙여 단어로 그룹화.
        - 숫자 그룹과 문자 그룹이 바뀔 때마다 토큰 분리.
        - 모든 순회가 끝나면 마지막 토큰 추가.
    - StringBuilder
        
        기본적으로 String 객체는 변경할 수 없습니다. 메서드 중 하나를 사용할 때마다 메모리에 새 문자열 개체가 생성됨으로 메모리 낭비가 발생됩니다.
        
        ```csharp
        // StringBuilder 객체 인스턴스 및 초기화
        StringBuilder sb = new StringBuilder();
        
        string str = "HelloHiWorld";
        
        // c변수의 값을 sb 객체에 문자열 끝에 추가할 수 있다.
        sb.Append(c);
        
        // sb 객체의 문자열에서 startIndex부터 length 만큼 문자를 제거한다
        sb.Remove(5,2);
        ```
        
    - List<>
        
        배열은 동적으로 크기 조절이 되지 않지만 List는 가능하며 배열 크기에 대해 크게 신경 쓸 필요도 없습니다.
        List는 Generic이나 구조체로 간주되며 <> 사이에 자료형을 선언해야 합니다.
        
        동적인 배열을 만드는 상황에서 사용
        
        ```csharp
        using System.Collections.Generic;
        
        // List 객체 인스턴스 및 초기화
        List<string> list = new List<string>();
        
        list.Add("사과");
        list.Add("바나나");
        list.Add("두리안");
        list.Add("복숭아");
        
        string[] result = list.ToArray();
        // result = {"사과", "바나나", "두리안", "복숭아"}
        ```
        
- **진법 변환**
    - Convert.ToInt64
        
        지정된 값을 64비트 부호 있는 정수로 변환합니다.
        
        프로그래머 계산기에서는 여러가지 수를 다양한 진법으로 변환 해야 합니다.
        핵심 기능인 비트 키패드는 64bit를 직접 수정 할 수 있는데 그렇기에 ToInt64 Method를 사용하여 최대 64bit를 변환 하도록 대응했습니다.
        
        ```csharp
        // int는 32bit가 최대임으로 64bit 자료형인 long 사용
        // 10진수 128을 string 자료형에 선언 및 정의
        string value = "128";
        
        // fromBase는 2, 8, 10, 16만 허용
        int fromBase = 2;
        
        long decimalValue = Convert.ToInt64(value, fromBase); 
        // decimalValue = 10000000
        // 2진법으로 변환 되었음
        ```
        
- **하나의 함수로  여러 버튼을 동시에 활성화, 비활성화**
    - foreach
        
        ```csharp
          // 이벤트 발생시 Tag에 따라 버튼을 활성/비활성화 하는 Fucntion
          private void ChangeButtonStatus(string @base, int pageNum)
          {
              foreach (Control ctrl in KeypadTabControl.TabPages[pageNum].Controls)
              // KeypadTabControl 객체에 n번 탭 페이지의 모든 컨트롤을 foreach
              {
                  if (ctrl is Button btn)
                  // Button 속성의 컨트롤이며
                  {
                      if (btn.Tag == null)
                      // Tag가 없다면
                      {
                          // 무조건 Enable 한다
                          btn.Enabled = true;
                          continue;
                      }
                      // 버튼의 태그를 string으로 변환하고 ","를 기준으로 나눔. 
                      string[] validBases = btn.Tag?.ToString().Split(',') ?? Array.Empty<string>();
                      btn.Enabled = validBases.Contains(@base);
                  }
              }
          }
        ```
        
        프로그래머 계산기 form에는 TabPages 컨트롤에 버튼들이 들어가 있습니다.
        
        인터넷 브라우저의 탭 기능처럼 인터넷 브라우저 탭처럼 버튼이나 라디오 버튼과 같은 객체를 탭에 넣어 전환 할 수 있습니다.
        
        해당 코드는 TabPages 내부에 들어가 있는 버튼들의 속성을 가져와 조건 비교 후 버튼을 활성화, 비활성화 하는 코드입니다.
        
        비단 TabPage 뿐만 아니라 group이나 form 내부의 객체를 하나씩 가져와서 속성을 가져오거나 수정할때에도 foreach문을 사용해 기능을 구현했습니다.
        

---

## 📝 느낀 점과 아쉬웠던 점

### 👩‍💻 남주현

- 클래스, 각 기능을 구현하는 함수 등 코드가 복잡해지면서 변수 구분이 어려웠기 때문에 어디서 왔는지 바로 파악할 수 있는 변수명을 작성해야 함을 깨달았습니다.

### 🧑‍💻 이정훈

- 기능 테스트 하면서 예외 처리의 중요성에 대해 뼈저리게 느끼게 된 계기였습니다.
특히 진법 변환 부분에서 OverflowException이나 FormatException 같은 오류에 잘 대응해서 단순히 예외 처리 뿐만이 아니라 예외 발생 후 처리 하는 방법도 공부해야겠다 생각이 들었습니다.
- 조건문을 너무 남발한 나머지 조건 분기가 너무 많아져 디버깅하거나 코드를 수정 할 때 힘들었습니다. 코딩에 정답이 없다지만 알고리즘 공부를 열심히 해서 조건문을 줄여 가독성 좋은 코드를 짜야겠습니다.
- 객체지향 언어에 익숙하지 않은 나머지 절차지향 언어와 비슷하게 로직을 구현했던것 같습니다.
객체지향 언어의 장점인 상속이나 오버라이드같은 개념을 살리지 못해 아쉬웠습니다.
프로젝트가 끝나면 객체지향의 개념에 대해 진도를 나갈텐데 열심히 공부해야겠습니다.
