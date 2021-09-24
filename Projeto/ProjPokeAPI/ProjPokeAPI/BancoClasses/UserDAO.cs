using ProjPokeAPI.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class UserDAO
    {
        public void Insert(Usuario usuario)
        {
            var query = "";
            query += "Insert into tbl_usuario(nomeusuario, username, senha, email)";
            query += string.Format("values ('{0}', '{1}', '{2}', '{3}'); ", usuario.NomeUsuario, usuario.Username, usuario.Senha, usuario.Email);
            var banco = new Banco();
            banco.executarComando(query);
        }

        public void Update(Usuario usuario)
        {
            var query = "";
            query += "Update tbl_usuario set ";
            query += string.Format(" nomeusuario = '{0}', ", usuario.NomeUsuario);
            query += string.Format(" username = '{0}', ", usuario.Username);
            query += string.Format(" senha = '{0}', ", usuario.Senha);
            query += string.Format(" email = '{0}' ", usuario.Email);
            query += string.Format(" where idusuario = '{0}' ", usuario.IdUsuario);
            var banco = new Banco();
            banco.executarComando(query);
        }

        public void Delete(Usuario usuario)
        {
            var query = string.Format("Delete from tbl_usuario where idusuario = {0}", usuario.IdUsuario);
            var banco = new Banco();
            banco.executarComando(query);
        }

        public List<Usuario> Select()
        {
            var query = string.Format("Select * from tbl_usuario");
            var banco = new Banco();
            var result = banco.listarDados(query);
            return ListUsuarios(result);
        }

        public List<Usuario> SelectById(Usuario usuario)
        {
            var query = string.Format("Select * from tbl_usuario where idusuario = '{0}' ", usuario.IdUsuario);
            var banco = new Banco();
            var result = banco.listarDados(query);
            return ListUsuarios(result);
        }

        public List<Usuario> Select(Usuario usuario)
        {
            var query = string.Format("Select * from tbl_usuario where email = '{0}'", usuario.Email);
            var banco = new Banco();
            var result = banco.listarDados(query);
            return ListUsuarios(result);
        }

        public List<Usuario> ListUsuarios(MySqlDataReader result)
        {
            var usuarios = new List<Usuario>();
            while (result.Read())
            {
                var Usuarios = new Usuario()
                {
                    IdUsuario = int.Parse(result["idusuario"].ToString()),
                    NomeUsuario = result["nomeusuario"].ToString(),
                    Username = result["username"].ToString(),
                    Senha = result["senha"].ToString(),
                    Email = result["email"].ToString()
                };
                usuarios.Add(Usuarios);
            }
            result.Close();
            return usuarios;
        }
    }
}
