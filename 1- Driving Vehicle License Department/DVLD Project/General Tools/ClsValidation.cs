using System;
using System.Text.RegularExpressions;

namespace DVLD_Project.General_Tools
{
    public class ClsValidation
    {
        public static bool ValidateEmail(string emailAddress)
        {

            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);

        }
        public static bool ValidateInteger(string Number)
        {

            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);

        }
        public static bool Validatedecimal(string Number)
        {

            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);

        }
        public static bool IsNumber(string Number)
        {

            return (ValidateInteger(Number) || Validatedecimal(Number));
        }

    }
}

