using Andreani.ARQ.Core.Interface;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudTest.Infrastructure.Services.CuadroFutbolService.Queries
{
    public class CuadroFutbolServiceQueries : ICuadroFutbolServiceQueries
    {
        private readonly IReadOnlyQuery query;

        public CuadroFutbolServiceQueries(IReadOnlyQuery _query)
        {
            query = _query;
        }
        public async Task<bool> GetCuadroFutbol(string column, string nombre)
        {
            var cuadro = await query.GetByIdAsync<CuadroFutbol>(column, nombre);
            return (cuadro is not null) ? true : false;
        }

        public async Task<CuadroFutbol> GetByIdAsync(string column, string nombre)
        {
            var entity = await query.GetByIdAsync<CuadroFutbol>(column, nombre);
            return entity;
        }

        public async Task<IEnumerable<CuadroFutbol>> GetAllAsync()
        {
            var list = await query.GetAllAsync<CuadroFutbol>();
            return list;
        }
    }
}
