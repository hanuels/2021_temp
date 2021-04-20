using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Exporting.Text;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;


namespace PdfToExcel
{
    public partial class Form1 : Form
    {
        OpenFileDialog fileDialog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (fileDialog.FileName.Length > 0)
            {
                PdfDocument doc = new PdfDocument();
                doc.LoadFromFile(fileDialog.FileName);

                PdfPageBase page = doc.Pages[2];
                SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string text = page.ExtractText(strategy);
                FileStream fs = new FileStream("Result_PDF.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(text);
                sw.Flush();
                sw.Close();

                string textValue = System.IO.File.ReadAllText("Result_PDF.txt");
                textBox1.Text = textValue;
            }
            else { MessageBox.Show("PDF 파일을 선택해 주세요."); }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF Files|*.pdf";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName.Length > 0)
                {
                    axAcroPDF1.LoadFile(fileDialog.FileName);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Dispose();
            this.Close();
        }

        private void Form1_AutoSizeChanged(object sender, EventArgs e)
        {
            axAcroPDF1.Width = button1.Width;
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }

        //private static void WriteExcelData()
        //{
        //    Excel.Application excelApp = null;
        //    Excel.Workbook wb = null;
        //    Excel.Worksheet ws = null;
        //    try
        //    {
        //        excelApp = new Excel.Application();

        //        wb = excelApp.Workbooks.Open("test200.xlsx");
        //        // 엑셀파일을 엽니다.
        //        // ExcelPath 대신 문자열도 가능합니다
        //        // 예. Open(@"D:\test\test.xlsx");

        //        ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;
        //        // 첫번째 Worksheet를 선택합니다.

        //        Excel.Range rng = ws.Range[ws.Cells[1, 1], ws.Cells["A1", "H10"];
        //        // 해당 Worksheet에서 저장할 범위를 정합니다.
        //        // 지금은 저장할 행렬의 크기만큼 지정합니다.
        //        // 다른 예시 Excel.Range rng = ws.Range["B2", "G8"];

        //        object[,] data = new object["A1", "H10"];
        //        // 저장할 때 사용할 object 행렬

        //        for (int r = 0; r < row; r++)
        //        {
        //            for (int c = 0; c < column; c++)
        //            {
        //                // data[r , c] = Data[r, c] 저장할 데이터
        //            }
        //        }
        //        // for문이 아니더라도 object[,] 형으로 저장된다면 저장이 가능합니다.

        //        rng.Value = data;
        //        // data를 불러온 엑셀파일에 적용시킵니다. 아직 완료 X

        //        if (path != null)
        //            // path는 새로 저장될 엑셀파일의 경로입니다.
        //            // 따로 지정해준다면, "다른이름으로 저장" 의 역할을 합니다.
        //            // 상대경로도 가능합니다. (예. "secondExcel.xlsx")
        //            wb.SaveCopyAs(path);
        //        else
        //            // 따로 저장하지 않는다면 지금 파일에 그대로 저장합니다.
        //            wb.Save();

        //        wb.Close();
        //        excelApp.Quit();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        ReleaseExcelObject(ws);
        //        ReleaseExcelObject(wb);
        //        ReleaseExcelObject(excelApp);
        //    }
        //}


    }
}
