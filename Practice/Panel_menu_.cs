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
    public partial class Panel_menu_ : UserControl
    {
        public Panel_menu_()
        {
            InitializeComponent();
     
            //StartPosition = FormStartPosition.Manual;
            this.ClientSize = new System.Drawing.Size(this.Width, 0);
        }
        public Panel_menu_(Point newLocation, Button[] button_arr, Form Form_panel)
        : this()
        {

            string[] arr = new string[] { "num1", "num2", "num3", "num3", "num3", "num1", "num2", "num3", "num3", "num3" };

            for (int i = 0; i < button_arr.Length; i++)
            {

                button_arr[i].Name = $"Button_panel{i}";

                int newSize = 10;
                button_arr[i].Height = 30;
                button_arr[i].Font = new Font(button_arr[i].Font.FontFamily, newSize);
                button_arr[i].BackColor = Color.LightGray;
                button_arr[i].Dock = DockStyle.Top;
                Working_with_subscribers panel_Menu = new Working_with_subscribers();
                button_arr[i].Click += exit;
                button_arr[i].Tag = i;
                button_arr[i].Left = 100;
                //чтобы избежать мерцания "замораживаем" панель на время добавления контрола
                this.SuspendLayout();
                this.Controls.Add(button_arr[i]);
                //перемещаем последний добавленный элемент в начало списка контролов
                this.Controls.SetChildIndex(button_arr[i], 0);

                //"размораживаем" панель
                this.ResumeLayout();
            }

            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;



            //MessageBox.Show($"{newLocation} \n {area.Width} {area.Height}");
            Location = newLocation;
        }
        private void Form2_Deactivate(object sender, EventArgs e)
        {
            //this.Close();
        }

        public void exit(object sender, EventArgs e)
        {
            //this.Close();
            Controls.Remove(Program.standart);
            Program.standart.Controls.Clear();
            Authorization f = new Authorization();
            Program.standart.ClientSize = new System.Drawing.Size(f.Width, f.Height);
            f.TopLevel = false;
            f.Show();
            f.TopLevel = false;
            f.SuspendLayout();
            Program.standart.Controls.Add(f);
            Program.standart.Text = f.Text;


        }
    }
}
