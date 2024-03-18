using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

public class PDFHelper
{
    public static void ExportToPDF(DataGridView dataGridView, string filePath)
    {
        PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);

        // Установка шрифта и размера текста
        BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        Font font = new Font(baseFont, 8, Font.NORMAL);

        // Загрузка данных из DataGridView в PDF-таблицу
        foreach (DataGridViewColumn column in dataGridView.Columns)
        {
            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
            pdfTable.AddCell(cell);
        }

        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                pdfTable.AddCell(new Phrase(cell.Value.ToString(), font));
            }
        }

        // Создание документа и запись в файл
        Document pdfDocument = new Document();
        PdfWriter.GetInstance(pdfDocument, new FileStream(filePath, FileMode.Create));
        pdfDocument.Open();
        pdfDocument.Add(pdfTable);
        pdfDocument.Close();
    }
}
