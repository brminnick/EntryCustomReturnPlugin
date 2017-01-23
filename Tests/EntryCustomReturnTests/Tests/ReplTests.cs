using System;

using Xamarin.UITest;

using NUnit.Framework;

namespace EntryCustomReturnUITests
{
	public class ReplTests : BaseTest
	{
		public ReplTests(Platform platform) : base(platform)
		{
		}

		[Test]
		public void ReplTest()
		{
			App.Repl();
		}
	}
}
