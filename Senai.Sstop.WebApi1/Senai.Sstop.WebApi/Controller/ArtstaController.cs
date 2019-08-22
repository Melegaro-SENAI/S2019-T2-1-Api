using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domain;
using Senai.Filmes.WebApi.Repositorio;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {

            ArtistaRepository ArtistaRepository = new ArtistaRepository;
        // /api/artistas -> retornar a lista de artistas
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ArtistaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(ArtistaDomain artista)
        {
            try
            {
                // tenta fazer alguma coisa
                ArtistaRepository.Cadastrar(artista);
                // 200
                return Ok();
                // notfound - 404
            }
            catch (Exception ex)
            {
                // plano b
                // 400
                return BadRequest(new { mensagem = "Deu ruim" + ex.Message });
            }
        }
    }
}
