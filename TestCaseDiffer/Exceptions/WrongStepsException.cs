using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.Exceptions
{
    public class WrongStepsException : Exception
    {
        public WrongStepsException()
        {
        }

        public WrongStepsException(string message) : base(message)
		{
        }

        public WrongStepsException(string message, Exception innerException) : base(message, innerException)
		{
        }
    }
}
