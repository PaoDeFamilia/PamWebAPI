using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjPokeAPI.Data;
using Banco;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjPokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UserDAO usuarioDAO = new UserDAO();
        Usuario usuario = new Usuario();

        // GET: api/<UsuarioController>
        [HttpGet]
        public List<Usuario> Get()
        {
            var leitor = usuarioDAO.Select();
            return leitor;
        }

        // GET api/<UsuarioController>/email
        [HttpGet("{email}")]
        public List<Usuario> Get(string email)
        {
            usuario.Email = email;
            var leitor = usuarioDAO.Select(usuario);
            return leitor;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post(Usuario usu)
        {
            usuarioDAO.Insert(usu);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, Usuario usu)
        {
            usu.IdUsuario = id;
            usuarioDAO.Update(usu);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            usuario.IdUsuario = id;
            usuarioDAO.Delete(usuario);
        }
    }
}
