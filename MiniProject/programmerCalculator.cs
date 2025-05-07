using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

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

            // Button 상태 초기 설정
            ChangeButtonStatus("DEC", 0);
            ChangeButtonStatus("QWORD", 1);
        }

        // 키보드 입력 이벤트 처리
        private void programmerCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            string keyString = keyHandler.GetBaseKeyString(e, SelectedBase);

            switch (keyString)
            {
                case "=":
                    CalculateBitClass calBit = new CalculateBitClass();
                    if (!string.IsNullOrEmpty(textBox_result.Text) && textBox_result.Text != "0")
                    {
                        textBox_view.AppendText(textBox_result.Text);
                        textBox_result.Text = calBit.CalculateWithOperation(textBox_view.Text, SelectedBase);

                        ChangeOperationButtonStatus(true);
                    }
                    break;

                case "+":
                case "-":
                case "*":
                case "/":
                    // 1. 부호 버튼을 누르면 textBox_result + "부호"를 textBox_view에 넣는다
                    if (textBox_result.Text != "0" || textBox_result.Text != "")
                    {
                        textBox_view.Text = textBox_result.Text + keyString;

                        // 2. equal 버튼 누르기 전까지 사칙연산 button, 진수변환 radioButton 비활성화
                        ChangeOperationButtonStatus(false);

                        // 3. textBox_result 텍스트 초기화
                        textBox_result.Clear();
                        textBox_result.Text = "0";
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

                case null:
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
            }
        }

        // 자료형 변환 radioButton을 눌렀을때 발생하는 이벤트 처리
        private void TypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            CalculateBitClass cb = new CalculateBitClass();

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

                // 변환된 자료형의 최대 비트수 보다 이상의 비트는 전부 false 처리
                for (int i = (int)SelectedType; i <= 63; i++)
                {
                    bitArray.Set(i, false);
                }

                cb.UpdateBitArrayBtn(KeypadTabControl, bitArray); // bitArray의 값을 Button에 적용
                string convertedBIN = cb.BitArrayToString(bitArray, SelectedBase); // 2진법으로 변환 된 값의 String
                bitArray = cb.KeypadValueToBitArray(KeypadTabControl, bitArray);
                textBox_result.Text = convertedBIN;
            }
        }

        // 비트 키패드의 비트별 button을 눌렀을때 발생하는 이벤트 처리
        private void BitButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CalculateBitClass cb = new CalculateBitClass();

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

            bitArray = cb.KeypadValueToBitArray(KeypadTabControl, bitArray);
            textBox_result.Text = cb.BitArrayToString(bitArray, SelectedBase);
        }

        // 연산 버튼 이벤트 처리
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

        // 숫자 입력 버튼 이벤트 처리
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

        // Equal 버튼 클릭 이벤트 처리
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

        // NOT Gate 연반 버튼 클릭 이벤트 처리
        private void NOTButton_Clicked(object sender, EventArgs e)
        {
            CalculateBitClass calBit = new CalculateBitClass();

            textBox_view.Clear();
            textBox_view.AppendText($"NOT({textBox_result.Text})");

            string result = calBit.CalculateNotGateOoperation(textBox_result.Text, SelectedBase);
            textBox_result.Clear();
            textBox_result.AppendText(result);
        }

        // 폼에서 우클릭 눌렀을때 발생하는 이벤트 처리
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                styleMenuStrip.Show(this, e.Location);
            }
        }

        // 일반 계산기 클릭 이벤트 처리
        private void SwitchFormEvent(object sender, EventArgs e)
        {
            normalCalculator normal = new normalCalculator();
            this.Hide();
            normal.ShowDialog();
            this.Close();
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

        // 연산 관련 버튼 상태 변경 Function
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

        // ResultTextBox 이벤트 처리
        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {
            ConvertBaseClass cb = new ConvertBaseClass();
            CalculateBitClass cBit = new CalculateBitClass();
            string[] convertedArray = cb.ConvertAllBase(SelectedBase, textBox_result.Text);

            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    int tagNum = int.Parse((string)txt.Tag);
                    txt.Text = convertedArray[tagNum];
                }
            }

            //cBit.UpdateBitArrayBtn(KeypadTabControl, bitArray, SelectedBase);
        }

        // Backspace 버튼 이벤트 처리
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

        // Clear Entry 버튼 이벤트 처리
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_view.Clear();
            textBox_result.Clear();
            textBox_result.Text = "0";
            ChangeOperationButtonStatus(true);
        }

        // 부호 변환 버튼 이벤트 처리
        private void button_toggleSign_Click(object sender, EventArgs e)
        {
            // 만약 textbox_result의 0번째 인덱스가 -라면
            if (textBox_result.Text[0] == '-')
            {
                // 제거한다
                textBox_result.Text =  textBox_result.Text.Remove(0, 1);
            }
            // 만약 textbox_result의 0번째 인덱스가 숫자라면
            else if (char.IsDigit(textBox_result.Text[0]))
            {
                // 0번 인덱스에 -를 삽입한다
                textBox_result.Text = textBox_result.Text.Insert(0, "-");
            }
       }

        // Form 색상 변경 이벤트 처리
        private void ChangeStyleItem_Click(object sender, EventArgs e)
        {
            Color cBackground = Color.Transparent;
            Color cFont = Color.Black;
            Color cButton = Color.Transparent;
            Color cHighlight = Color.Gray;

            if (sender is ToolStripMenuItem item)
            {
                switch (item.Name)
                {
                    case "lightStyleItem":
                        cBackground = System.Drawing.SystemColors.Control;
                        cFont = Color.Black;
                        cButton = System.Drawing.Color.Transparent;
                        cHighlight = System.Drawing.Color.Transparent;
                        break;
                    case "darkStyleItem":
                        cBackground = ColorTranslator.FromHtml("#1e1e1e");
                        cFont = ColorTranslator.FromHtml("#cccccc");
                        cButton = ColorTranslator.FromHtml("#373737");
                        cHighlight = ColorTranslator.FromHtml("#320064");
                        break;
                    case "pantonStyleItem":
                        cBackground = ColorTranslator.FromHtml("#E4C7B7");
                        cFont = ColorTranslator.FromHtml("#56443F");
                        cButton = ColorTranslator.FromHtml("#F1F0E2");
                        cHighlight = ColorTranslator.FromHtml("#A47864");
                        break;
                    case "jhStyleItem":
                        cBackground = ColorTranslator.FromHtml("#FBC1AE");
                        cFont = ColorTranslator.FromHtml("#495F77");
                        cButton = ColorTranslator.FromHtml("#F7E1C5");
                        cHighlight = ColorTranslator.FromHtml("#BBCBD2");
                        break;

                }
            }
            ApplyColors(this, cBackground, cFont, cButton, cHighlight);
        }

        // Form 내부의 모든 객체의 색상을 변경
        void ApplyColors(Control control, Color backColor, Color foreColor, Color btnColor, Color highlightColor)
        {
            control.BackColor = backColor;
            control.ForeColor = foreColor;
            if (control is Button)
                if (control.Name == "button_equal") // Equal 버튼만 하이라이트 색상으로 변경
                    control.BackColor = highlightColor;
                else control.BackColor = btnColor;
            
            foreach (Control child in control.Controls)
            {
                ApplyColors(child, backColor, foreColor,btnColor, highlightColor);
            }
        }
    }
}
