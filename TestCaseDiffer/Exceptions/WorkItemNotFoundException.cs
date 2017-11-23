using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.Exceptions
{
	public class WorkItemNotFoundException : Exception
	{
		public WorkItemNotFoundException()
		{
		}

		public WorkItemNotFoundException(string message) : base(message)
		{
		}

		public WorkItemNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
