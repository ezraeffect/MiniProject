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
        public normalCalculator()
        {
            InitializeComponent();
            Console.WriteLine("Init Component");

        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            var result = data.Compute(textBox_view.Text, null);
            textBox_result.Text = result.ToString();
        }

        private void normalCalculator_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Console.WriteLine(e.KeyData);
        }
    }
}
