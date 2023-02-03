using FluentValidation;
using TesteDesenvolvimento.Data.ApplicationModels;
using TesteDesenvolvimento.Data.Models;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Validations
{
    public class ItemPedidoDeleteValidation : Validation<ItensPedidoCreateRequestModel>
    {
        public ItemPedidoDeleteValidation()
        {
        }
        public new bool IsValid(ItensPedidoCreateRequestModel itemPedido)
        {
            EvaluateErrors(itemPedido);
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
