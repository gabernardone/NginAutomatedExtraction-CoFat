using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{

    public class DataReferencia
    {

        public bool UsarDataManual { get; set; }
        public string DataManual { get; set; }


        public DataReferencia(bool usarDataManual, string dataManual)
        {
            UsarDataManual = usarDataManual;
            DataManual = dataManual;
        }

        public DataReferencia()
        {

        }


        private string[] Data()
        {
            CultureInfo culture = new CultureInfo("en-US");
            string[] anoMes = new string[2];

            if (!UsarDataManual)
            {
                       
                anoMes[0] = DateTime.Now.Year.ToString();
                anoMes[1] = culture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.Month);


                return anoMes;
            }
            else
            {

                anoMes[0] = DataManual.Split('/')[0];
                anoMes[1] = culture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(DataManual.Split('/')[1]));


                return anoMes;
            }

        }


        public string DataFormatada()
        {

            var data = Data();

            return string.Format("{0}_{1}/", data[0], data[1]);

            
        }


    }
}
