using Biblioteca_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Jogos.DAL
{
    public class GeneroDao
    {
        public List<Genero> ObterTodosGeneros()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM GENERO ORDER BY DESCRICAO";

                Conexao.Conectar();
                var reader = command.ExecuteReader();

                List<Genero> generos = new List<Genero>();

                while (reader.Read())
                {
                    Genero genero = new Genero();
                    genero.Id = (int)reader["id"];
                    genero.Descricao = (string)reader["descricao"];

                    generos.Add(genero);
                }

                return generos;
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
