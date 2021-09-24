using ProjPokeAPI.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class PokeDAO
    {
        public void Insert(Pokemon poke)
        {
            var query = "";
            query += "Insert into tbl_pokemon(idpoke, nomepoke, sprite, tipo1, tipo2, altura, peso)";
            query += string.Format("values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');", poke.IdPoke, poke.NomePoke, poke.Sprite, poke.Tipo1, poke.Tipo2, poke.Altura, poke.Peso);
            var banco = new Banco();
            banco.executarComando(query);
        }

        public void Update(Pokemon poke)
        {
            var query = "";
            query += "Update tbl_pokemon set ";
            query += string.Format(" nomepoke = '{0}', ", poke.NomePoke);
            query += string.Format(" sprite = '{0}', ", poke.Sprite);
            query += string.Format(" tipo1 = '{0}', ", poke.Tipo1);
            query += string.Format(" tipo2 = '{0}', ", poke.Tipo2);
            query += string.Format(" altura = '{0}', ", poke.Altura);
            query += string.Format(" peso = '{0}' ", poke.Peso);
            query += string.Format(" where idpoke = '{0}' ", poke.IdPoke);
            var banco = new Banco();
            banco.executarComando(query);
        }

        public void Delete(Pokemon poke)
        {
            var query = string.Format("Delete from tbl_pokemon where idpoke = {0}", poke.IdPoke);
            var banco = new Banco();
            banco.executarComando(query);
        }

        public List<Pokemon> Select()
        {
            var query = string.Format("Select * from tbl_pokemon");
            var banco = new Banco();
            var result = banco.listarDados(query);
            return ListPokemon(result);
        }

        public List<Pokemon> Select(Pokemon poke)
        {
            var query = string.Format("Select * from tbl_pokemon where idpoke = '{0}' ", poke.IdPoke);
            var banco = new Banco();
            var result = banco.listarDados(query);
            return ListPokemon(result);
        }

        public List<Pokemon> ListPokemon(MySqlDataReader result)
        {
            var pokes = new List<Pokemon>();
            while (result.Read())
            {
                var Pokes = new Pokemon()
                {
                    IdPoke = int.Parse(result["idpoke"].ToString()),
                    NomePoke = result["nomepoke"].ToString(),
                    Sprite = result["sprite"].ToString(),
                    Tipo1 = result["tipo1"].ToString(),
                    Tipo2 = result["tipo2"].ToString(),
                    Altura = int.Parse(result["altura"].ToString()),
                    Peso = int.Parse(result["peso"].ToString())
                };
                pokes.Add(Pokes);
            }
            result.Close();
            return pokes;
        }
    }
}
