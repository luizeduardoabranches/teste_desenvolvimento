using Microsoft.Extensions.Configuration;
using Teste.Desenvolvimento.Shared.Models;
using Teste_Desenvolvimento_Infra.Repositories;

namespace Teste_Desenvolvimento_Domain.Services
{
    public static class ExcluirService
    {

        public static async Task<string> ExcluirServiceAsync(RequisicaoIdModel resposta, IConfiguration configuracao)
        {
            try
            {
                var excluir = new ExcluirRepository(configuracao);
                RespostaModel requisicao = new();

                requisicao.Imovel = await excluir.ExcluirImovelAsync(resposta.ImovelId);
                requisicao.Imobiliaria = await excluir.ExcluirImobiliariaAsync(resposta.ImobiliariaId);
                requisicao.Endereco = await excluir.ExcluirEnderecoAsync(resposta.EnderecoId);
                requisicao.Proprietario = await excluir.ExcluirProprietarioAsync(resposta.ProprietarioId);

                return "Dados excluídos com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
