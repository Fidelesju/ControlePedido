namespace TesteDesenvolvimento.Business.Validations
{
    public class DefaultErrorMessages
    {
        public const string RequiredField = "Campo obrigatório.";
        public const string InvalidDate = "Informe uma data válida.";
        public const string InvalidEmail = "Informe um email válido.";
        public const string InvalidId = "Informe um número inteiro maior que zero.";


        public static string TextOutOfBounds(int min, int max)
        {
            string t = $@"Esse campo deve conter entre {min} e {max} dígitos.";
            return t;
        }

        public static string NumberOutOfBounds(int min, int max)
        {
            return $@"Informe um número inteiro entre {min} e {max}";
        }

        public static string NumberGreaterOrEqualThan(int min)
        {
            return $@"Informe um número inteiro maior que {min} ";
        }
    }
}
