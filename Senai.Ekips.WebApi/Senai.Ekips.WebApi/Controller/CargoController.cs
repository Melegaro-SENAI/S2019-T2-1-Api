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
    public class CargoController : ControllerBase
    {
        CargoRepository CargoRepository = new CargoRepository();

        [HttpGet]
        // IEnumerable<Cargos>
        public IActionResult Listar()
        {
            return Ok(CargoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Cargos cargos)
        {
            try
            {
                CargoRepository.Cadastrar(cargos);
                return Ok();
            }
            catch (Exception ex)
            {
               return BadRequest(new { mensagem = "Eita, erro: " + ex.Message });
            }
        }

        // [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cargos cargos = CargoRepository.BuscarPorId(id);
            if (cargos == null)
                return NotFound();
            return Ok(cargos);
        }

        [HttpPut]
        public IActionResult Atualizar(Cargos cargos)
        {
            try
            {
                // pesquisar um cargo
                Cargos CargoBuscado = CargoRepository.BuscarPorId(cargos.IdCargo);
                // caso nao encontre, not found 
                if (CargoBuscado == null)
                    return NotFound();
                // caso contrario, se ela for encontrada, eu ataulizo porque quero
                CargoRepository.Atualizar(cargos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu Erro" } + ex.Message);
            }
        }


    }
}