using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.Service.Properties;
using TestCaseDiffer.Tfs;

namespace TestCaseDiffer.Service.Configuration
{
	public class TfsSettings : ITfsSettings
	{
		public string TfsConnection => Settings.Default.TfsConnection;
	}
}
