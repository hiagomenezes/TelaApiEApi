using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace telaAPI.Controllers
{
    public class Detalhe
    {
        public string serieRPS { get; set; }
        public string serieNFe { get; set; }
        public string numeroRPS { get; set; }
        public DateTime dataRPS { get; set; }
        public string situacaoRPS { get; set; }
        public string codigoMotivoCancelamento { get; set; }
        public int numeroNFesubs { get; set; }
        public string sNFeCS { get; set; }
        public DateTime nFeCS { get; set; }
        public string descricaoCancelamento { get; set; }
        public string cSP { get; set; }
        public string lPS { get; set; }
        public string sPVP { get; set; }
        public string enderecoL { get; set; }
        public string numeroL { get; set; }
        public string complementoL { get; set; }
        public string bairroL { get; set; }
        public string cidadeL { get; set; }
        public string uFL { get; set; }
        public string cEPL { get; set; }
        public string quantidadeServico { get; set; }
        public string valorServico { get; set; }
        public string valorTRetençoes { get; set; }
        public string tomadorEstrangeiro { get; set; }
        public string pNTE { get; set; }
        public string sPE { get; set; }
        public string identificacaoTomador { get; set; }
        public string tCNPJ { get; set; }
        public string razaoSocial { get; set; }
        public string enderecoT { get; set; }
        public string numeroT { get; set; }
        public string complementoT { get; set; }
        public string bairroT { get; set; }
        public string cidadeT { get; set; }
        public string uFT { get; set; }
        public string cEPT { get; set; }
        public string email { get; set; }
        public int nfatura { get; set; }
        public float vfatura { get; set; }
        public string formaPagamento { get; set; }
        public string discriminacaoServico { get; set; }
        public string codOutVal { get; set; }
        public int valor { get; set; }
        public int valToSer { get; set; }
        public int valToValReg { get; set; }
        public string codMovCancelamento { get; set; }
    }
}
