using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        ArtistaRepository ArtistaRepository = new ArtistaRepository();

        [HttpGet]
        // IEnumerable<Artistas>
        public IActionResult Listar()
        {
            return Ok(ArtistaRepository.Listar());
        }

        /// <summary>
        /// Cadastrar uma categoria
        /// </summary>
        /// <param name="artista"></param>
        /// <returns>Mensagem de erro</returns>

        [HttpPost]
        public IActionResult Cadastrar(Artistas artista)
        {
            try
            {
                ArtistaRepository.Cadastrar(artista);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita erro: " + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("@{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Artistas artista = ArtistaRepository.BuscarPorId(id);
            if (artista == null)
                return NotFound();
            return Ok(artista);
        }
    }
}