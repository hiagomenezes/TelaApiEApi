using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace telaAPI
{
    public class DB
    {
        
        public string conexao()
        {
            string con = "Server= localhost; Database= CadastroNotas; Integrated Security = SSPI";
            using (SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
            }
               
            

            return"";
        }
       






        //class CHAMANDO-O-BANCO-DE-DADOS(string con)
        //{
        //    banco tal vem aqui() = "banco.http.asdhuahsd";

        //    AQUI EU VOU CHAMAR A QUERY QUE VOU EXECUTAR DENTRO DO BANCO DE DADOS TAL()
        //        {
        //        string QUERY = @"SELECT * FROM CadastroNotas 
        //                    WHERE ID = 2";
        //    }
        //}
    }
}
