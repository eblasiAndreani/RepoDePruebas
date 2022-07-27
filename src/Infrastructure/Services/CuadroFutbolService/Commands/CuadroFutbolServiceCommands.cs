using Andreani.ARQ.Core.Interface;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Application.UseCase.CuadroFutbolABM.Create;
using CrudTest.Application.UseCase.CuadroFutbolABM.Delete;
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
                Nombre = request.Nombre
            };
            _repository.Insert(entity);
            await _repository.SaveChangeAsync();
            return entity;
        }

        public async Task<CuadroFutbol> Delete(CuadroFutbol entity)
        {
            _repository.Delete(entity);
            await _repository.SaveChangeAsync();
            return entity;
        }

        public async Task<CuadroFutbol> Update(CuadroFutbol entity)
        {
            _repository.Update(entity);
            await _repository.SaveChangeAsync();
            return entity;
        }
    }
}
