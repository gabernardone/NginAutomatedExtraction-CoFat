using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago.JoinArchive
{
    public class GerenciadorDiretorio
    {

        public string Data { get; set; }
        public string DiretorioTemp { get; set; }
        public string DiretorioConf { get; set; }
        public string DiretorioDataExtraida { get; set; }

        public GerenciadorDiretorio(string data, string diretorioTemp, string diretorioConf)
        {
            Data = data.Remove(data.Length - 1);
            DiretorioTemp = diretorioTemp;
            DiretorioConf = diretorioConf;
            DiretorioDataExtraida = DiretorioConf + "\\" + Data;
        }

        public GerenciadorDiretorio()
        {

        }


        public void ChecarDiretorio()
        {
            if (!Directory.Exists(DiretorioDataExtraida))
            {
                Directory.CreateDirectory(DiretorioDataExtraida);
            }
        }


        public async Task Converter(List<string> arq, IProgress<string> progresso, CancellationToken ct)
        {
            
            var task = arq.Select(arquivo =>
                Task.Factory.StartNew(() =>
                {
                    ct.ThrowIfCancellationRequested();

                    ConvertTo.ConverterXLSX(DiretorioTemp + arquivo);
                    File.Delete(DiretorioTemp + arquivo);

                    if (!File.Exists(DiretorioDataExtraida + "\\" + arquivo + "x"))
                    {
                        File.Move(DiretorioTemp + arquivo + "x", DiretorioDataExtraida + "\\" + arquivo + "x");
                        progresso.Report(arquivo);
                    }

                    ct.ThrowIfCancellationRequested();
                })

            );

            await Task.WhenAll(task);

        }


        public List<FileInfo> EscanearPasta()
        {

            List<FileInfo> listaArquivos = new List<FileInfo>();
            var dir = new DirectoryInfo(DiretorioDataExtraida);

            foreach (var path in dir.GetFiles())
            {
                listaArquivos.Add(path);
            }


            return listaArquivos;
        }

    }
}
