using FluentValidation;
using TesteDesenvolvimento.Data.ApplicationModels;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Validations
{
    public class PedidoCreateValidation : Validation<PedidoCreateRequestModel>
    {
        public PedidoCreateValidation()
        {
            ValidateItemId();
        }
        public new bool IsValid(PedidoCreateRequestModel pedido)
        {
            EvaluateErrors(pedido);
            return ErrorsAreEmpty();
        }
        private void ValidateItemId()
        {
            RuleFor(pedido => pedido.ItemId)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .WithMessage(DefaultErrorMessages.TextOutOfBounds(3, 50))
            ;
        }

        protected override List<PersistenceError> GetPersistenceValidations()
        {
            return new List<PersistenceError>
            {
            };
        }
    }
}
