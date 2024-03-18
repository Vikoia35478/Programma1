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
    public partial class Sotudniki : Form
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
        public Sotudniki()
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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "itreheniyaDataSet2.Исполнители". При необходимости она может быть перемещена или удалена.
            this.исполнителиTableAdapter.Fill(this.itreheniyaDataSet2.Исполнители);


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
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Исполнители  where [ID_Исполнителя] like '" + textBox4.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Исполнители  where [Должность] like '" + textBox2.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Исполнители  where [Отдел] like '" + textBox3.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
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


            SqlConnection con = new SqlConnection(@"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand($"INSERT INTO Исполнители([ID_Исполнителя],[Имя],[Должность ],[Отдел])  Values (@id,@name,@dol,@otd) ", con);

            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn;




            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {

                if (textBox4.Text == textBox4.Text)
                {

                    cmd = new SqlCommand("select * from Исполнители where [ID_Исполнителя] = '" + textBox4.Text + "'", con);
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
                        command.Parameters.AddWithValue("@id", textBox4.Text);
                        command.Parameters.AddWithValue("@name", textBox1.Text);
                        command.Parameters.AddWithValue("@dol", textBox2.Text);
                        command.Parameters.AddWithValue("@otd", textBox3.Text);

                        command.ExecuteNonQuery();
                        dataGridView1.Update();
                        dataGridView1.Refresh();
                        MessageBox.Show("Информация успешно добавлена!!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();

                        dataGridView1.Update();
                        dataGridView1.Refresh();


                    }
                }
                else
                {
                    MessageBox.Show("Такой запрос  существует!!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            исполнителиTableAdapter.Update((itreheniyaDataSet2)исполнителиBindingSource.DataSource);
            MessageBox.Show("Изменения сохранены");


        }


        public void method_up() {

            SqlConnection con = new SqlConnection(@"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False");


            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlDataReader dr;
            SqlConnection cn;



            SqlCommand cmd = new SqlCommand("UPDATE Исполнители SET   [Имя] = '" + textBox1.Text + "',[Должность]='" + textBox2.Text + "',[Отдел]='" + textBox3.Text + "'  WHERE [ID_Исполнителя] = '" + textBox4.Text + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            dataGridView1.Update();
            dataGridView1.Refresh();

            MessageBox.Show("Информация успешно изменена!!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
           

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

        private void работаПоЗаявкамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Radota_po_zayavkam radota_Po_Zayavkam = new Radota_po_zayavkam();
            radota_Po_Zayavkam.Show();
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klientskaya_baza klientskaya_Baza = new Klientskaya_baza();
            klientskaya_Baza.Show();
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
