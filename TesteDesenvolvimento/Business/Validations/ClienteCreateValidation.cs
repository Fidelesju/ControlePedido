using FluentValidation;
using TesteDesenvolvimento.Data.ApplicationModels;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Validations
{
    public class ClienteCreateValidation : Validation<ClienteCreateRequestModel>
    {
        public ClienteCreateValidation()
        {
            ValidateNome();
            ValidatePedidoId();
            ValidateEmail();
        }
        public new bool IsValid(ClienteCreateRequestModel cliente)
        {
            EvaluateErrors(cliente);
            return ErrorsAreEmpty();
        }
        private void ValidateNome()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(name => CustomValidations.IsInLengthInterval(3, 50, name))
                .WithMessage(DefaultErrorMessages.TextOutOfBounds(3, 50))
            ;
        }

        private void ValidatePedidoId()
        {
            RuleFor(cliente => cliente.PedidoId)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(CustomValidations.ValidateDatabaseId)
                .WithMessage(DefaultErrorMessages.InvalidId)
            ;
        }

        private void ValidateEmail()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(name => CustomValidations.IsInLengthInterval(3, 50, name))
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
