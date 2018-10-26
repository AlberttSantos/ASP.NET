using Biblioteca_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Jogos.DAL
{
    public class UsuarioDao
    {
        public Usuario ObterUsuarioESenha(string nome, string senha)
        {
            try
            {
                //Executar comandos do sql no banco
                var command = new SqlCommand();

                //Add conexão no comando
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM USUARIOS WHERE NOME = @Usuario AND SENHA = @Senha";

                //Add parametros da consulta
                command.Parameters.AddWithValue("@Usuario", nome);
                command.Parameters.AddWithValue("@Senha", senha);

                Conexao.Conectar();

                //Executa a query e retorna os dados do banco "ExecuteReader"
                var reader = command.ExecuteReader();

                Usuario usuario = null;

                //Enquanto estiver lendo
                while (reader.Read())
                {
                    usuario = new Usuario();

                    usuario.Id = (int)reader["id"];
                    usuario.Nome = (string)reader["nome"];
                    usuario.Senha = (string)reader["senha"];
                    usuario.Perfil = (char)reader["perfil"];
                }

                return usuario;
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
