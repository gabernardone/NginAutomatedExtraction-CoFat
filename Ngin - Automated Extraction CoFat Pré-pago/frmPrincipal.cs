using Ngin___Automated_Extraction_CoFat_Pré_pago.JoinArchive;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{
    public partial class frmPrincipal : Form
    {
        NginExtractionConfig config = new NginExtractionConfig();
        private CancellationTokenSource _cts;
        ExtrairDados extr = new ExtrairDados();
        UnificarAquivos unr = new UnificarAquivos();

        public frmPrincipal()
        {
            InitializeComponent();

            if (!config.VerificarConfigurações())
            {
                btnExtrair.Enabled = false;
            }

        }

        private async void btnExtrair_Click(object sender, EventArgs e)
        {
            config = new NginExtractionConfig();

            btnExtrair.Visible = false;
            btnCancelar.Visible = true;

            _cts = new CancellationTokenSource();

            

            DataReferencia dt = new DataReferencia(config.CheckBoxData, config.DataReferencia);
            var data = dt.DataFormatada();

            ChromeDrive navegar = new ChromeDrive();

            var driver = navegar.StartChrome(config.Url, Path.GetTempPath(), config.Chrome);

            GerenciadorDiretorio ger = new GerenciadorDiretorio(data, Path.GetTempPath(), config.SaveIn);

            ger.ChecarDiretorio();


            try
            {
                AtualizarStatus("Acessando o Ngin, aguarde!");              

                var progress = new Progress<string>(x => pgbStatus.Value++);

                var links = await AcessarNgin(driver, data, _cts.Token);

                AtualizarStatus("Baixando relatórios");
                var arquivoBaixado = await ExtrairPlanilhas(data, links, driver, progress, _cts.Token);
               
                pgbStatus.Value = 0;
                driver.Quit();

                AtualizarStatus("Convertendo arquivos baixados");
                await ger.Converter(arquivoBaixado, progress, _cts.Token);

                pgbStatus.Value = 0;

                AtualizarStatus("Extraindo informações das planilhas");
                var infos = await extr.ExtrairAsync(ger.EscanearPasta(), ger.Data, progress, _cts.Token);

                AtualizarStatus("Consolidando Planilhas");
                await unr.Unificar(ger.DiretorioDataExtraida, ger.Data, infos, _cts.Token);

                AtualizarStatus("Consolidação Concluída com Sucesso");

                btnExtrair.Visible = true;
                btnCancelar.Visible = false;
                pgbStatus.Value = 0;
            }
            catch (OperationCanceledException)
            {
                btnExtrair.Visible = true;
                btnCancelar.Visible = false;
                pgbStatus.Value = 0;
                driver.Quit();
                AtualizarStatus("Operação Cancelada pelo Usuário");
            }
            catch(WebDriverException)
            {


            }

        }

        public void AtualizarStatus(string status)
        {

            lblStatus.Text = status;
        }

        private async Task<List<string>> ExtrairPlanilhas(string data, List<IWebElement> links, IWebDriver driver, IProgress<string> reportadorDeProgresso, CancellationToken ct)
        {

            return await Task.Run(() =>
            {
                ct.ThrowIfCancellationRequested();

                var downloads = DownloadArquivos.Download(driver, links, reportadorDeProgresso, ct);

                MethodInvoker action = delegate { pgbStatus.Maximum = downloads.Count(); };
                pgbStatus.BeginInvoke(action);

                ct.ThrowIfCancellationRequested();

                return downloads;

                
            }, ct);

        }

        private async Task<List<IWebElement>> AcessarNgin(IWebDriver driver, string data, CancellationToken ct)
        {


                return await Task.Run(() =>
                {
                    ct.ThrowIfCancellationRequested();

                    LoginNgin.Login(config.User, config.Password, driver);

                    RelatoriosEstaticos.AbrirRelatoriosEstaticos(driver);

                    RelatoriosEstaticos.AbrirDataAtual(driver, data);

                    var links = ListArquivos.ListaLinksDownlaod(driver);

                    MethodInvoker action = delegate { pgbStatus.Maximum = links.Count(); };
                    pgbStatus.BeginInvoke(action);

                    return links;

                });

        
        }

        private void tsmiOpcoes_Click(object sender, EventArgs e)
        {

            frmOpcoes formOpcoes = new frmOpcoes();
            formOpcoes.ShowDialog();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
            btnCancelar.Visible = false;
            btnExtrair.Visible = true;
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
