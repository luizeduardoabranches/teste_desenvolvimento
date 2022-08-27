using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Teste.Desenvolvimento.Shared.Models;
using Teste_Desenvolvimento_Infra.Sql;

namespace Teste_Desenvolvimento_Infra.Repositories
{
    public class AlterarRepository
    {
        private readonly string _connectionstring;

        public AlterarRepository(IConfiguration configuracao)
        {
            _connectionstring = configuracao.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ImovelModel>> AtualizarImovel(ImovelModel imovel)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryAsync<ImovelModel>(Consultas.AtualizarImovel,
                    new
                    {
                        preco = imovel.Preco,
                        imobiliaria_id = imovel.ImobiliariaId,
                        proprietario_id = imovel.ProprietarioId,
                        endereco_id = imovel.EnderecoId,
                        id = imovel.Id
                    });
            }
        }

        public async Task<IEnumerable<ImobiliariaModel>> AtualizarImobiliaria(ImobiliariaModel imobiliaria)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryAsync<ImobiliariaModel>(Consultas.AtualizarImobiliaria,
                    new
                    {
                        nome = imobiliaria.Nome,
                        razaoSocial = imobiliaria.RazaoSocial,
                        telefone = imobiliaria.Telefone,
                        id = imobiliaria.Id
                    });
            }
        }

        public async Task<IEnumerable<ProprietarioModel>> AtualizarProprietario(ProprietarioModel proprietario)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryAsync<ProprietarioModel>(Consultas.AtualizarProprietario,
                    new
                    {
                        nome = proprietario.Nome,
                        telefone = proprietario.Telefone,
                        cpf = proprietario.Cpf,
                        id = proprietario.Id
                    });
            }
        }

        public async Task<IEnumerable<EnderecoModel>> AtualizarEndereco(EnderecoModel endereco)
        {
            using (MySqlConnection connectionString = new(_connectionstring))
            {
                return await connectionString.QueryAsync<EnderecoModel>(Consultas.AtualizarEndereco,
                    new
                    {
                        cep = endereco.Cep,
                        numero = endereco.Numero,
                        complemento = endereco.Complemento,
                        logradouro = endereco.Logradouro,
                        bairro = endereco.Bairro,
                        localidade = endereco.Localidade,
                        uf = endereco.Uf,
                        ibge = endereco.Ibge,
                        gia = endereco.Gia,
                        ddd = endereco.Ddd,
                        siafi = endereco.Siafi,
                        id = endereco.Id
                    });
            }
        }
    }
}
