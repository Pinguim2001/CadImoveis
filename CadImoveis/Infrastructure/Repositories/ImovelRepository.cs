using CadImoveis.Domain.Entities;
using CadImoveis.Domain.Interfaces;
using CadImoveis.Infrastructure.Persistence;

namespace CadImoveis.Infrastructure.Repositories
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly AppDbContext _dbContext;

        public ImovelRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SetImovel(Imovel imovel)
        {
            _dbContext.Imoveis.Add(imovel);
            _dbContext.SaveChanges();
        }
        public void UpdateImovel(Imovel imovel)
        {
            _dbContext.Imoveis.Update(imovel);
            _dbContext.SaveChanges();
        }
        public Imovel? GetById(Guid id)
        {
            return _dbContext.Imoveis.Find(id);
        }

        public IEnumerable<Imovel> GetByProprietario(Guid proprietarioId)
        {
            return _dbContext.Imoveis.Where(i => i.IdProprietario == proprietarioId).ToList();
        }

        public IEnumerable<Imovel> ObterTodos()
        {
            return _dbContext.Imoveis.ToList();
        }
    }
}
