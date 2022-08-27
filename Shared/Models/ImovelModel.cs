namespace Teste.Desenvolvimento.Shared.Models
{
    public class ImovelModel
    {
        public int Id { get; set; }
        public double Preco { get; set; }
        public int ProprietarioId { get; set; }
        public int ImobiliariaId { get; set; }
        public int EnderecoId { get; set; }
    }
}
