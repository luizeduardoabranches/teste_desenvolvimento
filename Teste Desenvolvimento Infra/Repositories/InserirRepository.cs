using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Teste.Desenvolvimento.Shared.Models;
using Teste_Desenvolvimento_Infra.Sql;

namespace Teste.Desenvolvimento.Infra.Repositories
{
    public class InserirRepository
    {
        private readonly string _connectionstring;

        public InserirRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ImovelModel>> InserirImovel(ImovelModel propertieModel)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryAsync<ImovelModel>(Consultas.InserirImovel,
                    new
                    {
                        preco = propertieModel.Preco,
                        imobiliaria_id = propertieModel.ImobiliariaId,
                        proprietario_id = propertieModel.ProprietarioId,
                        endereco_id = propertieModel.EnderecoId
                    });
            }
        }

        public async Task<IEnumerable<ImobiliariaModel>> InserirImobiliaria(ImobiliariaModel realStateModel)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryAsync<ImobiliariaModel>(Consultas.InserirImobiliaria,
                    new
                    {
                        nome = realStateModel.Nome,
                        razaoSocial = realStateModel.RazaoSocial,
                        telefone = realStateModel.Telefone
                    });
            }
        }

        public async Task<IEnumerable<ProprietarioModel>> InserirProprietario(ProprietarioModel ownerModel)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryAsync<ProprietarioModel>(Consultas.InserirProprietario,
                    new
                    {
                        nome = ownerModel.Nome,
                        telefone = ownerModel.Telefone,
                        cpf = ownerModel.Cpf
                    });
            }
        }

        public async Task<IEnumerable<EnderecoModel>> InserirEndereco(EnderecoModel adressModel)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryAsync<EnderecoModel>(Consultas.InserirEndereco,
                    new
                    {
                        cep = adressModel.Cep,
                        logradouro = adressModel.Logradouro,
                        numero = adressModel.Numero,
                        complemento = adressModel.Complemento,
                        bairro = adressModel.Bairro,
                        localidade = adressModel.Localidade,
                        uf = adressModel.Uf,
                        ibge = adressModel.Ibge,
                        gia = adressModel.Gia,
                        ddd = adressModel.Ddd,
                        siafi = adressModel.Siafi
                    });
            }
        }
    }
}
