using Andreani.ARQ.Core.Interface;
using CrudTest.Domain.Entities;
using FluentValidation;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Create
{
    public class CuadroFutbolCreateValidator : AbstractValidator<CuadroFutbolCreateRequest>
    {
        public CuadroFutbolCreateValidator()
        {
            RuleFor(x => x.Nombre)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("El nombre no puede estar vacio")
               .MaximumLength(255)
               .WithMessage("Apellido solo puede tener 255 caracteres")
               .NotEqual("River Plate")
               .WithMessage("No se aceptan club de segunda division");
        }
    }
}
