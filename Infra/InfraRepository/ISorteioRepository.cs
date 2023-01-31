using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.InfraRepository
{
    public interface ISorteioRepository
    {
        Task<List<Pessoas>> Get();
    }
}
