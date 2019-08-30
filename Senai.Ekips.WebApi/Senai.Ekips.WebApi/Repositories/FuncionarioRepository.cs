using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        public List<Funcionarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // select
                return ctx.Funcionarios.ToList();
            }
        }

        public void Cadastrar(Funcionarios funcionarios)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // insert 
                ctx.Funcionarios.Add(funcionarios);
                ctx.SaveChanges();
            }
        }

        // buscar por id
        public Funcionarios BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
            }
        }

        // atualizar 
        public void Atualizar(Funcionarios funcionarios)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios FuncionarioBuscado = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == funcionarios.IdFuncionario);
                // update funcionarios set nome = @nome
                FuncionarioBuscado.Nome = funcionarios.Nome;
                // insert - add, delete - remove, update - update
                ctx.Funcionarios.Update(FuncionarioBuscado);
                // efetivar
                ctx.SaveChanges();
            }
        }

        // deletar
        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // encontrar o item 
                // chave primaria da tabela
                Funcionarios funcionario = ctx.Funcionarios.Find(id);
                // remover do contexto
                ctx.Funcionarios.Remove(funcionario);
                // efetivar as mudanças no banco de dados
                ctx.SaveChanges();
            }
        }
    }
}
