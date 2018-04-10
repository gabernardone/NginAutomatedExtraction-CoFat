using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{
    public static class DownloadArquivos
    {


        public static List<string> Download(IWebDriver driver, List<IWebElement> elementos, IProgress<string> progress, CancellationToken ct)
        {
            List<string> nomeArquivo = new List<string>();


            try
            {
                foreach (var item in elementos)
                {
                    ct.ThrowIfCancellationRequested();

                    item.Click();
                    nomeArquivo.Add(item.Text);

                    progress.Report(item.ToString());

                }
            }
            catch (OperationCanceledException)
            {
                driver.Quit();
                driver.Dispose();

                var principal = new frmPrincipal();
                principal.AtualizarStatus("Operação Cancelada pelo usuário.");
            }


            DownloadState(nomeArquivo);

            return nomeArquivo;
        }

        public static void DownloadState(List<string> arquivos)
        {
            foreach (var item in arquivos)
            {
                var downloadsPath = Path.GetTempPath() + item;

                for (var i = 0; i < arquivos.Count(); i++)
                {
                    if (File.Exists(downloadsPath)) { break; }
                    Thread.Sleep(1000);
                }
                var length = new FileInfo(downloadsPath).Length;
                for (var i = 0; i < arquivos.Count(); i++)
                {
                    Thread.Sleep(1000);
                    var newLength = new FileInfo(downloadsPath).Length;
                    if (newLength == length && length != 0) { break; }
                    length = newLength;
                }

            }


        }



    }
}
