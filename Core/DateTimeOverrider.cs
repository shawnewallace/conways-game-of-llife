using System;

namespace Cgol.Core
{

	public class DateTimeOverrider : IDisposable
	{

		public DateTimeOverrider(DateTime overriddenTime)
		{
			DateTimeHelper.OverridenDateTime = overriddenTime;
		}

		public void Dispose()
		{
			DateTimeHelper.OverridenDateTime = null;
		}
	}
}