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
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();

        [HttpGet]
        // IEnumerable<Funcionarios>
        public IActionResult Listar()
        {
            return Ok(FuncionarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionarios)
        {
            try
            {
                FuncionarioRepository.Cadastrar(funcionarios);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro: " + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Funcionarios funcionarios = FuncionarioRepository.BuscarPorId(id);
            if (funcionarios == null)
                return NotFound();
            return Ok(funcionarios);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FuncionarioRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Funcionarios funcionarios)
        {
            try
            {
                // pesquisar um funcionario
                Funcionarios FuncionarioBuscado = FuncionarioRepository.BuscarPorId(funcionarios.IdFuncionario);
                // caso nao encontre, not found
                if (FuncionarioBuscado == null)
                    return NotFound();
                // caso contrario, se ela for encontrada, eu atualizo porque quero
                FuncionarioRepository.Atualizar(funcionarios);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu Erro" } + ex.Message);
            }
        }
    }
}