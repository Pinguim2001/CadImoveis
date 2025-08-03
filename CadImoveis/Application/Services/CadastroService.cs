using CadImoveis.Application.DTOs;
using CadImoveis.Domain.Entities;
using CadImoveis.Domain.Enum;
using CadImoveis.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace CadImoveis.Application.Services
{
    public class CadastroService
    {
        private readonly IProprietarioRepository proprietarioRepo;
        private readonly IImovelRepository imovelRepo;
        private readonly ImovelService imovelService;

        public CadastroService(IProprietarioRepository _proprietarioRepo, IImovelRepository _imovelRepo, ImovelService _imovelService)
        {
            this.proprietarioRepo = _proprietarioRepo;
            this.imovelRepo = _imovelRepo;
            this.imovelService = _imovelService;
        }

        public Guid CriarProprietario(ProprietarioDto _dto)
        {
            var proprietario = new Proprietario
            {
                Nome = _dto.Nome,
                Doc = _dto.Doc
            };

            proprietarioRepo.SetProprietario(proprietario);
            return proprietario.Id;
        }

        public Guid AddImovel(ImovelDto _dto) 
        {
            var imovel = new Imovel
            {
                IdProprietario = _dto.ProprietarioId,
                Area = _dto.Area,
                Endereco = _dto.Endereco,
                Etapa = Etapa.Imovel
            };

            imovelRepo.SetImovel(imovel);
            return imovel.Id;
        }

        public void FinalizarCadastro(Guid _imovelId)
        {
            var imovel = imovelRepo.GetById(_imovelId);

            if (imovel == null)
                throw new Exception("Imovel não localizado");

            imovel.Etapa = Etapa.Finalizado;

            imovel.Finalizado = true;

            imovelRepo.UpdateImovel(imovel);

        }

        public ResumoCadastroDto GetResumo(Guid _imovelId)
        {
            var imovel = imovelRepo.GetById(_imovelId);
            
            if(imovel == null || !imovel.Finalizado)
                    throw new Exception("Cadastro Finalizado ou Inexistente");

            var proprietario = proprietarioRepo.GetById(imovel.IdProprietario);
            var valor = imovelService.CalcValorHectare(imovel.Area) * imovel.Area;

            return new ResumoCadastroDto
            {
                NomeProp = proprietario.Nome,
                Doc = proprietario.Doc,
                Area = imovel.Area,
                Endereco = imovel.Endereco,
                ValorCalc = valor
            };
        }

        public Proprietario? GetProprietarioByDoc(string _documento)
        {
            return proprietarioRepo.GetByDoc(_documento);
        }

        public Imovel? RetomarCadastro(Guid _imovelId)
        {
            var imovel = imovelRepo.GetById(_imovelId);
            if (imovel == null || imovel.Finalizado)
                return null;

            return imovel;
        }

        public IEnumerable<object> ListarCadastros()
        {
            var imoveis = imovelRepo.ObterTodos();
            var proprietarios = imoveis
                .Select(i => proprietarioRepo.GetById(i.IdProprietario))
                .Where(p => p != null)
                .ToDictionary(p => p!.Id);

            return imoveis.Select(i => new
            {
                i.Id,
                i.Area,
                i.Endereco,
                i.Etapa,
                i.Finalizado,
                Proprietario = proprietarios.ContainsKey(i.IdProprietario) ? proprietarios[i.IdProprietario]!.Nome : "Desconhecido"
            });
        }

        public ValorTotalDto CalcValorTotal(string _documento)
        {
            var proprietario = proprietarioRepo.GetByDoc(_documento);
            if (proprietario is null)
                throw new Exception("Proprietario não encontrado");

            var imoveis = imovelRepo.GetByProprietario(proprietario.Id);
            var areaTotal = imoveis.Sum(i => i.Area);
            var valorTotal = imovelService.CalcValorTotal(imoveis);

            return new ValorTotalDto
            {
                Doc = _documento,
                AreaTotal = areaTotal,
                ValorTotal = valorTotal
            };
        }
    }
}
