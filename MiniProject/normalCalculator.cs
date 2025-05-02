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
            Console.WriteLine("Init Component");
            this.KeyDown += new KeyEventHandler(normalCalculator_KeyDown);

        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            var result = data.Compute(textBox_view.Text, null);
            textBox_result.Text = result.ToString();
        }

        private void normalCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine($"KeyCode: {e.KeyCode}, KeyData: {e.KeyData}, KeyValue: {e.KeyValue}");
            string tempString;
            tempString = keyHandler.GetKeyString(e);
            Console.WriteLine(tempString);
            
        }
    }
}
