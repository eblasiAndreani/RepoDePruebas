using Andreani.ARQ.Core.Interface;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Application.UseCase.CuadroFutbolABM.Create;
using CrudTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Infrastructure.Services.CuadroFutbolService.Commands
{
    public class CuadroFutbolServiceCommands : ICuadroFutbolServiceCommands
    {
        private readonly ITransactionalRepository _repository;
        public CuadroFutbolServiceCommands(ITransactionalRepository repository)
        {
            _repository = repository;
        }
        public async Task<CuadroFutbol> Create(CuadroFutbolCreateRequest request)
        {
            var entity = new CuadroFutbol()
            {
                Nombre = request.nombre
            };
            _repository.Insert(entity);
            await _repository.SaveChangeAsync();
            return entity;
        }
    }
}
