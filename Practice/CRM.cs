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
    public partial class CRM : UserControl
    {
        public CRM()
        {
            InitializeComponent();//
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRM_Autocs CRM_autocs = new CRM_Autocs();
            CRM_autocs.Name = "abonent_CRM_control";

            CRM_autocs.Location = new Point(150, 150);
            this.Hide();

            Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Add(CRM_autocs);
        }

        private void CRM_Load(object sender, EventArgs e)
        {
            radioButton4.Checked = true;
            
        }
        DataSet Table;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {



                metod(" and Requests.id_status = 1");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {



                metod(" and Requests.id_status = 2");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {


                metod(" and Requests.id_status = 3");

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {


                //Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Clear();

                //Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Add(info_Abonent);
                metod("");


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                metod(" and Requests.id_status = 1");

            }
            if (radioButton2.Checked == true)
            {
                metod(" and Requests.id_status = 2");
            }
            if (radioButton3.Checked == true)
            {
                metod(" and Requests.id_status = 3");
            }
            if (radioButton4.Checked == true)
            {
                metod("");
            }
        }
        void metod(string ysl)
        {

            Table = SQL.table($@"
                Select Requests.id as 'Requests.id', Requests.date_create as 'Requests.date_create', 
                Requests.id_abonent as 'Requests.id_abonent', Services.service_name as 'Services.service_name',
                KindsService.kind_name as 'KindsService.kind_name', TypesService.type_name as 'TypesService.type_name',
                StutusRequests.status_name as 'StutusRequests.status_name'
                from Requests, Services, KindsService, TypesService, StutusRequests

                where Requests.id_service = Services.id
                and Requests.id_kind_service = KindsService.id
                and Requests.id_type_service = TypesService.id
                and Requests.id_status = StutusRequests.id
                {ysl}    
                ");
            dataGridView1.DataSource = Table.Tables[0];
        }
    }
}
