using System;
using Cgol.Core;
using Xunit;

namespace Cgol.Tests.Core.DateTimeHelperTests
{
	public class ConstructorTests
	{
		public ConstructorTests()
		{
			DateTimeHelper.OverridenDateTime = null;
		}

		[Fact]
		public void it_resets_when_disposed()
		{
			var notRealDate = new DateTime(1995, 8, 26);

			using (var overrider = new DateTimeOverrider(notRealDate))
			{
				var result = DateTimeHelper.Now;

				Assert.Equal(notRealDate, result);
			}
			Assert.NotEqual(notRealDate, DateTimeHelper.Now);
		}
	}
}
