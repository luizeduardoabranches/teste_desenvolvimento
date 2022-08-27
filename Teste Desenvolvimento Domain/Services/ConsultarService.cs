using Microsoft.Extensions.Configuration;
using Teste.Desenvolvimento.Shared.Models;
using Teste_Desenvolvimento_Infra.Repositories;

namespace Teste_Desenvolvimento_Domain.Services
{
    public static class ConsultarService
    {

        public static async Task<RespostaModel> ConsultarServiceAsync(RequisicaoIdModel resposta, IConfiguration configuracao)
        {
            var consultar = new ConsultarRepository(configuracao);
            RespostaModel requisicao = new();

            requisicao.Imovel = await consultar.ConsultarImovel(resposta.ImovelId);
            requisicao.Imobiliaria = await consultar.ConsultarImobiliaria(resposta.ImobiliariaId);
            requisicao.Proprietario = await consultar.ConsultarProprietario(resposta.ProprietarioId);
            requisicao.Endereco = await consultar.ConsultarEndereco(resposta.EnderecoId);

            return requisicao;
        }
    }
}
