using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago.JoinArchive
{
    public class ExtrairDados
    {

        List<string> tempo, tipoCliente, uF, operadoraLd, tarifa, quantidade, duracaoBonificada, duracaoTarifadaMin, duracaoBonificadaMin, valor, valorSemAd, valorBonificado;


        public static int GetLastUsedRow(ExcelWorksheet sheet, int colnum)
        {
            var row = sheet.Dimension.End.Row;
            while (row >= 1)
            {
                var range = sheet.Cells[row, colnum, row, colnum];
                if (range.Any(c => !string.IsNullOrEmpty(c.Text)))
                {
                    break;
                }
                row--;
            }
            return row;
        }


        public static List<string> LerPlanilha(string range, string column, ExcelWorksheet ws)
        {
            try
            {
                var lastColCell1 = GetLastUsedRow(ws, 2);

                var address = new StringBuilder();
                address.Append(range).Append(":").Append(column).Append(lastColCell1);

                var cells = ws.Cells;
                var dictionary = cells[address.ToString()]
                    .GroupBy(c => new { c.Start.Row, c.Start.Column })
                    .Where(x => (cells[x.Key.Row, x.Key.Column].Value != null) && (cells[x.Key.Row, x.Key.Column].Value.ToString() != "PT Inovação Copyright  - 2006"))
                    .Select(rcg => cells[rcg.Key.Row, rcg.Key.Column].Value)
                    .ToList()
                    .ConvertAll(x => x.ToString());

                return dictionary;
            }
            catch (ArgumentException)
            {
                return null;
            }

        }


        private void AdicionaListaFinal(List<string> dadosExtraidos, ref List<string> destino)
        {

            if (destino == null)
            {
                destino = new List<string>(dadosExtraidos);

            }
            else
            {
                foreach (var item in dadosExtraidos)
                {
                    destino.Add(item);
                }
            }


        }


        //public InformacoesPlan Extrair(List<FileInfo> arquivos, string dataReferencia)
        //{

        //    foreach (var item in arquivos)
        //    {
        //        using (ExcelPackage pck = new ExcelPackage(item))
        //        {
        //            var numeroSheets = pck.Workbook.Worksheets.Select(x => x.Index).ToList();

        //            foreach (var sheets in numeroSheets)
        //            {
        //                var ws = pck.Workbook.Worksheets[sheets];
        //                ws.DeleteColumn(6);

        //                AdicionaListaFinal(LerPlanilha("B4", "B", ws), ref tempo);
        //                AdicionaListaFinal(LerPlanilha("C4", "C", ws), ref tipoCliente);
        //                AdicionaListaFinal(LerPlanilha("D4", "D", ws), ref uF);
        //                AdicionaListaFinal(LerPlanilha("E4", "E", ws), ref operadoraLd);
        //                AdicionaListaFinal(LerPlanilha("F4", "F", ws), ref tarifa);
        //                AdicionaListaFinal(LerPlanilha("G4", "G", ws), ref quantidade);
        //                AdicionaListaFinal(LerPlanilha("H4", "H", ws), ref duracaoBonificada);
        //                AdicionaListaFinal(LerPlanilha("I4", "I", ws), ref duracaoTarifadaMin);
        //                AdicionaListaFinal(LerPlanilha("J4", "J", ws), ref duracaoBonificadaMin);
        //                AdicionaListaFinal(LerPlanilha("K4", "K", ws), ref valor);
        //                AdicionaListaFinal(LerPlanilha("L4", "L", ws), ref valorSemAd);
        //                AdicionaListaFinal(LerPlanilha("M4", "M", ws), ref valorBonificado);
        //            }

        //        }
        //    }

        //    var infos = new InformacoesPlan(tempo, tipoCliente, uF, operadoraLd, tarifa, quantidade, duracaoBonificada, duracaoTarifadaMin,
        //                                    duracaoBonificadaMin, valor, valorSemAd, valorBonificado);

        //    return infos;
        //}

        public async Task<InformacoesPlan> ExtrairAsync(List<FileInfo> arquivos, string dtReferenca, IProgress<string> progresso, CancellationToken ct)
        {
            var tasks = arquivos.Select(arq =>
                 Task.Factory.StartNew(() =>
                 {
                     ct.ThrowIfCancellationRequested();

                     ExcelPackage pck = new ExcelPackage(arq);

                     var numeroSheets = pck.Workbook.Worksheets.Select(x => x.Index).ToList();

                     foreach (var sheets in numeroSheets)
                     {
                         var ws = pck.Workbook.Worksheets[sheets];
                         ws.DeleteColumn(6);

                         AdicionaListaFinal(LerPlanilha("B4", "B", ws), ref tempo);
                         AdicionaListaFinal(LerPlanilha("C4", "C", ws), ref tipoCliente);
                         AdicionaListaFinal(LerPlanilha("D4", "D", ws), ref uF);
                         AdicionaListaFinal(LerPlanilha("E4", "E", ws), ref operadoraLd);
                         AdicionaListaFinal(LerPlanilha("F4", "F", ws), ref tarifa);
                         AdicionaListaFinal(LerPlanilha("G4", "G", ws), ref quantidade);
                         AdicionaListaFinal(LerPlanilha("H4", "H", ws), ref duracaoBonificada);
                         AdicionaListaFinal(LerPlanilha("I4", "I", ws), ref duracaoTarifadaMin);
                         AdicionaListaFinal(LerPlanilha("J4", "J", ws), ref duracaoBonificadaMin);
                         AdicionaListaFinal(LerPlanilha("K4", "K", ws), ref valor);
                         AdicionaListaFinal(LerPlanilha("L4", "L", ws), ref valorSemAd);
                         AdicionaListaFinal(LerPlanilha("M4", "M", ws), ref valorBonificado);                        

                         ct.ThrowIfCancellationRequested();
                     }

                     progresso.Report(arq.Name);

                 })

                );

            await Task.WhenAll(tasks);

            var infos = new InformacoesPlan(tempo, tipoCliente, uF, operadoraLd, tarifa, quantidade, duracaoBonificada, duracaoTarifadaMin,
                                duracaoBonificadaMin, valor, valorSemAd, valorBonificado);

            return infos;

        }
    }
}
