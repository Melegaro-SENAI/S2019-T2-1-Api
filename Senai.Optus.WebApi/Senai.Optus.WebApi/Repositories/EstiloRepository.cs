using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                // facilitar a nossa vida
                // select 
                return ctx.Estilos.ToList();
            }
        }

        public void Cadastrar(Estilos estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // insert into eventos (nome) values (@nome)
                ctx.Estilos.Add(estilos);
                ctx.SaveChanges();
            }
        }

        // buscar por id 
        public Estilos BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        // atualizar
        public void Atualizar(Estilos estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilos.IdEstilo);
                // update estilos set nome = @nome
                EstiloBuscado.Nome = estilos.Nome;
                // insert - add, delete - remove, update - update
                ctx.Estilos.Update(EstiloBuscado);
                // efetivar
                ctx.SaveChanges();
            }
        }
        // deletar
        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // encontrar o item
                // chave primaria da tabela
                Estilos estilos = ctx.Estilos.Find(id);
                // remover do contexto
                ctx.Estilos.Remove(estilos);
                // efetivar as mudanças no banco de dados
                ctx.SaveChanges();
            }
        }
    }
}