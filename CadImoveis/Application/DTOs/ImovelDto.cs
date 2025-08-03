namespace CadImoveis.Application.DTOs
{
    public class ImovelDto
    {
        public Guid ProprietarioId { get; set; }
        public decimal Area { get; set; }
        public string Endereco { get; set; } = string.Empty;
    }
}
