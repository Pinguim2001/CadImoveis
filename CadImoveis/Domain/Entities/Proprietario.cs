namespace CadImoveis.Domain.Entities
{
    public class Proprietario
    {
        public Guid Id{ get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Doc {  get; set; } = string.Empty;
        public List<Imovel>? Imoveis { get; set; } 
    }
}
