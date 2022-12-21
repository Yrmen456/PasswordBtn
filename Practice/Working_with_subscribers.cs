using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Practice
{
    public partial class Working_with_subscribers : Form
    {
        public Working_with_subscribers()
        {
            InitializeComponent();

            Program.working_with_subscribers = this;

        }

        public  void LogPlainEvent(object sender, EventArgs e)
        {
            object name = (sender as Button).Tag;
            MessageBox.Show("" + name.ToString());

        }

        public void ActionsPost_Button_2_Click(object sender, EventArgs e)
        {
            object name = (sender as Button).Tag;
      
            Panel_Controler.Controls.Clear();
            Abonent_THC abonent_THC = new Abonent_THC();
            abonent_THC.Name = "abonent_THC_control";
            Panel_Controler.Controls.Add(abonent_THC);
            panel1.Controls["ActionsPost_Button_2"].Enabled = false;

            panel1.Controls["ActionsPost_Button_4"].Enabled = true;
        }
        public void ActionsPost_Button_4_Click(object sender, EventArgs e)
        {
            object name = (sender as Button).Tag;
       
            Panel_Controler.Controls.Clear();
            CRM CRM_ = new CRM();
            CRM_.Name = "abonent_CRM_control";

            CRM_.Dock = DockStyle.Fill;
            Panel_Controler.Controls.Add(CRM_);
            panel1.Controls["ActionsPost_Button_4"].Enabled = false;
            panel1.Controls["ActionsPost_Button_2"].Enabled = true;

        }
        public static void eror(object sender, EventArgs e)
        {
            object name = (sender as Button).Tag;
            MessageBox.Show("Юра наговнокодил");

        }

        private void Working_with_subscribers_MouseEnter(object sender, EventArgs e)
        {
            //forma_panel.Focus();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
       

        private void label4_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs) e;
            if (me.Button == MouseButtons.Right)
            {
                int CursorX = Cursor.Position.X;
                int CursorY = Cursor.Position.Y;
                Panel_menu loginForm = new Panel_menu();
                loginForm.StartPosition = FormStartPosition.CenterParent;
                Panel_menu panel_menu = new Panel_menu();
                Button exit = new Button();
                exit.Text = "exit";
                Button[] buttons = new Button[] { exit  };
                Form form = this;
                new Panel_menu(Cursor.Position, buttons, form).Show();
                Program.MyApplicationContext myApplicationContext = new Program.MyApplicationContext();
                //myApplicationContext.Open(new test());
                
            }
        }

       
        private int location = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (location - 20 > 0)
            {
                location -= 20;
                panel2.VerticalScroll.Value = location;
            }
            else
            {
                // If scroll position is below 0 set the position to 0 (MIN)
                location = 0;
                panel2.AutoScrollPosition = new Point(0, location);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (location + 20 < panel2.VerticalScroll.Maximum)
            //{
            //    location += 20;
            //    panel2.VerticalScroll.Value = location;
            //}
            //else
            //{
            //    // If scroll position is above 280 set the position to 280 (MAX)
            //    location = panel2.VerticalScroll.Maximum;
            //    panel2.AutoScrollPosition = new Point(0, location);
            //}
        }

        private void Working_with_subscribers_Shown(object sender, EventArgs e)
        {
            //int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            //int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            //Program.standart.Location = new Point((ScreenWidth / 2) - (this.Width / 2),
            //(ScreenHeight / 2) - (this.Height / 2));
        }




       

        private void Working_with_subscribers_Load(object sender, EventArgs e)
        {
            Panel_Controler.Focus();
            //
          
            label4.Text = $"{User.Surname_User} {User.Name_User[0]}. {User.Patronymic_User[0]}.";

            DataSet ActionsPost = SQL.table($" Select Actions.id, Actions.name  from   Post , ActionsPost, Actions  where   ActionsPost.post = Post.id and Actions.id = ActionsPost.actions  and Post.id = {User.Id_post_User}  order by  id");

            String[] ActionsPost_id = ActionsPost.Tables[0].Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
            String[] ActionsPost_name = ActionsPost.Tables[0].Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();



            for (int i = 0; i < ActionsPost_id.Length; i++)
            {
                Button button = new Button();
                button.Name = $"ActionsPost_Button_{ActionsPost_id[i]}";
                button.Text = $"{ActionsPost_name[i]}";
                int newSize = 8;
                button.Height = 50;
                button.Font = new Font(button.Font.FontFamily, newSize);
                button.BackColor = Color.LightGray;
                button.Dock = DockStyle.Top;
                if (int.Parse(ActionsPost_id[i]) == 2)
                {
                    button.Click += ActionsPost_Button_2_Click;
                }
                else if (int.Parse(ActionsPost_id[i]) == 4)
                {
                    button.Click += ActionsPost_Button_4_Click;
                }
                else
                {
                    button.Click += eror;
                }


                button.Tag = ActionsPost_id[i];
                button.Left = 100;
                //чтобы избежать мерцания "замораживаем" панель на время добавления контрола
                panel1.SuspendLayout();
                panel1.Controls.Add(button);
                //перемещаем последний добавленный элемент в начало списка контролов
                panel1.Controls.SetChildIndex(button, 0);

                //"размораживаем" панель
                panel1.ResumeLayout();
            }
            //
    
            DataSet PostEvents = SQL.table($"Select * from Events , Post , PostEvents  where PostEvents.id_post = Post.id and PostEvents.id_events = Events.id  and date_time >= '{DateTime.Now.ToString("yyyy-MM-dd")}'  and Post.id = {User.Id_post_User} order by  date_time");
            //DataSet PostEvents = SQL.table($"Select * from Events , Post , PostEvents  where PostEvents.id_post = Post.id and PostEvents.id_events = Events.id  and Post.id = {User.Id_post_User} order by  date_time");
            String[] Post_Events = PostEvents.Tables[0].Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
            String[] Post_Events_date = PostEvents.Tables[0].Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray();



            for (int i = 0; i < Post_Events.Length; i++)
            {
                Button button = new Button();
                button.Name = $"{Post_Events[i]}";
                DateTime dt = Convert.ToDateTime(Post_Events_date[i]);
                string z = "в " + dt.ToString("HH:mm") == "00:00" ? (dt.ToString("HH:mm")) : ("");
                button.Text = $"{Post_Events[i]} {dt.ToString("dd:MM:yyyy")} {z}";
                int newSize = 10;
                button.Height = 60;
                button.Font = new Font(button.Font.FontFamily, newSize);
                button.BackColor = Color.LightGray;
                button.Dock = DockStyle.Top;
                button.Click += LogPlainEvent;
                button.Tag = Post_Events[i];
                button.Left = 100;
                //чтобы избежать мерцания "замораживаем" панель на время добавления контрола
                panel2.SuspendLayout();
                panel2.Controls.Add(button);
                //перемещаем последний добавленный элемент в начало списка контролов
                panel2.Controls.SetChildIndex(button, 0);

                //"размораживаем" панель
                panel2.ResumeLayout();
            }
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = false;
            panel1.VerticalScroll.Maximum = 0;
            panel1.AutoScroll = true;
            panel2.HorizontalScroll.Maximum = 0;
            panel2.AutoScroll = false;
            panel2.VerticalScroll.Maximum = 0;
            panel2.AutoScroll = true;
            try
            {
                ovalPictureBox1.Image = Image.FromFile("photo\\" + User.Photo_User + ".png");
            }
            catch
            {
                ovalPictureBox1.Image = Image.FromFile("photo\\" + User.Photo_User + ".jpg");
            }
            Panel_Controler.Controls.Clear();
            Abonent_THC abonent_THC = new Abonent_THC();
            abonent_THC.Name = "abonent_THC_control";
            Panel_Controler.Controls.Add(abonent_THC);
            panel1.Controls["ActionsPost_Button_2"].Enabled = false;
        }
        public Panel Dostyp_Panel_Controler
        {
            get { return Panel_Controler; }
            set { Panel_Controler = value; }
        }
        public Panel Dostyp_Panel1_Controler    
        {
            get { return panel1; }
            set { panel1 = value; }
        }
        private void Working_with_subscribers_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    class OvalPictureBox : PictureBox
    {
        public OvalPictureBox()
        {
            this.BackColor = Color.DarkGray;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }
    }
}
