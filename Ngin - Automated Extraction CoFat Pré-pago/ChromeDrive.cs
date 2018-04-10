using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{
    public class ChromeDrive
    {
        public IWebDriver StartChrome(string url, string downloadDirectory, string driverLocation)
        {

            ChromeDriverService service = ChromeDriverService.CreateDefaultService(driverLocation, "chromedriver.exe");
            service.HideCommandPromptWindow = true;

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
            //chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--no-sandbox");

            var driver = new ChromeDriver(service, chromeOptions);

            // Allow download in headless mode
            //var param = new Dictionary<string, string>();
            //param.Add("behavior", "allow");
            //param.Add("downloadPath", driverLocation);

            //var cmdParam = new Dictionary<string, object>();
            //cmdParam.Add("cmd", "Page.setDownloadBehavior");
            //cmdParam.Add("params", param);

            //var content = new StringContent(JsonConvert.SerializeObject(cmdParam), Encoding.UTF8, "application/json");

            driver.Navigate().GoToUrl(url);

            //var endereco = service.ServiceUrl + "session/" + driver.SessionId + "/chromium/send_command";

            //var httpClient = new HttpClient();
            //Post(endereco, content);



            return driver;

        }

        //public async void Post(string endereco, StringContent content)
        //{
        //    var httpClient = new HttpClient();
        //    await httpClient.PostAsync(endereco, content);
        //}


        public ChromeDrive()
        {

        }



    }
}
