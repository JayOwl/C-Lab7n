using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLibrary.Business;
using BusinessLibrary.Common;
using BusinessLibrary.Data;

namespace BusinessLibrary.Business
{
    public class CustomerValidation
    {
        private static List<string> errors;

        public static string ErrorMessage
        {
            get
            {
                string result = "";

                foreach (string message in errors)
                {
                    result += message + "\r\n";
                }

                return result;
            }
        }

        static CustomerValidation()
        {
            errors = new List<string>();
        }

        public static CustomerCollection GetCustomers()
        {
            return CustomerRepository.GetCustomers();
        }

    }
}
