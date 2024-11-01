using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Database;
using MySql.Data.MySqlClient;
using ProjetoEscola.Helpers;

namespace ProjetoEscola.Models
{
    public class UsuarioDAO
    {
        //private static Conexao _conn = new Conexao();

        public Usuario GetByUsuario(string usuario)
        {
            return new Usuario()
            {
                Id = 1,
                Nome = "Max Uanderson",
                Email = "joao@ifro.edu.br",
                Username = "joao",
                Perfil = "admin",
                Senha = HashHelper.Compute("joao1234"),
                Image = "user_1.jpg"
            };
        }

        public Usuario GetByUsuario(string usuarioNome, string senha)
        {
            try
            {
                //var query = _conn.Query();
                //query.CommandText = "SELECT * FROM usuario " +
                //    "WHERE usuario_usu = @usuario AND senha_usu = @senha";

                //query.Parameters.AddWithValue("@usuario", usuarioNome);
                //query.Parameters.AddWithValue("@senha", senha);

                //MySqlDataReader reader = query.ExecuteReader();

                Usuario usuario = null;

                //while (reader.Read())
                //{
                //    usuario = new Usuario();
                //    usuario.Id = reader.GetInt32("cod_usu");
                //    usuario.Nome = reader.GetString("nome_usu");
                //    //usuario.Funcionario = new Funcionario() { Id = reader.GetInt32("cod_func"), Nome = reader.GetString("nome_func") };
                //}

                return usuario;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //_conn.Close();
            }
        }
    }
}
