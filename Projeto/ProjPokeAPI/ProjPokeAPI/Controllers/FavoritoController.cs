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
    public class FavoritoController : ControllerBase
    {
        FavDAO favDAO = new FavDAO();
        Favorito fav = new Favorito();

        // GET api/<FavoritoController>/5
        [HttpGet("{id}")]
        public List<Favorito> Get(int id)
        {
            fav.IdUsuario = id;
            var leitor = favDAO.Select(fav);
            return leitor;
        }

        // POST api/<FavoritoController>
        [HttpPost]
        public void Post(Favorito favorito)
        {
            favDAO.Insert(favorito);
        }

        // DELETE api/<FavoritoController>/5
        [HttpDelete]
        public void Delete(Favorito favorito)
        {
            favDAO.Delete(favorito);
        }
    }
}
