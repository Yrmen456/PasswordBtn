using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace Practice
{
    class SQL
    {
        public static string Conect()
        {
            //AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)))));

            //DESKTOP-IBAEO8B\SQLEXPRESS
            //PK312-8
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="Z:\ИС-19\hahaha\УП 04\Сегодя\Form_yp_04\Form_yp_04\Database1.mdf";Integrated Security=True
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="Z:\ИС-19\hahaha\УП 04\Сегодя\Form_yp_04\Form_yp_04\Database1.mdf";Integrated Security=True
            //string link = @"..\..\";
            string startupPath = Environment.CurrentDirectory;
            //return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='Z:\ИС-19\hahaha\УП 04\Сегодя\Form_yp_04\Form_yp_04\Database1.mdf';Integrated Security=True";
            //return @"Data Source=10.0.10.250\SQLEXPRESS;Initial Catalog=assets;Integrated Security=True";  
            //ВСТРОЕННАЯ
            //return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={startupPath}\db\Practice_db.mdf;Integrated Security=True;Connect Timeout=30";
            //ТЕХ
            //return @"Data Source=DESKTOP-77HU0K3;Initial Catalog=Practice;Integrated Security=True";  
            //ДОМ
            return @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Practice;Integrated Security=True";  
        }
        public static string id_personal = "";
        public static List<string> spisok(string table, string stolb)
        {
            List<string> kol = new List<string>();
            SqlConnection ThisConnection = new SqlConnection(SQL.Conect());
            ThisConnection.Open();
            SqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = $"select {stolb} as 'n' from {table}";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {

                kol.Add("" + thisReader["n"]);
            }
            thisReader.Close();
            ThisConnection.Close();

            return kol;
        }
        public static string[] massiv(string table, string stolb)
        {
            List<string> kol = new List<string>();
            SqlConnection ThisConnection = new SqlConnection(SQL.Conect());
            ThisConnection.Open();
            SqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = $"select {stolb} as 'n' from {table}";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {

                kol.Add("" + thisReader["n"]);
            }
            thisReader.Close();
            ThisConnection.Close();
            string[] arr = new string[kol.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = kol[i];
            }
            return arr;
        }

        public static string[] massiv_full(string zapros, string tabale)
        {
            List<string> kol = new List<string>();
            SqlConnection ThisConnection = new SqlConnection(SQL.Conect());
            ThisConnection.Open();
            SqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = $"{zapros}";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {

                kol.Add("" + thisReader[$"n"]);
            }
            thisReader.Close();
            ThisConnection.Close();
            string[] arr = new string[kol.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = kol[i];
            }
            return arr;
        }

        public static string Zapros(string zapros)
        {

            try
            {
                SqlConnection ThisConnection = new SqlConnection(SQL.Conect());

                String query;
                SqlConnection con;
                SqlCommand cmd;
                SqlDataAdapter a;
                DataSet ds;
                query = zapros;
                con = new SqlConnection(SQL.Conect());
                cmd = new SqlCommand(query, con);
                con.Open();
                a = new SqlDataAdapter(query, con);
                ds = new DataSet();
                a.Fill(ds);
                return "true";

            }
            catch (InvalidCastException e)
            {
                return ""+e;
            }



        }
        public static int Cheknumarr(string[] list, string num)
        {
            int resylt = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == num)
                {
                    resylt = i;
                }
            }

            return resylt + 1;
        }
        public static DataSet table(string zapros)
        {
            SqlConnection ThisConnection = new SqlConnection(SQL.Conect());

            String query;
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter a;
            DataSet ds;
            query = zapros;
            con = new SqlConnection(SQL.Conect());
            cmd = new SqlCommand(query, con);
            con.Open();
            a = new SqlDataAdapter(query, con);
            ds = new DataSet();
            a.Fill(ds);
            return ds;

        }

        public static string zapros2(string zapros)
        {
            SqlConnection ThisConnection = new SqlConnection(SQL.Conect());
            ThisConnection.Open();
            SqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = $"{zapros}";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            string dostyp = "0";

            while (thisReader.Read())
            {

                dostyp = "1";
            }
            thisReader.Close();
            ThisConnection.Close();
            return dostyp;

        }

        public static string[] user_data(string zapros, string[] stolb )
        {
            string[] arr;
            List<string> kol = new List<string>();
            SqlConnection ThisConnection = new SqlConnection(SQL.Conect());
            ThisConnection.Open();
            SqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = $"{zapros}";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            

            while (thisReader.Read())
            {
                for (int i = 0; i < stolb.Length; i++)
                {
                    kol.Add("" + thisReader[$"{stolb[i]}"]);
                }    
                
            }
            arr = kol.ToArray();
            thisReader.Close();
            ThisConnection.Close();
            return arr;

        }

    }
}
