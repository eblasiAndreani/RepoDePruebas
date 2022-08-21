using Andreani.ARQ.Pipeline.Clases;
using MediatR;

namespace CrudTest.Application.UseCase.LoginABM.GetByUserPassword
{
    public class GetLoginRequest : IRequest<Response<GetLoginResponse>>
    {
        public string UserName { get; set; }
    }
}
