using Application.Interface;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadasUsuario.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ListaPessoasController : ControllerBase
    {
        private readonly ISorteio _peopleRepository;
        public ListaPessoasController(ISorteio peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]

        public async Task<ActionResult> Get ()
        {
            List<Pessoas> Pessoas = await _peopleRepository.GetPessoas();




            if (Pessoas is null)
                return NotFound();

            return Ok(Pessoas);
        }

    }
}
