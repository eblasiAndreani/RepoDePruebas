using Andreani.ARQ.Pipeline.Clases;
using Andreani.ARQ.WebHost.Controllers;
using CrudTest.Application.UseCase.CuadroFutbolABM.Create;
using CrudTest.Application.UseCase.CuadroFutbolABM.Delete;
using CrudTest.Application.UseCase.CuadroFutbolABM.Get;
using CrudTest.Application.UseCase.CuadroFutbolABM.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudTest.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CuadroFutbolController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CuadroFutbolCreateResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CuadroFutbolCreateRequest body) => Result(await Mediator.Send(body));

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id) => Result(await Mediator.Send(new CuadroFutbolDeleteRequest{ Id = id }));

        [HttpGet]
        [ProducesResponseType(typeof(CuadroFutbolGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get() => Result(await Mediator.Send(new CuadroFutbolGetRequest()));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CuadroFutbolGetByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(string id) => Result(await Mediator.Send(new CuadroFutbolGetByIdRequest() { Id = id }));

    }
}
