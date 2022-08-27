using Newtonsoft.Json;
using Teste.Desenvolvimento.Shared.Models;
using Teste_Desenvolvimento_Infra.Repositories;

namespace Teste_Desenvolvimento_Domain.Services
{
    public static class ViaCepService
    {
        public static async Task<EnderecoModel> ConsultaCepServiceAsync(string cep)
        {
            HttpResponseMessage resposta = await ViaCepRepository.BuscaCepAsync(cep);

            string json = await resposta.Content.ReadAsStringAsync();

            EnderecoModel endereco = JsonConvert.DeserializeObject<EnderecoModel>(json);

            return endereco;
        }
    }
}
