using Biblioteca_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Jogos.DAL
{
    public class EditorDao
    {

        public List<Editor> ObterTodosEditores()
        {
            try
            {
                SqlCommand command = new SqlCommand();

                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM EDITOR";

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                List<Editor> editores = new List<Editor>();

                while (reader.Read())
                {
                    Editor editor = new Editor();
                    editor.Id = (int)reader["id"];
                    editor.Nome = (string)reader["nome"];

                    editores.Add(editor);
                }
                return editores;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexao.Desconectar();
                // command.CommandText = "SELECT e.id, e.nome FROM jogo j, editor e where j.id_editor = e.id and e.id = @id_jogo";
                //command.Parameters.AddWithValue("@id_jogo", id_jogo);
            }
        }

        public Editor SelecionarEditorDoJogo(string id_jogo)
        {
            try
            {
                SqlCommand command = new SqlCommand();

                command.Connection = Conexao.connection;
                command.CommandText = "SELECT e.id, e.nome FROM jogo j, editor e where j.id_editor = e.id and e.id = @id_jogo";
                command.Parameters.AddWithValue("@id_jogo", id_jogo);

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                Editor editor = new Editor();

                while (reader.Read())
                {                    
                    editor.Id = (int)reader["id"];
                    editor.Nome = (string)reader["nome"];                    
                }
                return editor;

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
