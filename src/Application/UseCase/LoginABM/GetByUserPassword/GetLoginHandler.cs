using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Application.Common.Interfaces.IAutenticacion;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.LoginABM.GetByUserPassword
{
    public class GetLoginHandler : IRequestHandler<GetLoginRequest, Response<GetLoginResponse>>
    {
        private readonly ILoginService loginService;
        public GetLoginHandler(ILoginService loginService)
        {
            this.loginService = loginService;
        }
#pragma warning disable CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        public async Task<Response<GetLoginResponse>> Handle(GetLoginRequest request, CancellationToken cancellationToken)
#pragma warning restore CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        {
            try
            {
                var response = loginService.Login(request.UserName);
                if(response is null)
                {
                    return new Response<GetLoginResponse>
                    {
                        Content = null,
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    };
                }
                else
                {
                    return new Response<GetLoginResponse>
                    {
                        Content = new GetLoginResponse
                        {
                            Token = response.Token
                        },
                        StatusCode = System.Net.HttpStatusCode.OK
                    };
                }
            }
            catch (Exception)
            {
                return new Response<GetLoginResponse>
                {
                    Content = null,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }
        }
    }
}
