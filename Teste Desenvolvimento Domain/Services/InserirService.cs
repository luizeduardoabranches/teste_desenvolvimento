using Microsoft.Extensions.Configuration;
using Teste.Desenvolvimento.Infra.Repositories;
using Teste.Desenvolvimento.Shared.Models;

namespace Teste_Desenvolvimento_Domain.Services
{
    public static class InserirService
    {
        public static async Task<string> InserirServiceAsync(RequisicaoModel requisicao, IConfiguration configuracao)
        {
            try
            {
                var inserir = new InserirRepository(configuracao);
                var endereco = await PopularEnderecoAsync(requisicao.Endereco); 

                await inserir.InserirEndereco(endereco);
                await inserir.InserirProprietario(requisicao.Proprietario);
                await inserir.InserirImobiliaria(requisicao.Imobiliaria);
                await inserir.InserirImovel(requisicao.Imovel);

                return "Dados cadastrados com sucesso!";

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

            return endereco;
        }
    }
}