using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositórios;

namespace Senai.Peoples.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {

        FuncionariosRepository FuncionariosRepository = new FuncionariosRepository();

        [HttpGet]
        public IEnumerable<FuncionariosDomain> ListarTodos()
        {
            return FuncionariosRepository.Listar();
        }

        // o controller devera receber o id que eu quero buscar
        // GET /api/funcionarios/3
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionariosDomain funcionariosDomain = FuncionariosRepository.BuscarPorId(id);
            if (funcionariosDomain == null)
                return NotFound();
            return Ok(funcionariosDomain);
        }

        // cadastrar um novo
        [HttpPost]
        public IActionResult Cadastrar(FuncionariosDomain FuncionariosDomain)
        {
            FuncionariosRepository.Cadastrar(FuncionariosDomain);
            return Ok();
        }

        // DELETE /api/estilos/1009
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            FuncionariosRepository.Deletar(id);
            return Ok();
        }

        // atualizar - update
        //[HttpPut]
        //public IActionResult Atualizar(FuncionariosDomain funcionariosDomain)
        //{
          //  FuncionariosDomain.Atualizar(funcionariosDomain);
          //  return Ok();
       // }
    }
}