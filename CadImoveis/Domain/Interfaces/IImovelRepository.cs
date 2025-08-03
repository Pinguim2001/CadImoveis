using CadImoveis.Domain.Entities;

namespace CadImoveis.Domain.Interfaces
{
    public interface IImovelRepository
    {
        void SetImovel(Imovel imovel);
        void UpdateImovel(Imovel imovel);

        Imovel? GetById(Guid id);
        IEnumerable<Imovel> GetByProprietario(Guid proprietarioId);

        IEnumerable<Imovel> ObterTodos();
    }
}
