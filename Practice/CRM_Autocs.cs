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
    public partial class CRM_Autocs : UserControl
    {
        public CRM_Autocs()
        {
            InitializeComponent();
           
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Program.working_with_subscribers.Dostyp_Panel_Controler.Controls[0].Show();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Program.working_with_subscribers.Dostyp_Panel1_Controler.Controls["ActionsPost_Button_4"].Enabled = false;

            //telefon.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] stolb = new string[] { "Abonents_id", "telephone", "email", "Abonents_personal_account", "fio", "Equipment_id", "Equipment_name", "type_name", "type_id" };
            string[] data_user = SQL.user_data($@"Select Abonents.id as 'Abonents_id', Abonents.telephone, Abonents.email, 
            Abonents.personal_account as 'Abonents_personal_account', Abonents.fio,
            Equipment.id as 'Equipment_id' ,Equipment.name as 'Equipment_name' , TypesEquipment.type_name as 'type_name' , Equipment.id_type as 'type_id'
            from Contracts, Abonents ,	Equipment ,TypesEquipment
            where Contracts.id_abonent = Abonents.id and Equipment.id = Contracts.serial_number_equipment
            and Equipment.id_type = TypesEquipment.id and telephone = N'{telefon.Text}' and fio like N'{fio.Text}%' ", stolb);



            if (data_user.Length <= 0)
            {
                return;
            }
            if (fio.Text == data_user[4].Split(new char[] { ' ' })[0] && telefon.Text == data_user[1])
            {

               
                CRM_Add CRM_add = new CRM_Add(data_user[0], data_user[1], data_user[2], data_user[3], data_user[4], data_user[5], data_user[6], data_user[7], data_user[8]);
                CRM_add.Name = "abonent_CRM_control";

        
                this.Dispose();

                Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Add(CRM_add);
            }
        }
    }
}
