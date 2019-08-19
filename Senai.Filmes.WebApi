using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domain;
using Senai.Filmes.WebApi.Repositorio;

namespace Senai.Filmes.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GeneroController : ControllerBase
    {

        List<GeneroDomain> generos = new List<GeneroDomain>
        {
            new GeneroDomain { IdGenero = 1, Nome = "Comedia"},
            new GeneroDomain { IdGenero = 2, Nome = "Terror"},
            new GeneroDomain { IdGenero = 3, Nome = "Romance"}
        };

        GeneroRepositorio GeneroRepositorio = new GeneroRepositorio();

        [HttpGet]
        public IEnumerable<GeneroDomain> ListarTodos()
        {
            //return generos;
            return GeneroRepositorio.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            GeneroDomain Genero = generos.Find(x => x.IdGenero == id);
            if (Genero == null)
            {
                return NotFound();
            }
            return Ok(Genero);
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            generos.Add(
                new GeneroDomain
                {
                    IdGenero = generos.Count + 1,
                    Nome = generoDomain.Nome
                }
            );
            return Ok(generos);
        }
        
    }

}