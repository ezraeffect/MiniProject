using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class normalCalculator : Form
    {

        DataTable data = new DataTable();
        KeyboardInputHandler keyHandler = new KeyboardInputHandler();
        public normalCalculator()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(normalCalculator_KeyDown);

        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            var result = data.Compute(textBox_view.Text, null);
            textBox_result.Text = result.ToString();
        }

        private void normalCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            /*string keyString;
            int number;
            keyString = keyHandler.GetKeyString(e);

            if (int.TryParse(keyString, out number))
            {
                Console.WriteLine(number.ToString());
            }   
            else
            {
                Console.WriteLine("너는 아무거나 입력했을거시여");
            }*/

            textBox_view.AppendText(keyHandler.GetKeyString(e));
        }
    }
}
