using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{
    public class InformacoesPlan
    {

        public List<string> Tempo { get; set; }
        public List<string> TipoCliente { get; set; }
        public List<string> UF { get; set; }
        public List<string> OperadoraLd { get; set; }
        public List<string> Tarifa { get; set; }
        public List<string> Quantidade { get; set; }
        public List<string> DuracaoBonificada { get; set; }
        public List<string> DuracaoTarifadaMin { get; set; }
        public List<string> DuracaoBonificadaMin { get; set; }
        public List<string> Valor { get; set; }
        public List<string> ValorSemAd { get; set; }
        public List<string> ValorBonificado { get; set; }

        public InformacoesPlan(List<string> tempo, List<string> tipoCliente, List<string> uF, List<string> operadoraLd, List<string> tarifa, List<string> quantidade,List<string> duracaoBonificada, List<string> duracaoTarifadaMin,
                                List<string> duracaoBonificadaMin, List<string> valor, List<string> valorSemAd, List<string> valorBonificado)
        {
            Tempo = tempo;
            TipoCliente = tipoCliente;
            UF = uF;
            OperadoraLd = operadoraLd;
            Tarifa = tarifa;
            Quantidade = quantidade;
            DuracaoBonificada = duracaoBonificada;
            DuracaoTarifadaMin = duracaoTarifadaMin;
            DuracaoBonificadaMin = duracaoBonificadaMin;
            Valor = valor;
            ValorSemAd = valorSemAd;
            ValorBonificado = valorBonificado;
        }




    }
}
