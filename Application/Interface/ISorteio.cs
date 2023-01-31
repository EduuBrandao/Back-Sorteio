using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ISorteio
    {
        Task<List<Pessoas>> GetPessoas();

       List<Pessoas> GetSorteio(List<Pessoas> pessoas);

    }
}
