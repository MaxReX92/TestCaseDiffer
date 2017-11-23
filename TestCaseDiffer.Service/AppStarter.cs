using Owin;
using System;

namespace TestCaseDiffer.Service
{
	public delegate IDisposable AppStarter(string url, Action<IAppBuilder> configure);
}
