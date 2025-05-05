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
    public partial class programmerCalculator : Form
    {
        KeyboardInputHandler keyHandler = new KeyboardInputHandler();
        public programmerCalculator()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(programmerCalculator_KeyDown);
        }

        private void programmerCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            KeyboardInputHandler.Base value = KeyboardInputHandler.Base.BIN;
            string keyString = keyHandler.GetBaseKeyString(e, value);
            Console.WriteLine(keyString);
        }
    }
}
