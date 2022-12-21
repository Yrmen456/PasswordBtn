using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Practice
{
    public partial class Info_abonent : UserControl
    {
        public string id_abonent;
        public int okno;
        public Info_abonent(string id_abonent, int okno)
        {
            InitializeComponent();
            this.BringToFront();
            this.okno = okno;
            this.id_abonent = id_abonent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Program.working_with_subscribers.Dostyp_Panel_Controler.Controls.Count.ToString());
            this.Dispose();
            Program.working_with_subscribers.Dostyp_Panel_Controler.Controls[okno].Show();
        }
        string  serial_number_equipment ;
        private void Info_abonent_Load(object sender, EventArgs e)
        {
            DataSet Abonents = SQL.table($@" Select Abonents.id as 'Номер_абонента', Abonents.fio as 'ФИО' , Abonents.series_number_passport as 'Серия паспорта', Abonents.series_number_passport as 'Номер паспорта', 
            Abonents.date_issued_passport as 'Дата_выдачи', Abonents.residence_address as 'Кем_выдан', 
            Contracts.id as 'Номер_договора_с_абонентом' ,
            Contracts.contract_conclude as 'Дата_заключения_договора', TypesOfContract.type_name as 'Тип_договора',
            date_termination_contract as 'Дата_расторжения_договора',
            reason_termination_contract as 'Причина_расторжения_договора', Abonents.personal_account as 'Лицевой_счет', 
            Cities.prefix + ' ' + Cities.house as 'Адресс' , Services.service_name as 'Услуги', serial_number_equipment
            from Abonents, Contracts, Services , Genders , Cities, TypesOfContract
                where 
                Abonents.id = Contracts.id_abonent
                and Services.id = Contracts.services
				and Genders.id = Abonents.gender
				and Cities.id  = Abonents.live_address
				and Contracts.type_contract = TypesOfContract.id
                and Abonents.id = N'{id_abonent}' ");
            button1.Focus();
            print_label("Labels_4", 14, 30, $"Информация об абоненте {id_abonent}", 100);
            string[] label_text = new string[] { "Номер абонента", "ФИО", "Серия паспорта", "Номер паспорта", "Дата выдачи", "Кем выдан", "Номер договора с абонентом", "Дата заключения договора", "Тип договора", "Дата расторжения договора", "Причина расторжения договора", "Лицевой счет", "Адрес", "Перечень подключенных услуг" };
            var stringArr = Abonents.Tables[0].Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
            var stringArr2 = Abonents.Tables[0].Rows[0].ItemArray.ToArray();
            //string[] arr = Abonents.Tables[0].Rows[0].ItemArray.;
            for (int i = 0; i < stringArr.Length; i++)
            {
                if (i==14)
                {
                    serial_number_equipment = stringArr[i];
                    
                }else
                if (stringArr2[i] != System.DBNull.Value)
                {
                    Label button = new Label();
                    button.Name = $"label_{i}";
                    if (i == 2) { button.Text = $"{label_text[i]}: {stringArr[i].Split(new char[] { ' ' })[0] }"; }
                    else if (i == 3) { button.Text = $"{label_text[i]}: {stringArr[i].Split(new char[] { ' ' })[1]}"; }
                    else if (i == 13) { button.Text = $"{label_text[i]}: {stringArr[i].Replace(" ", ", ")}"; }
                    else { button.Text = $"{label_text[i]}: {stringArr[i]}"; }




                    int newSize = 10;
                    button.Height = 25;
                    button.Font = new Font(button.Font.FontFamily, newSize);

                    button.Dock = DockStyle.Top;


                    button.Tag = label_text[i];
                    button.Left = 100;
                    //чтобы избежать мерцания "замораживаем" панель на время добавления контрола
                    panel_info.SuspendLayout();
                    panel_info.Controls.Add(button);
                    //panel_info последний добавленный элемент в начало списка контролов
                    panel_info.Controls.SetChildIndex(button, 0);

                    //"размораживаем" панель
                    panel_info.ResumeLayout();
                }
              
            }
            print_label("Labels_1", 14, 30, "Данные об оборудовании абонента:", 100);
            print_label("Labels_2", 10, 25, $"Серийный номер {serial_number_equipment}", 100);
            print_label("Labels_3",10,25, "История обращений в техническую поддержку ", 100);
            panel_info.SuspendLayout();
            DataGridView dataGridView_tex = new DataGridView();

            dataGridView_tex.MinimumSize = new System.Drawing.Size(200, 10);
            dataGridView_tex.MaximumSize = new System.Drawing.Size(200, 200);
            dataGridView_tex.Dock = DockStyle.Top;
            panel_info.Controls.Add(dataGridView_tex); 
            dataGridView_tex.DataSource = SQL.table($@"Select distinct Requests.date_create as 'Дата' , problem_name as 'Проблема'  from Requests, TypesProblem, Contracts
                where Requests.id_problem = TypesProblem.id and Requests.id_abonent = Contracts.id_abonent and serial_number_equipment = N'{serial_number_equipment}'").Tables[0];
            //panel_info последний добавленный элемент в начало списка контролов
            
            panel_info.Controls.SetChildIndex(dataGridView_tex, 0);
            dataGridView_tex.AllowUserToAddRows = false;
            dataGridView_tex.RowHeadersVisible = false;
            dataGridView_tex.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //"размораживаем" панель
            panel_info.ResumeLayout();


            panel_info.HorizontalScroll.Maximum = 0;
            panel_info.AutoScroll = false;
            panel_info.VerticalScroll.Maximum = 0;
            panel_info.AutoScroll = true;
        }
        void print_label(string name, int size , int height, string text, int left)
        {
            Label button1 = new Label();
            button1.Name = name;
            int newSize2 = size;
            button1.Height = height;
            button1.Font = new Font(button1.Font.FontFamily, newSize2);
            button1.Dock = DockStyle.Top;
            button1.Text = text;
            button1.Left = left;
            panel_info.SuspendLayout();
            panel_info.Controls.Add(button1);
            //panel_info последний добавленный элемент в начало списка контролов
            panel_info.Controls.SetChildIndex(button1, 0);

            //"размораживаем" панель
            panel_info.ResumeLayout();
        }
    }
}
