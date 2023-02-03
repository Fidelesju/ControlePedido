using FluentValidation;
using TesteDesenvolvimento.Data.ApplicationModels;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Validations
{
    public class ItemPedidoCreateValidation : Validation<ItensPedidoCreateRequestModel>
    {
        public ItemPedidoCreateValidation()
        {
            ValidateNome();
            ValidateValorUnitario();
        }
        public new bool IsValid(ItensPedidoCreateRequestModel itensPedido)
        {
            EvaluateErrors(itensPedido);
            return ErrorsAreEmpty();
        }
        private void ValidateNome()
        {
            RuleFor(itensPedido => itensPedido.Nome)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(name => CustomValidations.IsInLengthInterval(3, 50, name))
                .WithMessage(DefaultErrorMessages.TextOutOfBounds(3, 50))
            ;
        }
        

        private void ValidateValorUnitario()
        {
            RuleFor(itensPedido => itensPedido.ValorUnitario)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .WithMessage(DefaultErrorMessages.InvalidId)
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
