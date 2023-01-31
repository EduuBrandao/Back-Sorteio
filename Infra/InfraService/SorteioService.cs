using AutoMapper;
using Datas;
using Datas.datas;
using Domain.Entidades;
using Infra.Data;
using Infra.InfraRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.InfraService
{
    public class SorteioService : BaseRepository<PessoasConfig> , ISorteioRepository
    {
        private readonly IMapper _mapper;
        public SorteioService(SorteioContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<Pessoas>> Get()
        {
            var document =  Context.DadosClientes.ToList();

            return Mapper<List<Pessoas>>(document);
        }

        protected T Mapper<T>(Object data)
        {
            return _mapper.Map<T>(data);
        }
    }
}
