using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{
    public static class ConvertTo
    {
        public static void ConverterXLSX(string arquivo)
        {
            try
            {
                var excel = new Microsoft.Office.Interop.Excel.Application();
                var workbooks = excel.Workbooks;

                   var workbook = workbooks.Open(arquivo);

                    workbook.SaveAs(Filename: arquivo + "x", FileFormat: XlFileFormat.xlOpenXMLWorkbook);

                    workbook.Close(0);

                workbooks.Close();              
                excel.Quit();
                Marshal.ReleaseComObject(workbooks);
                Marshal.ReleaseComObject(excel);
                GC.Collect();

            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao realiza a conversão para .xlsx: {0}", e.Message);
            }




        }



    }
}
