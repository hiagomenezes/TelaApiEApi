using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaTesteApi
{
    public partial class Form2 : Form
    {
        List<Pessoas> listadepessoas = new List<Pessoas>();
        public Form2()
        {

            InitializeComponent();
            //  listadepessoas.Add();
        }
        //public string propriedade { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {



            dataGridView1.DataSource = listadepessoas;

            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }


    }
}
