using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepository
    {
        public List<Cargos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // select 
                return ctx.Cargos.ToList();
            }
        }

        public void Cadastrar(Cargos cargos)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // insert
                ctx.Cargos.Add(cargos);
                ctx.SaveChanges();
            }
        }

        // buscar por id
        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
            }
        }

        // atualizar
        public void Atualizar(Cargos cargos)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Cargos CargoBuscado = ctx.Cargos.FirstOrDefault(x => x.IdCargo == cargos.IdCargo);
                // update cargos set nome = @nome
                CargoBuscado.Nome = cargos.Nome;
                // insert - add, delete - remove, update - update
                ctx.Cargos.Update(CargoBuscado);
                // efetivar
                ctx.SaveChanges();
            }
        }
    }
}
