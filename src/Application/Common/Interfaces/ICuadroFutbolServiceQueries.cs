using CrudTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Application.Common.Interfaces
{
    public interface ICuadroFutbolServiceQueries
    {
        Task<bool> GetCuadroFutbol(string column, string nombre);
        Task<CuadroFutbol> GetByIdAsync(string column, string nombre);
        Task<IEnumerable<CuadroFutbol>> GetAllAsync(string column, string nombre);
    }
}
