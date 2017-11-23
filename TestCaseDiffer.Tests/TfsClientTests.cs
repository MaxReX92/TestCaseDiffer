using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.Tfs;

namespace TestCaseDiffer.Tests
{
	[TestClass]
	public class TfsClientTests
	{
		private ITfsSettings _settings;

		[TestInitialize]
		public void TestInitialize()
		{
			_settings = MockRepository.GenerateStub<ITfsSettings>();
			_settings.Stub(x => x.TfsConnection).Repeat.Any().Return("https://hqrndtfs.avp.ru/tfs");
		}

		//[TestMethod]
		public void GetWorkItemTest()
		{
			var client = new TfsApiClient(_settings);
			var workItem = client.GetTestCase(2441738);
		}
	}
}
