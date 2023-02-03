using FluentValidation;
using TesteDesenvolvimento.Data.ApplicationModels;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Validations
{
    public class PedidoDeleteValidation : Validation<PedidoCreateRequestModel>
    {
        public PedidoDeleteValidation()
        {
        }
        public new bool IsValid(PedidoCreateRequestModel pedido)
        {
            EvaluateErrors(pedido);
            return ErrorsAreEmpty();
        }
       

        protected override List<PersistenceError> GetPersistenceValidations()
        {
            return new List<PersistenceError>
            {
            };
        }
    }
}
