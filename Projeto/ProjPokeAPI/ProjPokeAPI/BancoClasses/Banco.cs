using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Banco : IDisposable
    {
        private readonly MySqlConnection conexao;

        public Banco()
        {
            conexao = new MySqlConnection("server = host.docker.internal; port = 3308; user id = root; password = nic2003mysql; database = ProjPokeAPI");
            conexao.Open();
        }

        public void executarComando(string query)
        {
            var Comando = new MySqlCommand
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            Comando.ExecuteNonQuery();
        }

        public MySqlDataReader listarDados(string query)
        {
            var Comando = new MySqlCommand(query, conexao);
            return Comando.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
