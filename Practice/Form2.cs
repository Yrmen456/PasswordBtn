using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[,] arr = new string[,] { { "name", "Yrmen45" }, { "password", "Yrmen45" }, { "password2", "Yrmen45" } };
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                MessageBox.Show(""+arr[i,0]+" "+arr[i,1]);
            }
           
        }
    }
}
