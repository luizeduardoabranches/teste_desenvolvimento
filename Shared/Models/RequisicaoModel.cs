namespace Teste.Desenvolvimento.Shared.Models
{
    public class RequisicaoModel
    {
        public ImovelModel Imovel { get; set; }
        public ImobiliariaModel Imobiliaria { get; set; }
        public ProprietarioModel Proprietario { get; set; }
        public RequisicaoEnderecoModel Endereco { get; set; }
    }
}
