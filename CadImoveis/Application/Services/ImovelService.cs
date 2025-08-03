using CadImoveis.Domain.Entities;

namespace CadImoveis.Application.Services
{
    public class ImovelService
    {
        public decimal CalcValorHectare (decimal _area)
        {
            if (_area >= 1 && _area <= 10) return 26000;

            if (_area > 10 && _area <= 50) return 24000;

            if (_area > 50) return 23000;

            return 0;
        }

        public decimal CalcValorTotal (IEnumerable<Imovel> _imoveis)
        {
            return _imoveis.Sum(x => CalcValorHectare(x.Area) * x.Area);
        }   
    }
}
