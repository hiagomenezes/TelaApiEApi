using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace telaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public Notas Get()
        {

            List<Detalhe> detalhes = new List<Detalhe>();

            detalhes.Add(new Detalhe()
            {
                serieRPS = "0001",
                serieNFe = "Série da NF-e",
                numeroRPS = "Número do RPS",
                dataRPS = DateTime.Now,
                situacaoRPS = "E",
                codigoMotivoCancelamento = "01 para Cancelamento do Serviço / 02 para Dados Incorretos / 03 para Substituição",
                numeroNFesubs = 0,
                sNFeCS = "cancelada/substituida",
                nFeCS = DateTime.Now,
                descricaoCancelamento = "Descrição do Motivo de Cancelamento. * Obrigatório somente para oscasos de RPS com Situação C(cancelado)",
                cSP = "Código do Serviço Prestado",
                lPS = "1",
                sPVP = "2",
                enderecoL = "Obrigatório para as atividades dos itens 7.02 e 7.05 da lista de serviços, não prestados em vias públicas.",
                numeroL = "Numero Logradouro",
                complementoL = "Complemento Logradouro do local do Serviço Prestado",
                bairroL = "Bairro Logradouro do local do Serviço Prestado",
                cidadeL = "Cidade Logradouro do local do Serviço Prestado",
                uFL = "SP",
                cEPL = "06325100",
                quantidadeServico = "100",
                valorServico = "15,60",
                valorTRetençoes = "15",
                tomadorEstrangeiro = "1",
                pNTE = "Códido do pais de nacionalidade do tomador, conforme tabela de paises quando o tomador for estrangeiro.",
                sPE = "2",
                identificacaoTomador = "2",
                tCNPJ = "3250001321569",
                razaoSocial = "INOVA TECNOLOGIA",
                enderecoT = "RUA MANAUS",
                numeroT = "11119",
                complementoT = "5 ANDAR",
                bairroT = "ALPHAVILLE",
                cidadeT = "BARUERI",
                uFT = "SP",
                cEPT = "06325100",
                email = "INOVA@ITECNOLOGIA.COM.BR",
                nfatura = 0,
                vfatura = 1525,
                formaPagamento = "BOLETO",
                discriminacaoServico = "Descritivo do Serviço Prestado (Este campo será impresso em um retângulo com até 100 caracteres por linha(largura) e 13 linhas,   (altura).Usar o caracter  |( pipe ou barra vertical) como delimitador de quebra de linha. A cada 100 caracteres é obrigatório o caracter de quebra | , não deverá ser colocado esse delimitador na 13º linha (última linha)",
                codOutVal = " 01 - para IRRF, 02 - para PIS/PASEP,03 - para COFINS,04 - para CSLL , VN - para Valor não Incluso na Base de Cálculo",
                valor = 321,
                valToSer = 12165564,
                valToValReg = 15,
                codMovCancelamento = ""

            });

            detalhes.Add(new Detalhe()
            {

                serieRPS = "0002",
                serieNFe = "Série da NF-e",
                numeroRPS = "Número do RPS",
                dataRPS = DateTime.Now,
                situacaoRPS = "E",
                codigoMotivoCancelamento = "01 para Cancelamento do Serviço / 02 para Dados Incorretos / 03 para Substituição",
                numeroNFesubs = 0,
                sNFeCS = "cancelada/substituida",
                nFeCS = DateTime.Now,
                descricaoCancelamento = "Descrição do Motivo de Cancelamento. * Obrigatório somente para oscasos de RPS com Situação C(cancelado)",
                cSP = "Código do Serviço Prestado",
                lPS = "1",
                sPVP = "2",
                enderecoL = "Obrigatório para as atividades dos itens 7.02 e 7.05 da lista de serviços, não prestados em vias públicas.",
                numeroL = "Numero Logradouro",
                complementoL = "Complemento Logradouro do local do Serviço Prestado",
                bairroL = "Bairro Logradouro do local do Serviço Prestado",
                cidadeL = "Cidade Logradouro do local do Serviço Prestado",
                uFL = "SP",
                cEPL = "06325100",
                quantidadeServico = "100",
                valorServico = "15,60",
                valorTRetençoes = "15",
                tomadorEstrangeiro = "1",
                pNTE = "Códido do pais de nacionalidade do tomador, conforme tabela de paises quando o tomador for estrangeiro.",
                sPE = "2",
                identificacaoTomador = "2",
                tCNPJ = "3250001321569",
                razaoSocial = "INOVA TECNOLOGIA",
                enderecoT = "RUA MANAUS",
                numeroT = "11119",
                complementoT = "5 ANDAR",
                bairroT = "ALPHAVILLE",
                cidadeT = "BARUERI",
                uFT = "SP",
                cEPT = "06325100",
                email = "INOVA@ITECNOLOGIA.COM.BR",
                nfatura = 0,
                vfatura = 1525,
                formaPagamento = "BOLETO",
                discriminacaoServico = "Descritivo do Serviço Prestado (Este campo será impresso em um retângulo com até 100 caracteres por linha(largura) e 13 linhas,   (altura).Usar o caracter  |( pipe ou barra vertical) como delimitador de quebra de linha. A cada 100 caracteres é obrigatório o caracter de quebra | , não deverá ser colocado esse delimitador na 13º linha (última linha)",
                codOutVal = " 01 - para IRRF, 02 - para PIS/PASEP,03 - para COFINS,04 - para CSLL , VN - para Valor não Incluso na Base de Cálculo",
                valor = 321,
                valToSer = 12165564,
                valToValReg = 15,
                codMovCancelamento = ""

            });

            detalhes.Add(new Detalhe()
            {
                serieRPS = "000",
                serieNFe = "Série da NF-e",
                numeroRPS = "Número do RPS",
                dataRPS = DateTime.Now,
                situacaoRPS = "E",
                codigoMotivoCancelamento = "01 para Cancelamento do Serviço / 02 para Dados Incorretos / 03 para Substituição",
                numeroNFesubs = 0,
                sNFeCS = "cancelada/substituida",
                nFeCS = DateTime.Now,
                descricaoCancelamento = "Descrição do Motivo de Cancelamento. * Obrigatório somente para oscasos de RPS com Situação C(cancelado)",
                cSP = "Código do Serviço Prestado",
                lPS = "1",
                sPVP = "2",
                enderecoL = "Obrigatório para as atividades dos itens 7.02 e 7.05 da lista de serviços, não prestados em vias públicas.",
                numeroL = "Numero Logradouro",
                complementoL = "Complemento Logradouro do local do Serviço Prestado",
                bairroL = "Bairro Logradouro do local do Serviço Prestado",
                cidadeL = "Cidade Logradouro do local do Serviço Prestado",
                uFL = "SP",
                cEPL = "06325100",
                quantidadeServico = "100",
                valorServico = "15,60",
                valorTRetençoes = "15",
                tomadorEstrangeiro = "1",
                pNTE = "Códido do pais de nacionalidade do tomador, conforme tabela de paises quando o tomador for estrangeiro.",
                sPE = "2",
                identificacaoTomador = "2",
                tCNPJ = "3250001321569",
                razaoSocial = "INOVA TECNOLOGIA",
                enderecoT = "RUA MANAUS",
                numeroT = "11119",
                complementoT = "5 ANDAR",
                bairroT = "ALPHAVILLE",
                cidadeT = "BARUERI",
                uFT = "SP",
                cEPT = "06325100",
                email = "INOVA@ITECNOLOGIA.COM.BR",
                nfatura = 0,
                vfatura = 1525,
                formaPagamento = "BOLETO",
                discriminacaoServico = "Descritivo do Serviço Prestado (Este campo será impresso em um retângulo com até 100 caracteres por linha(largura) e 13 linhas,   (altura).Usar o caracter  |( pipe ou barra vertical) como delimitador de quebra de linha. A cada 100 caracteres é obrigatório o caracter de quebra | , não deverá ser colocado esse delimitador na 13º linha (última linha)",
                codOutVal = " 01 - para IRRF, 02 - para PIS/PASEP,03 - para COFINS,04 - para CSLL , VN - para Valor não Incluso na Base de Cálculo",
                valor = 321,
                valToSer = 12165564,
                valToValReg = 15,
                codMovCancelamento = ""

            });

            Notas notas1 = new Notas();
            notas1.iC = "12";
            notas1.iRC = DateTime.Now;
            notas1.DetalheColecao = detalhes;

            var json = JsonConvert.SerializeObject(notas1);



            return notas1;




        }

        #region "lista de pessoas teste"
        //[HttpGet]
        //public List<Pessoas> Get()
        //{

        //    List<Pessoas> listPessoas = new List<Pessoas>();
        //    //var json = new Pessoas

        //    listPessoas.Add(new Pessoas()
        //    {

        //        nome = "Renato Luan da Paz",
        //        idade = 35,
        //        cpf = "660.913.733-15",
        //        rg = "18.520.070-9",
        //        data_nasc = "13/07/1984",
        //        signo = "Câncer",
        //        mae = "Elisa Carla Alícia",
        //        pai = "Elias Vinicius Vicente da Paz",
        //        email = "renatoluandapaz..renatoluandapaz@aguabr.com.br",
        //        senha = "QfjTbprOCA",
        //        cep = "66123-480",
        //        endereco = "Passagem Dadi",
        //        numero = 142,
        //        bairro = "Sacramenta",
        //        cidade = "Belém",
        //        estado = "PA",
        //        telefone_fixo = "(91) 3862-8883",
        //        celular = "(91) 98136-2789",
        //        altura = "1,84",
        //        peso = 62,
        //        tipo_sanguineo = "O-",
        //        cor = "vermelho",

        //    });

        //    listPessoas.Add(new Pessoas()
        //    {

        //        nome = "Isis Teresinha Ayla da Costa",
        //        idade = 72,
        //        cpf = "341.805.323-87",
        //        rg = "16.590.266-8",
        //        data_nasc = "18/08/1947",
        //        signo = "Leão",
        //        mae = "Maitê Francisca",
        //        pai = "Iago Yuri da Costa",
        //        email = "isisteresinhaayladacosta__isisteresinhaayladacosta@unimedsjc.com.br",
        //        senha = "eTrlHtLeCe",
        //        cep = "24722-120",
        //        endereco = "Rua Itacaju",
        //        numero = 795,
        //        bairro = "Monjolos",
        //        cidade = "São Gonçalo",
        //        estado = "RJ",
        //        telefone_fixo = "(21) 2883-9258",
        //        celular = "(21) 98759-5002",
        //        altura = "1,75",
        //        peso = 46,
        //        tipo_sanguineo = "AB-",
        //        cor = "preto"

        //    });

        //    listPessoas.Add(new Pessoas()
        //    {
        //        nome = "Marcelo Nicolas Roberto Peixoto",
        //        idade = 32,
        //        cpf = "157.753.855-27",
        //        rg = "23.862.272-1",
        //        data_nasc = "19/04/1987",
        //        signo = "Áries",
        //        mae = "Teresinha Alessandra",
        //        pai = "Emanuel Julio Peixoto",
        //        email = "marcelonicolasrobertopeixoto_@modus.com.br",
        //        senha = "JxT6g2OWZz",
        //        cep = "69317-454",
        //        endereco = "Rua Mercúrio",
        //        numero = 990,
        //        bairro = "Cidade Satélite",
        //        cidade = "Boa Vista",
        //        estado = "RR",
        //        telefone_fixo = "(95) 2540-6163",
        //        celular = "(95) 99153-3067",
        //        altura = "1,78",
        //        peso = 70,
        //        tipo_sanguineo = "AB+",
        //        cor = "vermelho"

        //    });

        //    listPessoas.Add(new Pessoas()
        //    {
        //        nome = "Isadora Stella Campos",
        //        idade = 64,
        //        cpf = "779.202.370-25",
        //        rg = "29.553.392-4",
        //        data_nasc = "16/01/1955",
        //        signo = "Capricórnio",
        //        mae = "Laís Elaine",
        //        pai = "Lucas Francisco Victor Campos",
        //        email = "iisadorastellacampos@oi.com.br",
        //        senha = "sglqwr8FcC",
        //        cep = "58081-160",
        //        endereco = "Rua Heitor Gusmão",
        //        numero = 176,
        //        bairro = "Costa e Silva",
        //        cidade = "João Pessoa",
        //        estado = "PB",
        //        telefone_fixo = "(83) 2846-4195",
        //        celular = "(83) 99264-9888",
        //        altura = "1,81",
        //        peso = 60,
        //        tipo_sanguineo = "O-",
        //        cor = "roxo"

        //    });

        //    listPessoas.Add(new Pessoas()
        //    {
        //        nome = "Aparecida Nina Lima",
        //        idade = 52,
        //        cpf = "644.384.262-60",
        //        rg = "35.984.581-2",
        //        data_nasc = "06/07/1967",
        //        signo = "Câncer",
        //        mae = "Raimunda Bruna Ayla",
        //        pai = "Antonio Julio Lima",
        //        email = "aparecidaninalima__aparecidaninalima@l3ambiental.com.br",
        //        senha = "4apUoXlkjd",
        //        cep = "57070-592",
        //        endereco = "Rua Leonardo Vinicius",
        //        numero = 167,
        //        bairro = "Rio Novo",
        //        cidade = "Maceió",
        //        estado = "AL",
        //        telefone_fixo = "(82) 2860-0617",
        //        celular = "(82) 98713-3407",
        //        altura = "1,74",
        //        peso = 50,
        //        tipo_sanguineo = "O+",
        //        cor = "vermelho"

        //    });

        //    listPessoas.Add(new Pessoas()
        //    {
        //        nome = "Otávio Mateus dos Santos",
        //        idade = 35,
        //        cpf = "210.453.851-31",
        //        rg = "40.019.844-7",
        //        data_nasc = "15/06/1984",
        //        signo = "Gêmeos",
        //        mae = "Juliana Márcia",
        //        pai = "Theo Marcos Vinicius dos Santos",
        //        email = "otaviomateusdossantos__otaviomateusdossantos@zignani.com.br",
        //        senha = "xiUx82KycU",
        //        cep = "25954-380",
        //        endereco = "Servidão dos Passarinhos",
        //        numero = 703,
        //        bairro = "Meudon",
        //        cidade = "Teresópolis",
        //        estado = "RJ",
        //        telefone_fixo = "(21) 2827-1432",
        //        celular = "(21) 98137-2421",
        //        altura = "1,96",
        //        peso = 82,
        //        tipo_sanguineo = "AB+",
        //        cor = "azul"

        //    });

        //    listPessoas.Add(new Pessoas()
        //    {
        //        nome = "Rafael Mateus Campos",
        //        idade = 43,
        //        cpf = "615.088.410-47",
        //        rg = "21.726.385-9",
        //        data_nasc = "25/07/1976",
        //        signo = "Leão",
        //        mae = "Isabel Lúcia",
        //        pai = "Calebe Alexandre Campos",
        //        email = "rafaelmateuscampos..rafaelmateuscampos@mx.labinal.com",
        //        senha = "5GueHoWmzY",
        //        cep = "28470-972",
        //        endereco = "Rua Principal, s/n",
        //        numero = 731,
        //        bairro = "São Pedro de Alcântara",
        //        cidade = "Santo Antônio de Pádua",
        //        estado = "RJ",
        //        telefone_fixo = "(22) 2657-5017",
        //        celular = "(22) 99319-7346",
        //        altura = "1,95",
        //        peso = 78,
        //        tipo_sanguineo = "A+",
        //        cor = "preto"

        //    });

        //    listPessoas.Add(new Pessoas()
        //    {
        //        nome = "Lucas Caio Carlos Eduardo Nunes",
        //        idade = 65,
        //        cpf = "642.849.185-08",
        //        rg = "14.969.360-6",
        //        data_nasc = "16/11/1954",
        //        signo = "Escorpião",
        //        mae = "Laura Ana",
        //        pai = "Marcos Vinicius Anderson Nunes",
        //        email = "llucascaiocarloseduardonunes@indaseg.com.br",
        //        senha = "2boHPFHb6s",
        //        cep = "78730-306",
        //        endereco = "Rua Jacuí",
        //        numero = 192,
        //        bairro = "Jardim Iguassu",
        //        cidade = "Rondonópolis",
        //        estado = "MT",
        //        telefone_fixo = "(66) 2978-3631",
        //        celular = "(66) 99619-4972",
        //        altura = "1,92",
        //        peso = 102,
        //        tipo_sanguineo = "A-",
        //        cor = "vermelho"

        //    });

        //    listPessoas.Add(new Pessoas()
        //    {
        //        nome = "Heitor Davi Benjamin Sales",
        //        idade = 65,
        //        cpf = "609.803.885-62",
        //        rg = "38.259.248-7",
        //        data_nasc = "15/07/1954",
        //        signo = "Câncer",
        //        mae = "Hadassa Louise",
        //        pai = "Rafael Marcelo Bryan Sales",
        //        email = "heitordavibenjaminsales__heitordavibenjaminsales@randstad.com.br",
        //        senha = "GHdFAeczSC",
        //        cep = "76900-868",
        //        endereco = "Rua Júlio Guerra",
        //        numero = 565,
        //        bairro = "Dois de Abril",
        //        cidade = "Ji-Paraná",
        //        estado = "RO",
        //        telefone_fixo = "(69) 2992-6527",
        //        celular = "(69) 99288-9743",
        //        altura = "1,76",
        //        peso = 82,
        //        tipo_sanguineo = "B+",
        //        cor = "verde"

        //    });

        //    listPessoas.Add(new Pessoas()
        //    {
        //        nome = "Sérgio Igor Enzo Moreira",
        //        idade = 20,
        //        cpf = "623.513.267-09",
        //        rg = "26.733.169-1",
        //        data_nasc = "17/01/1999",
        //        signo = "Capricórnio",
        //        mae = "Manuela Jaqueline Carolina",
        //        pai = "Nicolas Cauã Moreira",
        //        email = "sergioigorenzomoreira_@caferibeiro.com.br",
        //        senha = "8XgT3rnLTU",
        //        cep = "29175-695",
        //        endereco = "Beco Olavo Bilac",
        //        numero = 768,
        //        bairro = "das Laranjeiras",
        //        cidade = "Serra",
        //        estado = "ES",
        //        telefone_fixo = "(27) 3959-0152",
        //        celular = "(27) 98697-6862",
        //        altura = "1,83",
        //        peso = 107,
        //        tipo_sanguineo = "A+",
        //        cor = "laranja"

        //    });

        //    return listPessoas;
        //    //listPessoas.Add(json);


        //}

        #endregion
    }
}
