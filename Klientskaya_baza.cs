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
    public partial class Klientskaya_baza : Form
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
        public Klientskaya_baza()
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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "itreheniyaDataSet.Клиентская_база". При необходимости она может быть перемещена или удалена.
            this.клиентская_базаTableAdapter.Fill(this.itreheniyaDataSet.Клиентская_база);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_IT_REHENIYADataSet4.Клиентская_база". При необходимости она может быть перемещена или удалена.
      ;
        

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
           
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from  Клиентская_база  where [Номер_телефона] like '" + textBox2.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
                    
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
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
            con.Open();
            adapter = new SqlDataAdapter("select * from  Клиентская_база  where [ФИО_Клиента] like '" + textBox1.Text + "%'", con);
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
