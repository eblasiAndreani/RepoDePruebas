using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Update
{
    public class CuadroFutbolUpdateValidator : AbstractValidator<CuadroFutbolUpdateRequest>
    {
        public CuadroFutbolUpdateValidator()
        {
            RuleFor(x => x.Id)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("El id no puede estar vacio")
               .Must(x => int.TryParse(x, out int _))
               .WithMessage("No es un numero");
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
