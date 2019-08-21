using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositórios
{
    public class FuncionariosRepository
    {

        // onde que sera feita essa comunicação
        //private string StringConexao = "Data Source=localhost;Initial Catalog=T_People;Integrated Security=true;";
          private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_People;User Id=sa;Pwd=132;";

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            // chamar o banco - declaro passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // nossa Query a ser executada
                string Query = "SELECT * FROM Funcionarios";
                // abrir a conexao
                con.Open();

                // declaro para percorrer a lista
                SqlDataReader sdr;
                // comando a ser executado em qual conexao
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // pegar os valores da tabela do banco e armazenar dentro da aplicação do backend
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionarios = Convert.ToInt32(sdr["IdFuncionarios"]),
                            Nome = sdr["Nome"].ToString(),
                            Sobrenome = sdr["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }

            }
            // executar o select
            // retornar as informacoes

            return funcionarios;
            }
    
        public FuncionariosDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdFuncionarios, Nome FROM Funcionarios WHERE IdFuncionarios = @IdFuncionarios";
            // abrir a conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionarios", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        // ler o que tem no sdr
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionarios = Convert.ToInt32(sdr["IdFuncionarios"]),
                            Nome = sdr["Nome"].ToString(),
                            Sobrenome =sdr["Sobrenome"].ToString()
                        };
                        return funcionario;
                    }
                }
                return null;

                // retornar
            }
        }

        public void Cadastrar(FuncionariosDomain funcionariosDomain)
        {
            string Query = "INSERT INTO Funcionarios (Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionariosDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionariosDomain.Sobrenome);
                con.Open();
                cmd.ExecuteReader();
            }
        }  
                                    
        public void Deletar(int id)
        {
            string Query = "DELETE FROM EstilosMusicais WHERE IdEstiloMusical = @Id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
