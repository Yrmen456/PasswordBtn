using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Mail;

namespace Practice
{
    public partial class Authorization : System.Windows.Forms.Form
    {
        public Authorization()
        {
            InitializeComponent();
   
        }
      
        private void mail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
             
           
                if(SQL.zapros2($"Select * from Users where email = '{mail.Text}'") == "1")
                {
                    MessageBox.Show("Введите пароль");
                    pass.ReadOnly = false;
                    pass.Focus();
                }
            }
        }

        private void mail_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // Program.control_forma.Controls.Clear();
           

            mail.Text = "";
            pass.ReadOnly = true;
            pass.Text = "";
            code.ReadOnly = true;
            code.Text = "";
            recode.Enabled = false;
            timer1.Stop();
            lbl_recode.Visible = false;
            lbl_timer.Visible = false;
            btn_accept.Enabled = false;

        }
        Random rnd = new Random();

        int code_num = 0;
        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                if (SQL.zapros2($"Select * from Users where email = '{mail.Text}' and password = '{pass.Text}'") == "1")
                {
                    MessageBox.Show("Введите код");
                    mail.ReadOnly = false;
                    code_num = rnd.Next(1000000, 9999999);
                    code.Focus();
                    code.ReadOnly = false;
                    lbl_recode.Text = "Код доступа " + code_num;
                    lbl_recode.Visible = true;
                    lbl_timer.Visible = true;
  
                    timer1.Start();
                    code.Text = "" + code_num;
                }
            }
        }
        int timer = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            if (timer / 10 < 10)
            {

                lbl_timer.Text = "00:0" + (timer/10).ToString();
            }
            else
            {
                lbl_timer.Text = "00:" + (timer / 10).ToString();
            }
        

            if (timer == 300)
            {
            

                timer = 0;

                code.Text = null;


                pass.ReadOnly = false;
                code.ReadOnly = true;
                recode.Enabled = true;

                lbl_recode.Visible = false;
                lbl_timer.Visible = false;
                pass.Focus();
                timer1.Stop();
                MessageBox.Show("Время для ввода кода истекло! Обновите код");
                
            }
        }

        private void code_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {


                if (code_num.ToString() == code.Text)
                {
                    MessageBox.Show("Код введен верно");
                    code.ReadOnly = false;
   
                    timer = 0;
                    recode.Enabled = false;
                    timer1.Stop();
                
                    btn_accept.Enabled = true;
                    btn_accept.Focus();
                }
            }
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {

            timer1.Stop();
           
            if (SQL.zapros2($"Select * from Users where email = '{mail.Text}' and password = '{pass.Text}'") == "1")
            {
                Controls.Remove(this);

                string[] stolb = new string[] { "email", "password", "name_access", "post","id", "surname", "name", "patronymic", "photo" }; 
                string[] data_user = SQL.user_data($"Select Users.email, Users.password, Access.name_access, Post.post, Post.id,  Users.name, Users.surname, Users.patronymic, Users.photo  from Users, Post, Access WHERE Users.access = Access.id and Users.post = Post.id and Users.email = '{mail.Text}' and Users.password = '{pass.Text}'", stolb);
                
                User User = new User();
                User.Email_User = data_user[0];
                User.Password_User = data_user[1];
                User.Id_post_User = int.Parse(data_user[4]);
                User.Post_User = data_user[3];
                User.Surname_User = data_user[5];
                User.Name_User = data_user[6];
                User.Patronymic_User = data_user[7];

                User.Photo_User = data_user[8];
                MessageBox.Show($"{data_user[2]}\n {User.Post_User}");
                Program.standart.Controls.Clear();
                Working_with_subscribers f = new Working_with_subscribers();
                Program.standart.ClientSize = new System.Drawing.Size(f.Width, f.Height);
                f.TopLevel = false;
                f.Show();
                f.TopLevel = false;
                f.SuspendLayout();
                Program.standart.Controls.Add(f);
                Program.standart.Text = f.Text;

             
            }


        }

        private void recode_Click(object sender, EventArgs e)
        {


            timer1.Stop();
            MessageBox.Show("Введите код");
            recode.Enabled = true;

            code_num = rnd.Next(1000000, 9999999);
            code.Focus();
            code.ReadOnly = false;
            lbl_recode.Text = "Код доступа " + code_num;
            lbl_recode.Visible = true;
            lbl_timer.Visible = true;

            timer1.Start();

        }

        private void Authorization_Load(object sender, EventArgs e)
        {


           
        }

        private void Authorization_Shown(object sender, EventArgs e)
        {
            

        }

        private void Authorization_Activated(object sender, EventArgs e)
        {
       
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
