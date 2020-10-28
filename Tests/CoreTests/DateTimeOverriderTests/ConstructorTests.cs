using System;
using Cgol.Core;
using Xunit;

namespace Cgol.Tests.Core.DateTimeOverriderTests
{
	public class ConstructorTests
	{
		[Fact]
		public void it_updates_date_time_helper()
		{
			// clean up from other tests
			DateTimeHelper.OverridenDateTime = null;
			var notRealDate = new DateTime(1995, 8, 26);
			Assert.NotEqual(notRealDate, DateTimeHelper.Now);

			using (var overrider = new DateTimeOverrider(notRealDate))
			{
				var result = DateTimeHelper.Now;

				Assert.Equal(notRealDate, result);
			}
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