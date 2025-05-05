using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MiniProject.KeyboardInputHandler;

namespace MiniProject
{
    public partial class programmerCalculator : Form
    {
        KeyboardInputHandler keyHandler = new KeyboardInputHandler();

        public static KeyboardInputHandler.Base SelectedBase = KeyboardInputHandler.Base.DEC;

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
            textBox1.AppendText(keyString);
        }

        // 진법 변환 radioButton을 눌렀을때 발생하는 이벤트 처리
        private void BaseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            string tagString;
            // radioButton의 모든 이벤트에 대해 가져오므로 체크 되었을때 동작 수행 하도록
            if (rb.Checked)
            {
                tagString = rb.Tag?.ToString();
                ChangeButtonStatus(rb.Tag?.ToString());
                SelectedBase = (Base)Enum.Parse(typeof(Base), rb.Tag?.ToString(), true);
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
