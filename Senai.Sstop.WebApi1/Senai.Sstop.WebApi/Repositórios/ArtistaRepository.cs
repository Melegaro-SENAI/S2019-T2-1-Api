using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class ArtistaRepository
    {
        private string StringConexao = "Data Source=localhost;Initial Catalog=T_SStop;Integrated Security=true;";

        public List<ArtistaDomain> Listar()
        {
            List<ArtistaDomain> artistar = new List<ArtistaDomain>();

            string Query = "SELECT A.IdArtista, A.Nome, E.IdEstiloMusical, E.Nome AS NomeEstilo FROM Artistas AS A INNER JOIN EstilosMusicais AS E ON A.IdEstiloMusical = E.IdEstiloMusical;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;


                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // executa a query
                    sdr = cmd.ExecuteReader();

                    //percorrer os dados
                    while (sdr.Read())
                    {
                        ArtistaDomain artista = new ArtistaDomain
                        {
                            IdArtista = (sdr["IdArtista"]),
                            Nome = sdr["Nome"].ToString(),
                            Estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"]),
                                Nome = sdr["NomeEstilo"].ToString()
                            }

                        };
                        artistas.Add(artista);
                    }
                }
            }

        }

            public void Cadastrar(ArtistaDomain artistaDomain)
            {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string Query = "INSERT INTO Artistas (Nome, IdEstiloMusical) VALUES (@Nome, @EstiloMusical);";

                    SqlCommand cmd = new SqlCommand(Query, con);
                    // parametros
                    cmd.Parameters.AddWithValue("@Nome", artistaDomain.Nome);
                    cmd.Parameters.AddWithValue("@IdEstiloMusical", artistaDomain.Estilo.IdEstil);
                    con.Open();
                    cmd.ExecuteNonQuery();

            }
        }
    }
}        