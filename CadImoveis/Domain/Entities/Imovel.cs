using CadImoveis.Domain.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CadImoveis.Domain.Entities
{
    public class Imovel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Area { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public Etapa Etapa { get; set; } = Etapa.Proprietario;
        public bool Finalizado { get; set; } = false;
        public Guid IdProprietario { get; set; }        
    }
}
