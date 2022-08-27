using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Teste.Desenvolvimento.Shared.Models;
using Teste_Desenvolvimento_Infra.Sql;

namespace Teste_Desenvolvimento_Infra.Repositories
{
    public class ConsultarRepository
    {
        private readonly string _connectionstring;

        public ConsultarRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<ImovelModel> ConsultarImovel(int id)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryFirstAsync<ImovelModel>(Consultas.ConsultarImovel,                    
                    new {id = id });
            }
        }

        public async Task<ImobiliariaModel> ConsultarImobiliaria(int id)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryFirstAsync<ImobiliariaModel>(Consultas.ConsultarImobiliaria,
                    new {id = id });
            }
        }

        public async Task<ProprietarioModel> ConsultarProprietario(int id)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryFirstAsync<ProprietarioModel>(Consultas.ConsultarProprietario,
                    new {id = id });
            }
        }

        public async Task<EnderecoModel> ConsultarEndereco(int id)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryFirstAsync<EnderecoModel>(Consultas.ConsultarEndereco,
                    new { id = id });
            }
        }
    }
}
