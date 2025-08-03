using CadImoveis.Domain.Entities;
using CadImoveis.Infrastructure.Persistence;
using CadImoveis.Domain.Interfaces;

namespace CadImoveis.Infrastructure.Repositories
{
    public class ProprietarioRepository : IProprietarioRepository
    {
        private readonly AppDbContext _dbContext;

        public ProprietarioRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public void SetProprietario(Proprietario proprietario)
        {
            _dbContext.Proprietarios.Add(proprietario);
            _dbContext.SaveChanges();
        }

        public Proprietario? GetById(Guid id)
        {
            return _dbContext.Proprietarios.Find(id);
        }

        public Proprietario? GetByDoc(string Doc)
        {
            return _dbContext.Proprietarios.FirstOrDefault(p => p.Doc == Doc);
        }
    }
}
