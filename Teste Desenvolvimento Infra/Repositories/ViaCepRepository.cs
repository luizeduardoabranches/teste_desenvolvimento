namespace Teste_Desenvolvimento_Infra.Repositories
{
    public static class ViaCepRepository
    {
        public static async Task<HttpResponseMessage> BuscaCepAsync(string cep)
        {
            var client = new HttpClient();

            return await client.GetAsync($@"https://viacep.com.br/ws/{cep}/json/");
        }
    }
}
