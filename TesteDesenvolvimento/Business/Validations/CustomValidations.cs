using System.Text.RegularExpressions;

namespace TesteDesenvolvimento.Business.Validations
{
    public class CustomValidations
    {
        public static Regex GetDateRegex()
        {
            return new Regex(@"^(\d{4})-(\d{2})-(\d{2}$)");
        }

        public static Regex GetTimeRegex()
        {
            return new Regex(@"^([01][0-9]|2[0-3]):[0-5][0-9]$");
        }
        public static bool ValidateDatabaseId(int id)
        {
            return id > 0;
        }

        public static bool ValidateDatabaseIdString(string id)
        {
            int response = Convert.ToInt32(id);
            return response > 0;
        }

        public static bool ValidateDate(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return true;
            }

            if (!GetDateRegex().IsMatch(date))
            {
                return false;
            }

            try
            {
                Convert.ToDateTime(date);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
        public static bool IsInLengthInterval(int min, int max, string s)
        {
            if (s == null)
            {
                return true;
            }

            return s.Length <= max && s.Length >= min;
        }

    }
}
