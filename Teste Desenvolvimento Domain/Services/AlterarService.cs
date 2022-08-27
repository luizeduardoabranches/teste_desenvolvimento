using Microsoft.Extensions.Configuration;
using Teste.Desenvolvimento.Shared.Models;
using Teste_Desenvolvimento_Infra.Repositories;

namespace Teste_Desenvolvimento_Domain.Services
{
    public static class AlterarService
    {
        public static async Task<string> AlterarServiceAsync(RequisicaoModel requisicao, IConfiguration configuracao)
        {
            try
            {
                var alterar = new AlterarRepository(configuracao);
                var endereco = await PopularEnderecoAsync(requisicao.Endereco);

                await alterar.AtualizarImovel(requisicao.Imovel);
                await alterar.AtualizarImobiliaria(requisicao.Imobiliaria);
                await alterar.AtualizarProprietario(requisicao.Proprietario);
                await alterar.AtualizarEndereco(endereco);

                return "Dados atualizados com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private static async Task<EnderecoModel> PopularEnderecoAsync(RequisicaoEnderecoModel requisicao)
        {
            EnderecoModel endereco = new();
            var enderecoViacep = await ViaCepService.ConsultaCepServiceAsync(requisicao.Cep);

            endereco.Cep = requisicao.Cep;
            endereco.Complemento = requisicao.Complemento;
            endereco.Numero = requisicao.Numero;
            endereco.Bairro = enderecoViacep.Bairro;
            endereco.Localidade = enderecoViacep.Localidade;
            endereco.Logradouro = enderecoViacep.Logradouro;
            endereco.Uf = enderecoViacep.Uf;
            endereco.Ibge = enderecoViacep.Ibge;
            endereco.Gia = enderecoViacep.Gia;
            endereco.Ddd = enderecoViacep.Ddd;
            endereco.Siafi = enderecoViacep.Siafi;
            endereco.Id = requisicao.Id;

            return endereco;
        }
    }
}
