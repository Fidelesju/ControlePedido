using FluentValidation;
using TesteDesenvolvimento.Data.ApplicationModels;
using TesteDesenvolvimento.Data.RequestModels;

namespace TesteDesenvolvimento.Business.Validations
{
    public class ClienteDeleteValidation : Validation<ClienteRequestModel>
    {
        public ClienteDeleteValidation()
        {
            ValidateClienteId();
        }
        public new bool IsValid(ClienteRequestModel cliente)
        {
            EvaluateErrors(cliente);
            return ErrorsAreEmpty();
        }
       
        private void ValidateClienteId()
        {
            RuleFor(cliente => cliente.ClienteId)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(CustomValidations.ValidateDatabaseId)
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
