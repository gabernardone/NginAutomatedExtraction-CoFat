using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{
    public static class RelatoriosEstaticos
    {


       public static void AbrirRelatoriosEstaticos(IWebDriver driver)
        {
            //Clica no botão "downloads" para abrir os relatórios estáticos
            driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr[2]/td/table/tbody/tr[1]/td[4]/table[1]/tbody/tr[1]/td[2]/a[1]")).Click();


            driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr[6]/td[1]/a/i")).Click();

        }

        public static void AbrirDataAtual(IWebDriver driver, string dataAtual)
        {
            try
            {
                driver.FindElement(By.XPath("//i[.='" + dataAtual + "']")).Click();
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                driver.Dispose();

                MessageBox.Show("Data solicitada não localizada, por gentileza, verifique no NGIN sua disponibilidade", "Data Referência não encontrada", MessageBoxButtons.OK);

                var principal = new frmPrincipal();
                principal.AtualizarStatus("Erro na execução, verifique as configurações e tente novamente!");

            }
            

        }



    }
}
