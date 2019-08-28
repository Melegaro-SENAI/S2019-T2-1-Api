using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentoRepository
    {
        // listar
        public List<Departamentos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // facilitar a nossa vida
                // select 
                return ctx.Departamentos.ToList();
            }
        }
        // cadastrar
        public void Cadastrar(Departamentos departamentos)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // insert into Departamentos (nome) values (@nome)
                ctx.Departamentos.Add(departamentos);
                ctx.SaveChanges();
            }
        }

        // buscar por id
        public Departamentos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.Find(id);
            }
        }
    }
}
