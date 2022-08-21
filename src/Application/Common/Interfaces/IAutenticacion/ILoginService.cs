using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Application.UseCase.LoginABM.GetByUserPassword;

namespace CrudTest.Application.Common.Interfaces.IAutenticacion
{
    public interface ILoginService
    {
       GetLoginResponse Login(string username);
    }
}
