using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Teste.Desenvolvimento.Shared.Models;
using Teste_Desenvolvimento_Infra.Sql;

namespace Teste_Desenvolvimento_Infra.Repositories
{
    public class ExcluirRepository
    {
        private readonly string _connectionstring;

        public ExcluirRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<ImovelModel> ExcluirImovelAsync(int id)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryFirstOrDefaultAsync<ImovelModel>(Consultas.ExcluirImovel,
                         new { id = id });
            }
        }

        public async Task<ImobiliariaModel> ExcluirImobiliariaAsync(int id)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryFirstOrDefaultAsync<ImobiliariaModel>(Consultas.ExcluirImobiliaria,
                         new { id = id });
            }
        }

        public async Task<ProprietarioModel> ExcluirProprietarioAsync(int id)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryFirstOrDefaultAsync<ProprietarioModel>(Consultas.ExcluirProprietario,
                         new { id = id });
            }
        }

        public async Task<EnderecoModel> ExcluirEnderecoAsync(int id)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryFirstOrDefaultAsync<EnderecoModel>(Consultas.ExcluirEndereco,
                         new { id = id });
            }
        }
    }
}
