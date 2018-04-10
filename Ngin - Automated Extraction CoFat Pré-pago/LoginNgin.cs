using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{
    static public class LoginNgin
    {


        static public void Login(string usuario, string senha, IWebDriver driver)
        {

            //Campo Usuário
            IWebElement username = driver.FindElement(By.Id("form-login-login"));

            //Campo Senha
            IWebElement password = driver.FindElement(By.XPath("/html/body/table/tbody/tr[2]/td/table/tbody/tr[1]/td[4]/table[1]/tbody/tr[3]/td[2]/input"));

            //Envia Usuário e Senha para seus respectivos campos
            username.Clear();
            username.SendKeys(usuario);

            password.Clear();
            password.SendKeys(senha);

            //Botão de "logar"
            driver.FindElement(By.XPath("/html/body/table/tbody/tr[2]/td/table/tbody/tr[1]/td[4]/table[1]/tbody/tr[3]/td[3]/span/a")).Click();

        }




    }
}
