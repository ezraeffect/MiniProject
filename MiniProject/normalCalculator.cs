using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniProject
{
    public partial class normalCalculator : Form
    {

        DataTable data = new DataTable();
        KeyboardInputHandler keyHandler = new KeyboardInputHandler();
        

        public normalCalculator()
        {
            InitializeComponent();
            // 키보드 입력 이벤트 핸들러
            this.KeyDown += new KeyEventHandler(normalCalculator_KeyDown);

        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            var result = data.Compute(textBox_view.Text, null);
            textBox_result.Text = result.ToString();
        }

        private void normalCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            string keyString = keyHandler.GetKeyString(e);

            switch (keyString)
            {
                case "=":
                    try
                    {
                        var result = data.Compute(textBox_view.Text, null);
                        textBox_result.Text = result.ToString();
                    }
                    catch(SyntaxErrorException)
                    {
                        textBox_result.Text = $"식이나 구문에 오류가 있습니다.";
                        break;
                    }
                    break;

                case "BS":
                    if (textBox_view.Text.Length > 0)
                    {
                        textBox_view.Text = textBox_view.Text.Substring(0, textBox_view.Text.Length - 1);
                    }
                    break;

                default:
                    textBox_view.AppendText(keyString);
                    break;
            }
        }

        private void button_writeNum_Click(object sender, EventArgs e)
        {
            string buttonText = ((System.Windows.Forms.Button)sender).Text;
            int num;
            if (int.TryParse(buttonText, out num))
            {
                textBox_view.AppendText(buttonText);
            }
        }
    }
}
