using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.Exceptions
{
    class WorkItemTypeException : Exception
    {
        public WorkItemTypeException()
        {
        }

        public WorkItemTypeException(string message) : base(message)
		{
        }

        public WorkItemTypeException(string message, Exception innerException) : base(message, innerException)
		{
        }
    }
}
