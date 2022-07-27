using Andreani.ARQ.Core.Interface;
using CrudTest.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.GetById
{
    public class CuadroFutbolGetByIdValidator : AbstractValidator<CuadroFutbolGetByIdRequest>
    {
        public CuadroFutbolGetByIdValidator()
        {
            RuleFor(x => x.Id)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("El id no puede estar vacio")
               .Must(x => int.TryParse(x, out int _))
               .WithMessage("No es un numero");
        }
    }
}
