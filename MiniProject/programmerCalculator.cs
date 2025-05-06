using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MiniProject.KeyboardInputHandler;

namespace MiniProject
{
    /*  TODO
     *  1. 실시간 진법 변환
     *  2. 비트시프트
     *  3. 비트연산 (AND, OR, NOT, NAND, NOR, XOR)
     *  4. byte, WORD, DWORD, QWORD
     * 
     * 
     * 
     * 
     * 
     */
    public partial class programmerCalculator : Form
    {
        KeyboardInputHandler keyHandler = new KeyboardInputHandler();

        DataTable data = new DataTable();

        public static KeyboardInputHandler.Base SelectedBase = KeyboardInputHandler.Base.DEC;
        public static KeyboardInputHandler.Base CurrentBase;

        public programmerCalculator()
        {
            InitializeComponent();
            // 키보드 입력 이벤트 핸들러
            this.KeyDown += new KeyEventHandler(programmerCalculator_KeyDown);
            // radioButton 값 초기 설정
            radioButton_HEX.Checked = false;
            radioButton_DEC.Checked = true;
            radioButton_OCT.Checked = false;
            radioButton_BIN.Checked = false;

            radioButton_HEX.CheckedChanged += new EventHandler(BaseRadioButton_CheckedChanged);
            radioButton_DEC.CheckedChanged += new EventHandler(BaseRadioButton_CheckedChanged);
            radioButton_OCT.CheckedChanged += new EventHandler(BaseRadioButton_CheckedChanged);
            radioButton_BIN.CheckedChanged += new EventHandler(BaseRadioButton_CheckedChanged);
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
                    if (textBox_result.Text.Length > 0)
                    {
                        textBox_result.Text = textBox_result.Text.Substring(0, textBox_result.Text.Length - 1);
                    }
                    break;

                default:
                    textBox_result.AppendText(keyString);
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
                ChangeButtonStatus(rb.Tag?.ToString());
                // 체크된 radioButton의 Status 저장
                SelectedBase = (Base)Enum.Parse(typeof(Base), rb.Tag?.ToString(), true);

                // 진법 변환


            }
        }

        // 이벤트 발생시 진법에 따라 버튼을 활성/비활성화 하는 Fucntion
        private void ChangeButtonStatus(string @base)
        {
            foreach (Control ctrl in KeypadTabControl.TabPages[0].Controls)
            // KeypadTabControl 객체에 0번 탭 페이지의 모든 컨트롤을 foreach
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
    }
}
