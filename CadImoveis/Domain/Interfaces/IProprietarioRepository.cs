using CadImoveis.Domain.Entities;

namespace CadImoveis.Domain.Interfaces
{
    public interface IProprietarioRepository
    {
        void SetProprietario(Proprietario proprietario);
        Proprietario? GetById(Guid Id);
        Proprietario? GetByDoc(string doc);
    }
}
