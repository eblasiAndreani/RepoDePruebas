using CrudTest.Application.UseCase.CuadroFutbolABM.Create;
using CrudTest.Domain.Entities;
using System.Threading.Tasks;

namespace CrudTest.Application.Common.Interfaces
{
    public interface ICuadroFutbolServiceCommands
    {
        Task<CuadroFutbol> Create(CuadroFutbolCreateRequest request);
        Task<CuadroFutbol> Delete(CuadroFutbol entity);
        Task<CuadroFutbol> Update(CuadroFutbol entity); 
    }
}
