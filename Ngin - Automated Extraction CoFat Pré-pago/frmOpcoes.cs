using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{
    public partial class frmOpcoes : Form
    {

        NginExtractionConfig conf;

        public frmOpcoes()
        {
            InitializeComponent();
            conf = new NginExtractionConfig();
            
            txtDiretorio.Text = conf.SaveIn;
            txtusuario.Text = conf.User;
            txtSenha.Text = conf.Password;
            txtUrl.Text = conf.Url;
            txtData.Text = conf.DataReferencia;
            txtChromeDriver.Text = conf.Chrome;
            ckbDataManual.Checked = conf.CheckBoxData;

            if (conf.CheckBoxData) 
            {
                txtData.Enabled = true;
            }

            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtDiretorio.Text == string.Empty || txtChromeDriver.Text == string.Empty || txtusuario.Text == string.Empty || txtSenha.Text == string.Empty || txtUrl.Text == string.Empty)
            {
                MessageBox.Show("Configurações necessárias não estão preenchinas. Obrigatório:/n Usuário, Senha, URL, Diretório, Chrome Driver");
            }
            else
            {
                conf.User = txtusuario.Text;
                conf.Password = txtSenha.Text;
                conf.Url = txtUrl.Text;
                conf.SaveIn = txtDiretorio.Text;
                conf.CheckBoxData = ckbDataManual.Checked;
                conf.DataReferencia = txtData.Text;
                conf.Chrome = txtChromeDriver.Text;

                conf.Save();
                conf.Reload();

                MessageBox.Show("Configurações Salvar com Sucesso!");
            }
 

            

        }

        private void ckbDataManual_CheckedChanged(object sender, EventArgs e)
        {            
            txtData.Enabled = ckbDataManual.Checked;
            lblInformacao.Visible = ckbDataManual.Checked;
        }

        private void frmOpcoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            var principal = new frmPrincipal();
            principal.Refresh();
        }
    }
}
