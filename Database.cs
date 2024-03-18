using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_REHENIYA
{
    internal class Database
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False");
        public static string type;

        public void openConnection()
        {
            try
            {

                con.Open();


            }
            catch (SqlException ex)
            {
                // Обработка исключения при подключении к базе данных
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Обработка других исключений
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            void openConnection()

            {
                throw new NotImplementedException();
            }
        }

        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {

                con.Close();
            }
        }

        public SqlConnection getConnection()
        {

            return con;
        }
    }
}
