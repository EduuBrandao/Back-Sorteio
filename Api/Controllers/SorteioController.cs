using Application.Interface;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteio_de_Habilitação.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteioController : Controller
    {
        private readonly ISorteio _peopleRepository;
        public SorteioController(ISorteio peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            List<Pessoas> Usuarios = await _peopleRepository.GetPeople();

            List<Pessoas> Sorteados =  _peopleRepository.GetSorteio(Usuarios);

            if (Sorteados is null)
                return NotFound();

            return Ok(Sorteados);
        }

    }
}
