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
    public partial class CRM_Add : UserControl
    {
        string Abonents_id; 
        string telephone; 
        string email; 
        string Abonents_personal_account;
        string fio;
        string aboryd_id; string aboryd_name; string aboryd_type; string aboryd_type_id;
        public CRM_Add( string Abonents_id, string telephone, string email, string Abonents_personal_account, string fio, string aboryd_id, string aboryd_name, string aboryd_type, string aboryd_type_id)
        {
            InitializeComponent();


            this.Abonents_id = Abonents_id;
            this.telephone = telephone;
            this.email = email;
            this.Abonents_personal_account = Abonents_personal_account;
            this.fio = fio;
            this.aboryd_id = aboryd_id;
            this.aboryd_name = aboryd_name;
            this.aboryd_type = aboryd_type;
            this.aboryd_type_id = aboryd_type_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string god = dt.Year.ToString();
            string moth = dt.Month.ToString();
            string day = dt.Day.ToString();
            Random random = new Random();
            string otv = SQL.Zapros($@"Insert Requests(id,date_create, id_abonent, id_service, id_kind_service, id_type_service, id_status, id_type_equipment, description_problem, id_problem) 
            values('{Abonents_personal_account}/{day}/{moth}/{god}/{random.Next(1,1000)}',
            '{DateTime.Now.ToString("dd-MM-yyyy")}','{Abonents_id}',
            '{ysl.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[comboBox1.SelectedIndex]}',
            '{vid.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[comboBox2.SelectedIndex]}',
            '{type.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[comboBox3.SelectedIndex]}',
            '1', '{aboryd_type_id}', '{textBox1.Text}', '{type_prob.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[comboBox4.SelectedIndex]}'
            )");
            if (otv == "true"){
                MessageBox.Show("Успех");
            }
            else
            {
                MessageBox.Show(""+ otv);
            }

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Program.working_with_subscribers.Dostyp_Panel_Controler.Controls[0].Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Info_abonent info_Abonent = new Info_abonent(Abonents_id,1);
            this.Hide();
            info_Abonent.Dock = DockStyle.Fill;
            Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Add(info_Abonent);
     
        }
        DataTable ysl;
        DataTable vid;
        DataTable type;
        DataTable type_prob;
        private void CRM_Add_Load(object sender, EventArgs e)
        {
            number.Text += Abonents_id;
            ab_fio.Text += fio;
            pers_ac.Text += "\n"+Abonents_personal_account;
            serial_num.Text += aboryd_id;
            type_ob.Text += aboryd_type;
            name_ob.Text +="\n" + aboryd_name;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ysl = SQL.table("Select * from Services").Tables[0];
            type_prob = SQL.table("Select * from TypesProblem").Tables[0];
            comboBox1.DataSource = ysl.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DrawItem += comboBox1_DrawItem;
            comboBox1.DropDownClosed += comboBox1_DropDownClosed;
            comboBox4.DataSource = type_prob.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            comboBox2.Enabled = true;
            vid = SQL.table("Select * from KindsService").Tables[0];
            comboBox2.DataSource = vid.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox2.DrawItem += comboBox2_DrawItem;
            comboBox2.DropDownClosed += comboBox2_DropDownClosed;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;

            type = SQL.table($"Select * from  TypesService , KindsService  where KindsService.id = TypesService.id_kind and id_kind = {vid.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[comboBox2.SelectedIndex]}").Tables[0];
            //MessageBox.Show("" + vid.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray()[comboBox2.SelectedIndex]);
            comboBox3.DataSource = type.Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray();
            comboBox3.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox3.DrawItem += comboBox3_DrawItem;
            comboBox3.DropDownClosed += comboBox3_DropDownClosed;
          
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            toolTip1.Hide(comboBox1);
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = comboBox1.GetItemText(comboBox1.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip1.Show(text, comboBox1, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();

        }
       

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            toolTip2.Hide(comboBox2);
        }

        
        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = comboBox2.GetItemText(comboBox2.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip2.Show(text, comboBox2, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            toolTip3.Hide(comboBox3);
        }

        private void comboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = comboBox3.GetItemText(comboBox3.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip3.Show(text, comboBox3, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }
    }
}
