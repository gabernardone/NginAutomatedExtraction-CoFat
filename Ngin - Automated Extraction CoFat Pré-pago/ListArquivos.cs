using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{
    public static class ListArquivos
    {

        public static List<IWebElement> ListaLinksDownlaod(IWebDriver driver)
        {

                List<IWebElement> listaElementos = new List<IWebElement>();

                listaElementos = driver.FindElements(By.TagName("a")).ToList();

                listaElementos.RemoveRange(0, 4);

                return listaElementos;


        }



    }
}
