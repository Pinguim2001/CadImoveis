namespace CadImoveis.Application.DTOs
{
    public class ResumoCadastroDto
    {
        public string NomeProp { get; set; } = string.Empty;
        public string Doc { get; set; } = string.Empty;
        public decimal Area { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public decimal ValorCalc { get; set; }
    }
}
