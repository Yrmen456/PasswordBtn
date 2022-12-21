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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            
            Program.standart = this;
            MaximizeBox = false;
            Controls.Remove(this);
            this.Controls.Clear();
            Authorization f = new Authorization();
            this.ClientSize = new System.Drawing.Size(f.Width, f.Height);
            f.TopLevel = false;
            f.Show();
            f.TopLevel = false;
            f.SuspendLayout();
            this.Controls.Add(f);
            this.Text = f.Text;
   
        }

        private void control_form1_Load(object sender, EventArgs e)
        {
           
            
    
        }
    }
}
