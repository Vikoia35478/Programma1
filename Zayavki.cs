using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_REHENIYA
{
    public partial class Zayavki : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False");
        System.Data.DataTable dt;
        SqlDataAdapter adapter;
        string Id;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private string dataToPrint;


        private object senderBtn;
        private System.Drawing.Color color;


        public Zayavki()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
  (
      int nLeftRect,     // x-coordinate of upper-left corner
      int nTopRect,      // y-coordinate of upper-left corner
      int nRightRect,    // x-coordinate of lower-right corner
      int nBottomRect,   // y-coordinate of lower-right corner
      int nWidthEllipse, // height of ellipse
      int nHeightEllipse // width of ellipse
  );














        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel2.Parent.BackColor);
            System.Windows.Forms.Control control = panel2;
            int radius = 30;
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddLine(radius, 0, control.Width - radius, 0);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddLine(control.Width, radius, control.Width, control.Height - radius);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddLine(control.Width - radius, control.Height, radius, control.Height);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.AddLine(0, control.Height - radius, 0, radius);
                path.AddArc(0, 0, radius, radius, 180, 90);
                using (SolidBrush brush = new SolidBrush(control.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel1.Parent.BackColor);
            System.Windows.Forms.Control control = panel1;
            int radius = 30;
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddLine(radius, 0, control.Width - radius, 0);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddLine(control.Width, radius, control.Width, control.Height - radius);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddLine(control.Width - radius, control.Height, radius, control.Height);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.AddLine(0, control.Height - radius, 0, radius);
                path.AddArc(0, 0, radius, radius, 180, 90);
                using (SolidBrush brush = new SolidBrush(control.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel3.Parent.BackColor);
            System.Windows.Forms.Control control = panel3;
            int radius = 30;
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddLine(radius, 0, control.Width - radius, 0);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddLine(control.Width, radius, control.Width, control.Height - radius);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddLine(control.Width - radius, control.Height, radius, control.Height);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.AddLine(0, control.Height - radius, 0, radius);
                path.AddArc(0, 0, radius, radius, 180, 90);
                using (SolidBrush brush = new SolidBrush(control.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private void Zayavki_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void авторизацияToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Main_form main_Form = new Main_form();
                main_Form.Show();

            }
            else
            {
                return;
            }
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            method_set();
        }

        public void method_set()
        {

            Random random = new Random();

            // Генерация случайного числа из 10 цифр
            int randomNumber = random.Next(1000, 9999); // Генерируем число в диапазоне от 100000000 до 999999999

            if (textBox1.Text == textBox1.Text)
            {





                SqlConnection con = new SqlConnection(@"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False");
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand($"INSERT INTO Заявки([ID_Заявки],[ID_Исполнителя],[Исполнитель],[ФИО_Клиента],[Номер_телефона],[Тип_оборудования ],[Серийный_номер],[Описание_проблемы],[Дата] ,[Статус_заявки])  Values (@ID_Заявки,@ID_Исполнителя,@Исполнитель,@ФИО_Клиента,@Номер_телефона,@Тип_оборудования,@Серийный_номер,@Описание_проблемы,@Дата,@Статус_заявки) ", con);
               
                SqlCommand cmd;
                SqlDataReader dr;
                SqlConnection cn;

                string time = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                string status = "Принято в работу";

                Random random_1 = new Random();
                string name ="";

                // Генерируем случайное число от 1 до 4
                int randomNumber_1 = random.Next(1, 5);
                string id = Convert.ToString(randomNumber_1);
               
                switch (randomNumber_1)
                {
                    case 1:
                        name = "Дмитрий Козинцев";
                        break;
                    case 2:
                        name = "Никита Фёдоров";
                        break;
                    case 3:
                        name = "Алексей Древесников";
                        break;
                    case 4:
                        name = "Владимир Лукин";
                        break;
                                   

                }





                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
    string.IsNullOrWhiteSpace(textBox2.Text) ||
    string.IsNullOrWhiteSpace(textBox3.Text) ||
    string.IsNullOrWhiteSpace(textBox4.Text) ||
    string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("Заполните все поля !!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else {
                    cmd = new SqlCommand("select * from Заявки where [ФИО_Клиента] = '" + textBox1.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        dr.Close();
                        MessageBox.Show("Такой запрос  существует!!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;

                    }
                    else
                    {
                        dr.Close();
                        command.Parameters.AddWithValue("@ФИО_Клиента", textBox1.Text);
                        command.Parameters.AddWithValue("@Номер_телефона", textBox2.Text);
                        command.Parameters.AddWithValue("@Тип_оборудования", textBox3.Text);
                        command.Parameters.AddWithValue("@Серийный_номер", textBox4.Text);
                        command.Parameters.AddWithValue("@Описание_проблемы", textBox5.Text);
                        command.Parameters.AddWithValue("@Дата", time);
                        command.Parameters.AddWithValue("@Статус_заявки", status);
                        command.Parameters.AddWithValue("@ID_Исполнителя", id);
                        command.Parameters.AddWithValue("@ID_Заявки", randomNumber);
                        command.Parameters.AddWithValue("@Исполнитель", name);


                        command.ExecuteNonQuery();

                        MessageBox.Show("Информация успешно добавлена!!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                        Main_form main = new Main_form();
                        main.Show();




                    }


                    string sourceConnectionString = @"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False";
                    string destinationConnectionString = @"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False";
                    string query = "INSERT INTO     Отчёты  (ID_Заявки, ID_Исполнителя,Исполнитель, Неисправность,Дата) SELECT ID_Заявки, ID_Исполнителя,Исполнитель, Описание_проблемы ,Дата  FROM Заявки WHERE ID_Заявки = '" + randomNumber+"'";
                    try
                    {
                        using (SqlConnection sourceConnection = new SqlConnection(sourceConnectionString))
                        using (SqlConnection destinationConnection = new SqlConnection(destinationConnectionString))
                        {
                            SqlCommand command_ = new SqlCommand(query, destinationConnection);

                            sourceConnection.Open();
                            destinationConnection.Open();

                            // Выполнение запроса
                            command_.ExecuteNonQuery();

                      
                        }
                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show("Ошибка","Ошибка переноса",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    string sourceConnectioN= @"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False";
                    string destinationConnectioN = @"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False";
                    string query_ = "INSERT INTO   Клиентская_база (ID_Заявки, ФИО_Клиента,Номер_телефона) SELECT ID_Заявки, ФИО_Клиента,Номер_телефона FROM  Заявки   WHERE ID_Заявки = '" + randomNumber + "'";
                    try
                    {
                        using (SqlConnection source = new SqlConnection(sourceConnectioN))
                        using (SqlConnection destination = new SqlConnection(destinationConnectioN))
                        {
                            SqlCommand command_ = new SqlCommand(query_, destination);

                            source.Open();
                            destination.Open();

                            // Выполнение запроса
                            command_.ExecuteNonQuery();


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка", "Ошибка переноса", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }





                }

            } 
        }

       







        private void label7_Click(object sender, EventArgs e)
        {
            method_set();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            method_set();
        }
    }
}
