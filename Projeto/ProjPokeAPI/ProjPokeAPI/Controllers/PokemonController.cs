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
    public class PokemonController : ControllerBase
    {
        PokeDAO pokeDAO = new PokeDAO();
        Pokemon poke = new Pokemon();

        // GET: api/<PokemonController>
        [HttpGet]
        public List<Pokemon> Get()
        {
            var leitor = pokeDAO.Select();
            return leitor;
        }

        // GET api/<PokemonController>/5
        [HttpGet("{id}")]
        public List<Pokemon> Get(int id)
        {
            poke.IdPoke = id;
            var leitor = pokeDAO.Select(poke);
            return leitor;
        }

        // POST api/<PokemonController>
        [HttpPost]
        public void Post(Pokemon pokemon)
        {
            pokeDAO.Insert(pokemon);
        }

        // PUT api/<PokemonController>/5
        [HttpPut("{id}")]
        public void Put(int id, Pokemon pokemon)
        {
            pokemon.IdPoke = id;
            pokeDAO.Update(pokemon);
        }

        // DELETE api/<PokemonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            poke.IdPoke = id;
            pokeDAO.Delete(poke);
        }
    }
}
