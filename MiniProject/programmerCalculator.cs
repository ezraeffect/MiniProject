using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MiniProject
{
    public enum Type : int // 자료형별 bit를 지정합니다.
    {
        BYTE = 8,   // 8bit (1 byte)
        WORD = 16,  // 16bit (2 byte)
        DWORD = 32, // 32bit (4 byte)
        QWORD = 64  // 64bit (8 byte)
    }

    public partial class programmerCalculator : Form
    {
        KeyboardInputHandler keyHandler = new KeyboardInputHandler();
        DataTable data = new DataTable();

        public static Base SelectedBase = Base.DEC;
        public static Type SelectedType = Type.DWORD;

        public static BitArray bitArray = new BitArray(64, false);

        public programmerCalculator()
        {
            InitializeComponent();

            // 버튼 초기 설정
            ChangeButtonStatus("DEC", 0);
            ChangeButtonStatus("QWORD", 1);
        }

        private void programmerCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            string keyString = keyHandler.GetBaseKeyString(e, SelectedBase);

            switch (keyString)
            {
                case "=":
                    try
                    {
                        // TODO
                        // 진법 계산 고려하여 분기문 수정
                        var result = data.Compute(textBox_result.Text, null);
                        textBox_result.Text = result.ToString();
                    }
                    catch (SyntaxErrorException)
                    {
                        textBox_result.Text = $"식이나 구문에 오류가 있습니다.";
                        break;
                    }
                    break;

                case "BS":

                    if (textBox_result.Text.Length > 1)
                    {
                        textBox_result.Text = textBox_result.Text.Substring(0, textBox_result.Text.Length - 1);
                    }
                    else if (textBox_result.Text.Length == 1)
                    {
                        // 1의 자리 수 일때 아예 지워지지 않도록 처리
                        textBox_result.Text = "0";
                    }
                    break;

                default:
                    if (textBox_result.Text == "0") textBox_result.Text = keyString;
                    else textBox_result.AppendText(keyString);
                    break;
            }
        }

        // 진법 변환 radioButton을 눌렀을때 발생하는 이벤트 처리
        private void BaseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            string tagString;
            // radioButton의 모든 이벤트에 대해 가져오므로 체크 되었을때 동작 수행 하도록
            if (rb.Checked)
            {
                // 체크 된 radioButton의 tag를 가져와 string으로 변환
                tagString = rb.Tag?.ToString();
                // tag에 해당하는 button을 활성화/비활성화
                ChangeButtonStatus(rb.Tag?.ToString(), 0);
                // 체크된 radioButton의 Status 저장
                SelectedBase = (Base)Enum.Parse(typeof(Base), rb.Tag?.ToString(), true);

                // 진법 변환
                switch (SelectedBase)
                {
                    case Base.BIN:
                        textBox_result.Text = textBox_BIN.Text; break;
                    case Base.OCT:
                        textBox_result.Text = textBox_OCT.Text; break;
                    case Base.HEX:
                        textBox_result.Text = textBox_HEX.Text; break;
                    case Base.DEC:
                        textBox_result.Text = textBox_DEC.Text; break;
                }

                // 만약에 체크박스가 바뀌는 이벤트가 발생하면.
                // A : 바뀌기 이전의 가장 최근의 Base
                // B : 이벤트 발생 이후의 Base
                // A에서 B로 진수 변환 후 Result TextBox에 대입

            }
        }

        // 자료형 변환 radioButton을 눌렀을때 발생하는 이벤트 처리
        private void TypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            string tagString;
            // radioButton의 모든 이벤트에 대해 가져오므로 체크 되었을때 동작 수행 하도록
            if (rb.Checked)
            {
                // 체크 된 radioButton의 tag를 가져와 string으로 변환
                tagString = rb.Tag?.ToString();
                // tag에 해당하는 button을 활성화/비활성화
                ChangeButtonStatus(rb.Tag?.ToString(), 1);
                // 체크된 radioButton의 Status 저장
                SelectedType = (Type)Enum.Parse(typeof(Type), rb.Tag?.ToString(), true);
            }
        }

        // 비트 키패드의 비트별 button을 눌렀을때 발생하는 이벤트 처리
        private void BitButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string btnName = btn.Name.ToString(); // 클릭된 버튼의 Name 속성을 string으로 변환
            string btnNum = new string(btn.Name.Where(char.IsDigit).ToArray()); // string에서 정수만 취한 후 저장
            int bitIndex = int.Parse(btnNum); // string을 int로 parse

            switch (btn.Text)
            {
                case "0":
                    btn.Text = "1";
                    bitArray[bitIndex] = true;
                    break;
                case "1":
                    btn.Text = "0";
                    bitArray[bitIndex] = false;
                    break;
            }

            UpdateBitArrayForBtn();
            textBox_result.Text = BitArr2String(bitArray, SelectedBase);
        }

        private void OperationButton_Clicked(object sender, EventArgs e)
        {
            // 1. 부호 버튼을 누르면 textBox_result + "부호"를 textBox_view에 넣는다
            Button btn = sender as Button;
            if (textBox_result.Text != "0" || textBox_result.Text != "")
            {
                textBox_view.Text = textBox_result.Text + btn.Text;

                // 2. equal 버튼 누르기 전까지 사칙연산 button, 진수변환 radioButton 비활성화
                ChangeOperationButtonStatus(false);

                // 3. textBox_result 텍스트 초기화
                textBox_result.Clear();
                textBox_result.Text = "0";
            }
        }

        private void BaseButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string tag = btn.Tag?.ToString();
            if (tag.Contains("HEX"))
            {
                if (textBox_result.Text == "0") textBox_result.Text = btn.Text;
                else textBox_result.AppendText(btn.Text);
            }
        }

        private void EqualButton_Clicked(object sender, EventArgs e)
        {
            CalculateBitClass calBit = new CalculateBitClass();
            if (!string.IsNullOrEmpty(textBox_result.Text) && textBox_result.Text != "0")
            {
                textBox_view.AppendText(textBox_result.Text);
                textBox_result.Text = calBit.CalculateWithOperation(textBox_view.Text, SelectedBase);

                ChangeOperationButtonStatus(true);
            }
        }

        // 폼에서 우클릭 눌렀을때 발생하는 이벤트 처리
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                styleMenuStrip.Show(this, e.Location);
            }
        }

        // 비트 키패드의 현재 값을 bitArray에 적용하는 Function
        // 비트 키패드 -> bitArray
        private void UpdateBitArrayForBtn()
        {
            foreach (Control ctrl in KeypadTabControl.TabPages[1].Controls)
            {
                if (ctrl is Button btn)
                {
                    string btnName = btn.Name.ToString(); // 클릭된 버튼의 Name 속성을 string으로 변환
                    string btnNum = new string(btn.Name.Where(char.IsDigit).ToArray()); // string에서 정수만 취한 후 저장
                    int bitIndex = int.Parse(btnNum); // string을 int로 parse

                    switch (btn.Text)
                    {
                        case "0":
                            bitArray[bitIndex] = false;
                            break;
                        case "1":
                            bitArray[bitIndex] = true;
                            break;
                    }
                }
            }
        }
        // BitArray를 String으로 변환하는 Function
        private string BitArr2String(BitArray bitArray, Base @base)
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

        private void ChangeOperationButtonStatus(bool status)
        {
            radioButton_BIN.Enabled = status;
            radioButton_OCT.Enabled = status;
            radioButton_DEC.Enabled = status;
            radioButton_HEX.Enabled = status;

            button_plus.Enabled = status;
            button_minus.Enabled = status;
            button_mul.Enabled = status;
            button_div.Enabled = status;

            button_leftShift.Enabled = status;
            button_rightShift.Enabled = status;

            button_AND.Enabled = status;
            button_OR.Enabled = status;
            button_NOT.Enabled = status;
            button_NAND.Enabled = status;
            button_XOR.Enabled = status;
            button_NOR.Enabled = status;

            button_remainder.Enabled = status;
        }

        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {
            ConvertBaseClass cb = new ConvertBaseClass();

            string[] convertedArray = cb.ConvertAllBase(SelectedBase, textBox_result.Text);

            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    int tagNum = int.Parse((string)txt.Tag);
                    txt.Text = convertedArray[tagNum];
                }
            }

            /* 1. 텍스트 박스가 변경되면
             * 2. 각진법에 알맞게 변환이 된다
             * 3. string의 n번째 값을 n번째 버튼의 Text로 변경
             * 3-1. string의 n번째 값을 bitArray의 n번에 저장
             * 단, 4비트라 가정했을때 string[0]은 4번 비트를 나타낸다
             * string을 반대로 뒤집으면?
             */
            string convertedBIN = convertedArray[3]; // 2진법으로 변환 된 값의 String
            string reversedBIN = new string(convertedBIN.Reverse().ToArray()); // String을 반대로 뒤집어 bitIndex와 stringIndex를 맞춘다
            int len = convertedBIN.Length;
            foreach (Control ctrl in KeypadTabControl.TabPages[1].Controls)
            {
                if (ctrl is Button btn)
                {
                    string btnNum = new string(btn.Name.Where(char.IsDigit).ToArray()); // string에서 정수만 취한 후 저장
                    int bitIndex = int.Parse(btnNum); // string을 int로 parse

                    if (bitIndex < len) // 배열 범위 이내라면 값 복사
                    {
                        btn.Text = reversedBIN[bitIndex].ToString();
                        bitArray[bitIndex] = reversedBIN[bitIndex] == '0' ? false : true;

                    }
                    else // 배열 범위 밖이라면 무조건 0으로 처리
                    {
                        btn.Text = "0";
                        bitArray[bitIndex] = false;
                    }
                }
            }
        }

        private void button_BS_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text.Length > 1)
            {
                textBox_result.Text = textBox_result.Text.Substring(0, textBox_result.Text.Length - 1);
            }
            else if (textBox_result.Text.Length == 1)
            {
                // 1의 자리 수 일때 아예 지워지지 않도록 처리
                textBox_result.Text = "0";
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_view.Clear();
            textBox_result.Clear();
            textBox_result.Text = "0";
            ChangeOperationButtonStatus(true);
        }
    }
}
