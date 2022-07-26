using CrudTest.Domain.Dtos;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.GetById
{
    public class CuadroFutbolGetByIdResponse
    {
        public CuadroFutbolDTO cuadroFutbolDTO { get; set; }
        public string Message { get; set; }
    }
}
