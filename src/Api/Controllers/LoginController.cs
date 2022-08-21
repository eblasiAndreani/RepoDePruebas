using Andreani.ARQ.Pipeline.Clases;
using Andreani.ARQ.WebHost.Controllers;
using CrudTest.Application.UseCase.LoginABM.GetByUserPassword;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudTest.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : ApiControllerBase
    {
        [HttpGet("{User}")]
        [ProducesResponseType(typeof(GetLoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(string User) => Result(await Mediator.Send(new GetLoginRequest() { UserName = User }));
    }
}
