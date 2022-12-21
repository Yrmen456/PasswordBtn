using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static Form1 standart;
        public static Working_with_subscribers working_with_subscribers;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyApplicationContext context = new MyApplicationContext();
            context.Open(new Form2());
            Application.Run(context);
          

        }
        public static int formCount;
        public class MyApplicationContext : ApplicationContext
        {
            public void Open(Form form)
            {
                
                form.Closed += OnFormClosed;
                formCount++;
                form.Show();
       
            }

            private void OnFormClosed(object sender, EventArgs e)
            {

                formCount--;
           
                if (formCount <= 0 )
                {
                    Application.Exit();
                }
            }
        }
    }
}
