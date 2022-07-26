using Andreani.ARQ.Core.Interface;
using CrudTest.Domain.Entities;
using FluentValidation;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Create
{
    public class CuadroFutbolCreateValidator : AbstractValidator<CuadroFutbolCreateRequest>
    {
        private readonly IReadOnlyQuery _query;
        public CuadroFutbolCreateValidator(IReadOnlyQuery query)
        {
            _query = query;
            RuleFor(x => x.nombre)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("El nombre no puede estar vacio")
               .MaximumLength(255)
               .WithMessage("Apellido solo puede tener 255 caracteres")
               .NotEqual("River Plate")
               .WithMessage("No se aceptan club de segunda division")
               .Must(x => !GetCuadroFutbol("Nombre", x).Result)
               .WithMessage("El club ingresado ya esta registrado");
        }

        public async Task<bool> GetCuadroFutbol(string column, string nombre)
        {
            var cuadro = await _query.GetByIdAsync<CuadroFutbol>(column, nombre);
            return (cuadro is not null) ? true : false;
        }
    }
}
