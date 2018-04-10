using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago.JoinArchive
{
    public class UnificarAquivos
    {


        public async Task Unificar(string diretorioDataExtraida, string dataReferencia, InformacoesPlan infos, CancellationToken ct)
        {

            //Cria um novo arquivo .xlsx que recebera as informações de todas as planilhas.

            FileInfo novoArquivo = new FileInfo(diretorioDataExtraida);
            var fileInfo = new FileInfo(novoArquivo + "\\" + "Concatenados_" + dataReferencia + ".xlsx");

           await Task.Run(() =>
            {
                ct.ThrowIfCancellationRequested();

                using (ExcelPackage pck = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = pck.Workbook.Worksheets.Add(dataReferencia);

                    var ws = pck.Workbook.Worksheets[1];

                    ws.Cells["A1"].Value = "Tempo";
                    ws.Cells["A2"].LoadFromCollection(infos.Tempo);

                    ws.Cells["B1"].Value = "Tipo Cliente";
                    ws.Cells["B2"].LoadFromCollection(infos.TipoCliente);

                    ws.Cells["C1"].Value = "Unidade Federativa";
                    ws.Cells["C2"].LoadFromCollection(infos.UF);

                    ws.Cells["D1"].Value = "Operadora LD";
                    ws.Cells["D2"].LoadFromCollection(infos.OperadoraLd);

                    ws.Cells["E1"].Value = "Tarifa";
                    ws.Cells["E2"].LoadFromCollection(infos.Tarifa);

                    ws.Cells["F1"].Value = "Quantidade";
                    ws.Cells["F2"].LoadFromCollection(infos.Quantidade);

                    ws.Cells["G1"].Value = "Duração Bonificada";
                    ws.Cells["G2"].LoadFromCollection(infos.DuracaoBonificada);

                    ws.Cells["H1"].Value = "Duração Tarifada (min)";
                    ws.Cells["H2"].LoadFromCollection(infos.DuracaoTarifadaMin);

                    ws.Cells["I1"].Value = "Duração Bonificada (min)";
                    ws.Cells["I2"].LoadFromCollection(infos.DuracaoBonificadaMin);

                    ws.Cells["J1"].Value = "Valor";
                    ws.Cells["J2"].LoadFromCollection(infos.Valor);

                    ws.Cells["K1"].Value = "Valor Sem Ad";
                    ws.Cells["K2"].LoadFromCollection(infos.ValorSemAd);

                    ws.Cells["L1"].Value = "Valor Bonificado";
                    ws.Cells["L2"].LoadFromCollection(infos.ValorBonificado);

                    ws.Cells["J1:J2"].Style.Numberformat.Format = "#,##0.00";

                    pck.Save();
                }


            });


        }
    }

}

