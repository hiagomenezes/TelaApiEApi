using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaTesteApi
{
    class Pessoas
    {
        public Pessoas()
        {
        }

        public Pessoas(int id, string nome, int idade, string cpf, string rg,
            string data_nasc, string signo, string mae, string pai, string email, string senha, 
            string cep, string endereco, int numero, string bairro, string cidade, string estado, string telefone_fixo, 
            string celular, string altura, int peso, string tipo_sanguineo, string cor)
        {
            this.id = id;
            this.nome = nome;
            this.idade = idade;
            this.cpf = cpf;
            this.rg = rg;
            this.data_nasc = data_nasc;
            this.signo = signo;
            this.mae = mae;
            this.pai = pai;
            this.email = email;
            this.senha = senha;
            this.cep = cep;
            this.endereco = endereco;
            this.numero = numero;
            this.bairro = bairro;
            this.cidade = cidade; 
            this.estado = estado;
            this.telefone_fixo = telefone_fixo;
            this.celular = celular;
            this.altura = altura;
            this.peso = peso;
            this.tipo_sanguineo = tipo_sanguineo;
            this.cor = cor;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string data_nasc { get; set; }
        public string signo { get; set; }
        public string mae { get; set; }
        public string pai { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string telefone_fixo { get; set; }
        public string celular { get; set; }
        public string altura { get; set; }
        public int peso { get; set; }
        public string tipo_sanguineo { get; set; }
        public string cor { get; set; }
    }
}
