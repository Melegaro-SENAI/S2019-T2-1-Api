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
    [ApiController]
    public class EstiloController : ControllerBase
    {
        EstiloRepository EstiloRepository = new EstiloRepository();

        [HttpGet]
        // IEnumerable<Estilos>
        public IActionResult Listar()
        {
            return Ok(EstiloRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Estilos estilos)
        {
            try
            {
                EstiloRepository.Cadastrar(estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro:" + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("@{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos Estilo = EstiloRepository.BuscarPorId(id);
            if (Estilo == null)
                return NotFound();
            return Ok(Estilo);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Estilos Estilo)
        {
            try
            {
                // pesquisar um estilo
                Estilos EstiloBuscado = EstiloRepository.BuscarPorId(Estilo.IdEstilo);
                // caso nao encontre, not found
                if (EstiloBuscado == null)
                    return NotFound();
                // caso contrario, se ela for encontrada, eu atualizo porque quero
                EstiloRepository.Atualizar(Estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu Erro" } + ex.Message);
            }
        }
    }
}