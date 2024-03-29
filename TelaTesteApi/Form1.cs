﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using RestSharp;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Net;
using System.Security.Policy;

namespace TelaTesteApi
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
                if (column.Index == 0)
                {
                    column.ReadOnly = false;
                }
                else
                {
                    column.ReadOnly = true;
                }

            // função para verificar se tem pelomenos em check com o valor true para ativar o botão para gerar o lote
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                var i = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        i++;
                    }
                }


                if (i > 0)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                List<Pessoas> pessoas = new List<Pessoas>();

                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings["API"] ?? "Not Found";
                HttpClient client = new HttpClient();
                //caminho local da api
                client.BaseAddress = new Uri(result);
                //receber as informações da api em formato json
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // o metodo getasync vai fazer a solicitação do get e o metodo readasstringasync vai deserializar o json
                var formata = client.GetAsync("weatherforecast").Result.Content.ReadAsAsync<IEnumerable<Pessoas>>().Result;
                pessoas.AddRange(formata);

                dataGridView1.DataSource = pessoas;

                // função para não permiter que coloque a ultima linha
                dataGridView1.AllowUserToAddRows = false;
            }
            catch (Exception)
            {
                MessageBox.Show("A SUA API NÃO ESTA FUNCIONANDO", "INFORMAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // botão para selecionar 50 linhas de uma vez
            for (int i = 0; i < 50 && (i <= dataGridView1.Rows.Count - 1); i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (sender as CheckBox).Checked;
            }

            if (checkBox1.Checked == true)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }


            int Totallinhas = Convert.ToInt32(dataGridView1.Rows.Count.ToString());
            int selecionados = 0;
            for (int x = 0; x < Totallinhas; x++)
            {
                if (dataGridView1.Rows[x].Cells[0].Value.ToString() == "True")
                {
                    selecionados++;
                }
            }
            if (selecionados == 0) MessageBox.Show("Nenhum linha foi selecionada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (selecionados > 0) MessageBox.Show(selecionados + " linha(s) selecionada(s)", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter MeuCaminho = null;

            SaveFileDialog Salvar = new SaveFileDialog();
            //Escolher onde salvar o arquivo
            //GerarLote.InitialDirectory = @"C:\Users\hiago\Desktop\teste";
            Salvar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // metodo para filtra o tipo do arquivo que vai ser salvo
            Salvar.Filter = "arquivos txt (*.txt)|*.txt";
            // codigo para retornar para o dioretorio quando salvar o arquivo
            // GerarLote.RestoreDirectory = true;
            // obtém ou define o título da caixa de diálogo do arquivo
            Salvar.Title = "Tela API";


            // contar todas as colunas do datagridview
            int qtdColunas = dataGridView1.Columns.Count;

            if (Salvar.ShowDialog() == DialogResult.OK)
            {
                //Pega o caminho do arquivo
                string caminho = Salvar.FileName;
                //Cria um StreamWriter no local
                MeuCaminho = new StreamWriter(caminho);

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value) == true)
                    {
                        string linha = null;
                        for (int i = 0; i < qtdColunas; i++)
                        {
                            linha += item.Cells[i].Value.ToString();
                        }
                        MeuCaminho.WriteLine(linha);
                    }
                }
                MeuCaminho.Close();
                /*DialogResult result = */
                MessageBox.Show("Salvo com sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // esta função vai chamar o evento no botão 2
                button2.PerformClick();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2(); ;
            // vai adicionar o valor que estiver selecionado no checkedbox no datagridview 2
            var ps = new List<Pessoas>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Pessoas i = row.DataBoundItem as Pessoas;
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    ps.Add(i);
                }
            }
            form2.dataGridView2.DataSource = ps;
            form2.dataGridView2.Refresh();

            //  excluir o valor que estiver selecionado do datagridview 1
            List<Pessoas> pessoas1 = new List<Pessoas>();
            pessoas1 = (List<Pessoas>)dataGridView1.DataSource;

            foreach (Pessoas item in ps)
            {
                //Pessoas pe = item.DataBoundItem as Pessoas;
                pessoas1.Remove(item);

            }
            dataGridView1.DataSource = pessoas1;
            form2.Show();
            this.Hide();

        }

    }
}


