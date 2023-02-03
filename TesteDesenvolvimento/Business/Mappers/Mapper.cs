using TesteDesenvolvimento.Business.Mappers.Interfaces;

namespace TesteDesenvolvimento.Business.Mappers
{
    public class Mapper <T> : IMapper<T>
    {
        protected T BaseMapping;

        public void SetBaseMapping(T baseMapping)
        {
            BaseMapping = baseMapping;
        }
    }
}
