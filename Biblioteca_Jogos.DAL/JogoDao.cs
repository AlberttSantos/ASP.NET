using Biblioteca_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Jogos.DAL
{
    public class JogoDao
    {
        public List<Jogo> ObterTodosJogo()
        {
            try
            {
                //Executar comandos do sql no banco
                var command = new SqlCommand();

                //Add conexão no comando
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM JOGO";

                Conexao.Conectar();

                //Executa a query e retorna os dados do banco "ExecuteReader"
                var reader = command.ExecuteReader();

                List<Jogo> jogos = new List<Jogo>();

                //Enquanto estiver lendo
                while (reader.Read())
                {
                    Jogo jogo = new Jogo();

                    jogo.Id = (int)reader["id"];
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.Imagem = reader["imagem"].ToString();

                    //Se o valor do banco for nulo salva nulo na variavei dataCompra, se não salva a data
                    jogo.DataCompra = reader["dataCompra"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["dataCompra"];
                    jogo.ValorPago = reader["valorPago"] == DBNull.Value ? (double?)null : (double)reader["valorPago"];

                    //Adiciona o jogo na lista
                    jogos.Add(jogo);
                }

                return jogos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexao.Desconectar();
               
            }
        }


    }
}
