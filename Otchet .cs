using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Word = Microsoft.Office.Interop.Word;



namespace IT_REHENIYA
{
    public partial class Otchet : Form
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
        public Otchet()
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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "itreheniyaDataSet1.Отчёты". При необходимости она может быть перемещена или удалена.
            this.отчётыTableAdapter.Fill(this.itreheniyaDataSet1.Отчёты);
 
      
   
       
       


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

     
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from Отчёты where [Неисправность] like '" + textBox4.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from Отчёты where [ID_Исполнителя] like '" + textBox2.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from Отчёты where [Исполнитель] like '" + textBox6.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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
            SqlCommand command = new SqlCommand($"INSERT INTO  Отчёты ([ID_Заявки],[ID_Исполнителя],[Исполнитель],[Стоимость_работы],[Неисправность],[Оказанная_помощь],[Дата])  Values (@id,@id_isp,@isp,@money,@err,@help,@date) ", con);

            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn;




            if (textBox5.Text != string.Empty || textBox2.Text != string.Empty)
            {

                if (textBox1.Text == textBox1.Text)
                {

                    cmd = new SqlCommand("select * from Отчёты where [ID_Заявки]= '" + textBox1.Text + "'", con);
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
                        command.Parameters.AddWithValue("@id", textBox1.Text);
                        command.Parameters.AddWithValue("@id_isp", textBox2.Text);
                        command.Parameters.AddWithValue("@isp", textBox3.Text);
                        command.Parameters.AddWithValue("@money", textBox4.Text);
                        command.Parameters.AddWithValue("@err", textBox5.Text);
                        command.Parameters.AddWithValue("@help", textBox6.Text);
                        command.Parameters.AddWithValue("@date", textBox7.Text);
                        command.ExecuteNonQuery();
                        dataGridView1.Update();
                        dataGridView1.Refresh();

                        MessageBox.Show("Информация успешно добавлена!!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox5.Clear();
                        textBox2.Clear();
                        textBox6.Clear();
                        textBox1.Clear();
                        textBox7.Clear();
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

            отчётыTableAdapter.Update((itreheniyaDataSet1)отчётыBindingSource.DataSource);
            MessageBox.Show("Изменения сохранены");


        }


        public void method_up() {

            SqlConnection con = new SqlConnection(@"Data Source=DOM\SQLEXPRESS;Initial Catalog=itreheniya;Integrated Security=True;Encrypt=False");


            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlDataReader dr;                 
            SqlConnection cn;
                    


            SqlCommand cmd = new SqlCommand("UPDATE Отчёты SET [ID_Исполнителя] ='" + textBox2.Text + "' ,  [Исполнитель] ='" + textBox3.Text + "' , [Стоимость_работы] ='" + textBox4.Text + "' , [Неисправность] ='" + textBox5.Text + "'  , [Оказанная_помощь] = '" + textBox6.Text + "' ,  [Дата]  = '" + textBox7.Text + "'    WHERE [ID_Заявки] = '" + textBox1.Text + "'    ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            dataGridView1.Update();
            dataGridView1.Refresh();

            MessageBox.Show("Информация успешно изменена!!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox5.Clear();
            textBox2.Clear();
            textBox6.Clear();
            textBox1.Clear();
            textBox7.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox7.Clear();
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

       
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from Отчёты where [Оказанная_помощь] like '" + textBox6.Text + "%'", con);
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from Отчёты where [ID_Заявки] like '" + textBox1.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from Отчёты where [Стоимость_работы] like '" + textBox4.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             Id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();





        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from Отчёты where [Неисправность] like '" + textBox5.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from Отчёты where [Дата] like '" + textBox7.Text + "%'", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void eXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Excel.Excel.dataExport(dataGridView1);
        }

        private void wORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Export_Data_To_Word(dataGridView1, sfd.FileName);
            }

        }




        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                //table style 
                /* oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");*/
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //header text
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "your header text";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save the file
                oDoc.SaveAs2(filename);

                //NASSIM LOUCHANI
            }
        }

      

        private void работаПоЗаявкамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Radota_po_zayavkam radota_Po_Zayavkam = new Radota_po_zayavkam();
            radota_Po_Zayavkam.Show();
            this.Close();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klientskaya_baza klientskaya_Baza = new Klientskaya_baza();
            klientskaya_Baza.Show();
            this.Close();
        }
    }







    }

