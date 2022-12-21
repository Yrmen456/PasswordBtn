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
    public partial class Abonent_THC : UserControl
    {
        public Abonent_THC()
        {
            InitializeComponent();
            radioButton3.Checked = true;
            this.Focus();
            sor_text.LostFocus += new EventHandler(sor_text_LostFocus);
            sort_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        }
        DataSet Adress;
        DataSet Table;
        string yslovie;
        private void sor_text_LostFocus(object sender, System.EventArgs e)
        {
            if (sort_name.SelectedIndex == 2)
            {
                Adress = SQL.table($@"select DISTINCT   Cities.prefix, Cities.raion, Cities.house  from Cities, Abonents where  Cities.id  = Abonents.live_address  and prefix  = N'{sor_text.Text}'  ");
                String[] home = Adress.Tables[0].Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray();
                sort_home.DataSource = home;
                sort_home.Text = "";
            }
           
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
       
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string where = "";
            if (radioButton.Tag.ToString() != "0")
            {
                where = "";
            }
            
            if (radioButton.Checked)
            {
                //Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Clear();

                Table = SQL.table($@"Select Abonents.id as 'Номер абонента ',fio as 'ФИО', 
                Contracts.id as 'Номер договора с абонентом',personal_account as 'Лицевой счет',
                service_name as 'Услуги'
                from Abonents, Contracts, Services , Cities
                where {yslovie}
                reason_termination_contract is  null 
                and Abonents.id = Contracts.id_abonent
                and Cities.id  = Abonents.live_address
                and Services.id = Contracts.services");
                dataGridView1.DataSource = Table.Tables[0];
                //Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Add(info_Abonent);
                yslovie2 = "reason_termination_contract is  null and";
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                //Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Clear();
   
                Table = SQL.table($@"Select Abonents.id as 'Номер абонента ',fio as 'ФИО', 
                Contracts.id as 'Номер договора с абонентом',personal_account as 'Лицевой счет',
                service_name as 'Услуги'
                from Abonents, Contracts, Services , Cities
                where {yslovie} 
                reason_termination_contract is not null 
                and Abonents.id = Contracts.id_abonent
                and Cities.id  = Abonents.live_address
                and Services.id = Contracts.services");
                dataGridView1.DataSource = Table.Tables[0];
                //Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Add(info_Abonent);
                yslovie2 = "reason_termination_contract is not null and ";
            }

        }
    
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {

           
                Table = SQL.table($@"Select Abonents.id as 'Номер абонента ',fio as 'ФИО', 
                Contracts.id as 'Номер договора с абонентом',personal_account as 'Лицевой счет',
                service_name as 'Услуги'
                from Abonents, Contracts, Services , Cities
                where {yslovie} 
                Abonents.id = Contracts.id_abonent
                and Cities.id  = Abonents.live_address
                and Services.id = Contracts.services");
                dataGridView1.DataSource = Table.Tables[0];
                dataGridView1.Columns[0].ReadOnly = true;
                yslovie2 = null;

            }
        }
        string yslovie2;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            DataTable Data_Table = Table.Tables[0];
            if (e.RowIndex >= 0)
            {
                MessageBox.Show("" + Data_Table.Rows[e.RowIndex][0].ToString());
                Info_abonent info_Abonent = new Info_abonent(Data_Table.Rows[e.RowIndex][0].ToString(), 0);
                //Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Clear();

                this.Hide();
                info_Abonent.Dock = DockStyle.Fill;
                Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Add(info_Abonent);
               
            }
          


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sor_text_TextChanged(object sender, EventArgs e)
        {

        }
        string[] tb = new string[] { "fio", "raion","prefix", "house" }; 
        private void button1_Click(object sender, EventArgs e)
        {
            yslovie = null;
            Table = SQL.table($@"Select Abonents.id as 'Номер абонента ',fio as 'ФИО', 
                Contracts.id as 'Номер договора с абонентом',personal_account as 'Лицевой счет',
                service_name as 'Услуги'
                from Abonents, Contracts, Services , Cities
                where {yslovie} {yslovie2}
                Abonents.id = Contracts.id_abonent
                and Cities.id  = Abonents.live_address
                and Services.id = Contracts.services");
            dataGridView1.DataSource = Table.Tables[0];
            dataGridView1.Columns[0].ReadOnly = true;
        }

        private void sort_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sort_name.SelectedIndex == 2)
            {
                sort_home.Visible = true;
            }
            else
            {

                sort_home.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sort_name.SelectedIndex == 0)
            {

                yslovie = $"fio like N'%{sor_text.Text}%' and";



            }
            else
        if (sort_name.SelectedIndex == 1)
            {

                yslovie = $" raion like N'%{sor_text.Text}%' and";



            }
            else
        if (sort_name.SelectedIndex == 3)
            {

                yslovie = $" Abonents.personal_account = N'{sor_text.Text}' and";



            }
            else
        if (sort_name.SelectedIndex == 2)
            {
                if (sort_home == null || sort_home.Text == " " || sort_home.Text == "")
                {
                    yslovie = $" prefix = N'{sor_text.Text}'  and ";
                }
                else
                {
                    yslovie = $" prefix = N'{sor_text.Text}' and house = N'{sort_home.Text}' and ";
                }




            }

            Table = SQL.table($@"Select Abonents.id as 'Номер абонента ',fio as 'ФИО', 
                Contracts.id as 'Номер договора с абонентом',personal_account as 'Лицевой счет',
                service_name as 'Услуги'
                from Abonents, Contracts, Services , Cities
                where {yslovie} {yslovie2}
                Abonents.id = Contracts.id_abonent
                and Cities.id  = Abonents.live_address
                and Services.id = Contracts.services");
            dataGridView1.DataSource = Table.Tables[0];
            dataGridView1.Columns[0].ReadOnly = true;
        }

        private void Abonent_THC_Load(object sender, EventArgs e)
        {

        }
    }
}
