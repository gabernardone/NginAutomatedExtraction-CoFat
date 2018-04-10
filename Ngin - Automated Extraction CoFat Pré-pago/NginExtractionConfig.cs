using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{

    [Serializable()]
    public class NginExtractionConfig : ApplicationSettingsBase
    {
        
        [DefaultSettingValue(@""), UserScopedSetting]
        public string SaveIn
        {
            get { return (string)this["SaveIn"]; }
            set { this["SaveIn"] = value; }
        }

        [DefaultSettingValue("http://10.238.64.74:8005/cube/prep-mart/login"), UserScopedSetting]
        public string Url   
        {
            get { return (string)this["Url"]; }
            set { this["Url"] = value; }
        }

        [DefaultSettingValue("80543233"), UserScopedSetting]
        public string User     
        {
            get { return (string)this["User"]; }
            set { this["User"] = value; }
        }

        [DefaultSettingValue("Vivo@2016!"), UserScopedSetting]
        public string Password
        {
            get { return (string)this["Password"]; }
            set { this["Password"] = value; }
        }

        [DefaultSettingValue("false"), UserScopedSetting]
        public bool CheckBoxData
        {
            get { return (bool)this["CheckBoxData"]; }
            set { this["CheckBoxData"] = value; }
        }

        [DefaultSettingValue(""), UserScopedSetting]
        public string DataReferencia
        {
            get { return (string)this["DataReferencia"]; }
            set { this["DataReferencia"] = value; }
        }

        [DefaultSettingValue(""), UserScopedSetting]
        public string Chrome
        {
            get { return (string)this["Chrome"]; }
            set { this["Chrome"] = value; }
        }



        public bool VerificarConfigurações()
        {
            if (SaveIn == string.Empty || Chrome == string.Empty || User == string.Empty || Password == string.Empty || Url == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }

}
