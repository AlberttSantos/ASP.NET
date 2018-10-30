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
        public List<Jogo> ObterTodosJogos()
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
                    jogo.ValorPago = reader["valorPago"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["valorPago"]);

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

        public Jogo CarregarJogoSelecionado(int id_jogos)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM JOGO WHERE id = @id";

                command.Parameters.AddWithValue("@id", id_jogos);
                
                Conexao.Conectar();

                //Retorna a quantidade de linhas afetadas
                var reader =  command.ExecuteReader();

                Jogo jogo = null;

                while (reader.Read())
                {
                    jogo = new Jogo();

                    jogo.Id = (int)reader["id"];
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.Imagem = reader["imagem"].ToString();

                    //Se o valor do banco for nulo salva nulo na variavei dataCompra, se não salva a data
                    jogo.DataCompra = reader["dataCompra"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["dataCompra"];
                    jogo.ValorPago = reader["valorPago"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["valorPago"]);

                    jogo.Id_Editor = (int)reader["id_editor"];
                    jogo.Id_Genero = (int)reader["id_genero"];
                }

                return jogo;
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

        public int InserirJogo(Jogo jogo)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"INSERT INTO JOGO (titulo, valorPago, imagem, dataCompra, id_editor, id_genero)
                                      VALUES (@titulo, @valorPago, @imagem, @dataCompra, @id_editor, @id_genero)";

                command.Parameters.AddWithValue("@titulo", jogo.Titulo);
                command.Parameters.AddWithValue("@valorPago", jogo.ValorPago);
                command.Parameters.AddWithValue("@imagem", jogo.Imagem);
                command.Parameters.AddWithValue("@dataCompra", jogo.DataCompra);
                command.Parameters.AddWithValue("@id_editor", jogo.Id_Editor);
                command.Parameters.AddWithValue("@id_genero", jogo.Id_Genero);

                Conexao.Conectar();

                //Executa a query e retorna o numero de linhas afetadas
                return command.ExecuteNonQuery(); 
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
