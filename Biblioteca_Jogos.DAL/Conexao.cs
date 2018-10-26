using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Jogos.DAL
{
    public class Conexao
    {
        //Obtem conection string do web.config
        public static string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ConnectionString;
        public static SqlConnection connection = new SqlConnection(connetionString);

        public static void Conectar()
        {   
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public static void Desconectar()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
