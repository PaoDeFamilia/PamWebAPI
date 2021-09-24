using ProjPokeAPI.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class FavDAO
    {
        public void Insert(Favorito fav)
        {
            var query = "";
            query += "Insert into tbl_favorito(idusuario, idpoke)";
            query += string.Format("values ('{0}', '{1}');", fav.IdUsuario, fav.IdPoke);
            var banco = new Banco();
            banco.executarComando(query);
        }

        public void Delete(Favorito fav)
        {
            var query = string.Format("Delete from tbl_favorito where idpoke = {0} and idusuario = {1}", fav.IdPoke, fav.IdUsuario);
            var banco = new Banco();
            banco.executarComando(query);
        }
        public List<Favorito> Select(Favorito fav)
        {
            var query = string.Format("Select * from tbl_favorito where idusuario = '{0}' ", fav.IdUsuario);
            var banco = new Banco();
            var result = banco.listarDados(query);
            return ListFavoritos(result);
        }

        public List<Favorito> ListFavoritos(MySqlDataReader result)
        {
            var favs = new List<Favorito>();
            while (result.Read())
            {
                var Favoritos = new Favorito()
                {
                    IdUsuario = int.Parse(result["idusuario"].ToString()),
                    IdPoke = int.Parse(result["idpoke"].ToString())
                };
                favs.Add(Favoritos);
            }
            result.Close();
            return favs;
        }
    }
}
