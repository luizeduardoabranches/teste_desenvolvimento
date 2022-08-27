using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Teste.Desenvolvimento.Shared.Models;
using Teste_Desenvolvimento_Domain.Services;

namespace teste_desenvolvimento.Controllers
{
    [ApiController]
    [Route("controller/")]
    public class Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Controller(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("consultar")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(RequisicaoIdModel))]
        public async Task<IActionResult> ConsultarAsync(RequisicaoIdModel request)
        {
            return Ok(await ConsultarService.ConsultarServiceAsync(request, _configuration));
        }

        [HttpPost("inserir")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(string))]
        public async Task<IActionResult> InserirAsync(RequisicaoModel request)
        {
            return Ok(await InserirService.InserirServiceAsync(request, _configuration));
        }

        [HttpPut("alterar")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(string))]
        public async Task<IActionResult> AlterarAsync(RequisicaoModel request)
        {
            return Ok(await AlterarService.AlterarServiceAsync(request, _configuration));
        }

        [HttpDelete("excluir")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(string))]
        public async Task<IActionResult> ExcluirAsync(RequisicaoIdModel request)
        {
            return Ok(await ExcluirService.ExcluirServiceAsync(request, _configuration));
        }

    }
}