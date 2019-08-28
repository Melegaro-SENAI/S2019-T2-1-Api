using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        DepartamentoRepository DepartamentoRepository = new DepartamentoRepository();

        [HttpGet]
        // IEnumerable<Departamentos>
        public IActionResult Listar()
        {
            return Ok(DepartamentoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Departamentos departamento)
        {
            try
            {
                DepartamentoRepository.Cadastrar(departamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, Erro: " + ex.Message });
            }
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Departamentos departamento = DepartamentoRepository.BuscarPorId(id);
            if (departamento == null)
                return NotFound();
            return Ok(departamento);
        }
    }
}