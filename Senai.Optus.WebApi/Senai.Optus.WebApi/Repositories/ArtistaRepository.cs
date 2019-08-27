using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class ArtistaRepository
    {
        public List<Artistas> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                // facilitar a nossa vida
                // select
                return ctx.Artistas.ToList();
            }
        }

        public void Cadastrar(Artistas artista)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // insert into categorias (nome) values (@nome)
                ctx.Artistas.Add(artista);
                ctx.SaveChanges();
            }
        }

        // buscar por id
        public Artistas BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.FirstOrDefault(x => x.IdArtista == id);
            }
        }
    }
}
