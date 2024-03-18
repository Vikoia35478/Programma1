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
    public partial class Radota_po_zayavkam : Form
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
        public Radota_po_zayavkam ()
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

        private void Sotudniki_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "itreheniyaDataSet3.Заявки". При необходимости она может быть перемещена или удалена.
            this.заявкиTableAdapter.Fill(this.itreheniyaDataSet3.Заявки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "itreheniyaDataSet3.Заявки". При необходимости она может быть перемещена или удалена.
            this.заявкиTableAdapter.Fill(this.itreheniyaDataSet3.Заявки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_IT_REHENIYADataSet3.Заявки". При необходимости она может быть перемещена или удалена.
        
       

        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Autorization autorization = new Autorization();
                autorization.Show();


            }
            else
            {
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox_6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox_7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox_8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox_9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox_10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();



        }


        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_3.Clear();
            textBox_2.Clear();
            textBox_4.Clear();
            textBox_1.Clear();
            textBox_5.Clear();
            textBox_6.Clear();
            textBox_7.Clear();
            textBox_8.Clear();
            textBox_9.Clear();
            textBox_10.Clear();

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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel4.Parent.BackColor);
            System.Windows.Forms.Control control = panel4;
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel5.Parent.BackColor);
            System.Windows.Forms.Control control = panel5;
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

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel6.Parent.BackColor);
            System.Windows.Forms.Control control = panel6;
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

        private void label8_Click(object sender, EventArgs e)
        {
            method_add();
        }

        public void method_add() {


            using (SqlConnection con = new SqlConnection(@"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Заявки WHERE [ID_Заявки] = @ID_Заявки", con);
                cmd.Parameters.AddWithValue("@ID_Заявки", textBox_1.Text);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    MessageBox.Show("Такой запрос существует!!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    dr.Close();
                    SqlCommand insertCommand = new SqlCommand(@"INSERT INTO Заявки ([ID_Заявки],[ID_Исполнителя],[Исполнитель],[ФИО_Клиента],[Номер_телефона],[Тип_оборудования],[Серийный_номер],[Описание_проблемы],[Дата],[Статус_заявки])  
                                                        VALUES (@ID_Заявки,@ID_Исполнителя,@Исполнитель,@ФИО_Клиента,@Номер_телефона,@Тип_оборудования,@Серийный_номер,@Описание_проблемы,@Дата,@Статус)", con);

                    insertCommand.Parameters.AddWithValue("@ID_Заявки", textBox_1.Text);
                    insertCommand.Parameters.AddWithValue("@ID_Исполнителя", textBox_2.Text);
                    insertCommand.Parameters.AddWithValue("@Исполнитель", textBox_3.Text);
                    insertCommand.Parameters.AddWithValue("@ФИО_Клиента", textBox_4.Text);
                    insertCommand.Parameters.AddWithValue("@Номер_телефона", textBox_5.Text);
                    insertCommand.Parameters.AddWithValue("@Тип_оборудования", textBox_6.Text);
                    insertCommand.Parameters.AddWithValue("@Серийный_номер", textBox_7.Text);
                    insertCommand.Parameters.AddWithValue("@Описание_проблемы", textBox_8.Text);
                    insertCommand.Parameters.AddWithValue("@Дата", textBox_9.Text);
                    insertCommand.Parameters.AddWithValue("@Статус", textBox_10.Text);

                    insertCommand.ExecuteNonQuery();
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                    MessageBox.Show("Информация успешно добавлена!!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Очистка текстовых полей
                    textBox_1.Clear();
                    textBox_2.Clear();
                    textBox_3.Clear();
                    textBox_4.Clear();
                    textBox_5.Clear();
                    textBox_6.Clear();
                    textBox_7.Clear();
                    textBox_8.Clear();
                    textBox_9.Clear();
                    textBox_10.Clear();

                    dataGridView1.Update();
                    dataGridView1.Refresh();
                }
            }



        }



        public void method_del() {

            DialogResult dialogResult = MessageBox.Show("Вы действителльно хотите удалить строку?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int a = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);



            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        public void method_save() {

            заявкиTableAdapter.Update((itreheniyaDataSet3)заявкиBindingSource.DataSource);
            MessageBox.Show("Изменения сохранены");


        }


        public void method_up() {

            SqlConnection con = new SqlConnection(@"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False");


            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlDataReader dr;
            SqlConnection cn;



            SqlCommand cmd = new SqlCommand("UPDATE Заявки SET [ID_Исполнителя] = @ID_Исполнителя, [Исполнитель] = @Исполнитель, [ФИО_Клиента] = @ФИО_Клиента, " +
         "[Номер_телефона] = @Номер_телефона, [Тип_оборудования] = @Тип_оборудования, [Серийный_номер] = @Серийный_номер, [Описание_проблемы] = @Описание_проблемы, " +
         "[Дата] = @Дата, [Статус_заявки] = @Статус_заявки WHERE [ID_Заявки] = @ID", con);

            cmd.Parameters.AddWithValue("@ID_Исполнителя", textBox_2.Text);
            cmd.Parameters.AddWithValue("@Исполнитель", textBox_3.Text);
            cmd.Parameters.AddWithValue("@ФИО_Клиента", textBox_4.Text);
            cmd.Parameters.AddWithValue("@Номер_телефона", textBox_5.Text);
            cmd.Parameters.AddWithValue("@Тип_оборудования", textBox_6.Text);
            cmd.Parameters.AddWithValue("@Серийный_номер", textBox_7.Text);
            cmd.Parameters.AddWithValue("@Описание_проблемы", textBox_8.Text);
            cmd.Parameters.AddWithValue("@Дата", textBox_9.Text);
            cmd.Parameters.AddWithValue("@Статус_заявки", textBox_10.Text);
            cmd.Parameters.AddWithValue("@ID", textBox_1.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            dataGridView1.Update();
            dataGridView1.Refresh();

            MessageBox.Show("Информация успешно изменена!!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox_3.Clear();
            textBox_2.Clear();
            textBox_4.Clear();
            textBox_1.Clear();
            textBox_5.Clear();
            textBox_6.Clear();
            textBox_7.Clear();
            textBox_8.Clear();
            textBox_9.Clear();
            textBox_10.Clear();


            dataGridView1.Update();
            dataGridView1.Refresh();


        }

        private void panel3_Click(object sender, EventArgs e)
        {
            method_add();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            method_del();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            method_del();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            method_save();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            method_save();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            method_up();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            method_up();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void отчётыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Otchet otchet = new Otchet();
            otchet.Show();
            this.Close();
        }

        private void textBox_1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Заявки where [ID_Заявки] like '" + textBox_1.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox_2_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Заявки where [ID_Исполнителя] like '" + textBox_2.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox_3_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Заявки where [Исполнитель] like '" + textBox_3.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox_4_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Заявки where [ФИО_Клиента] like '" + textBox_4.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox_5_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Заявки where [Номер_телефона] like '" + textBox_5.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox_6_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Заявки where [Тип_оборудования] like '" + textBox_6.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox_7_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Заявки where [Серийный_номер] like '" + textBox_7.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox_8_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Заявки where [Описание_проблемы] like '" + textBox_8.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox_9_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Заявки where [Дата] like '" + textBox_9.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox_10_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Заявки where [Статус_заявки] like '" + textBox_10.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sotudniki sotudniki = new Sotudniki();
            sotudniki.Show();
            this.Close();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klientskaya_baza klientskaya_Baza = new Klientskaya_baza();
            klientskaya_Baza.Show();
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_3.Clear();
            textBox_2.Clear();
            textBox_4.Clear();
            textBox_1.Clear();
            textBox_5.Clear();
            textBox_6.Clear();
            textBox_7.Clear();
            textBox_8.Clear();
            textBox_9.Clear();
            textBox_10.Clear();
        }
    }
}
