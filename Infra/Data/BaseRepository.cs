using Datas;

namespace Infra.Data
{
    public class BaseRepository<T>
    {
        protected SorteioContext Context { get; set; }

        public BaseRepository(SorteioContext context)
        {
            this.Context = context;
        }
    }
}
