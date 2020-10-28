using System;
using System.Runtime.InteropServices;

namespace Cgol.Core
{
  public static class DateTimeHelper
  {
    public static DateTime? OverridenDateTime { get; set; }

    public static DateTime Now
    {
      get
      {
        return OverridenDateTime ?? DateTime.Now;
      }
    }

    public static DateTime UtcNow
    {
      get
      {
        return OverridenDateTime == null ? DateTime.UtcNow : OverridenDateTime.Value.ToUniversalTime();
      }
    }

    public static DateTime ToEastern(this DateTime utcDateTime)
    {
      var isWindows = System.Runtime.InteropServices.RuntimeInformation
                                               .IsOSPlatform(OSPlatform.Windows);
      if (isWindows)
      {
        return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
      }
      return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.FindSystemTimeZoneById("US/Eastern"));
    }

    public static DateTime FromEasternToUTC(this DateTime easternDateTime)
    {
      var unspecifiedDate = DateTime.SpecifyKind(easternDateTime, DateTimeKind.Unspecified);

      var isWindows = System.Runtime.InteropServices.RuntimeInformation
                                               .IsOSPlatform(OSPlatform.Windows);
      if (isWindows)
      {
        return TimeZoneInfo.ConvertTimeToUtc(unspecifiedDate, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
      }
      return TimeZoneInfo.ConvertTimeToUtc(unspecifiedDate, TimeZoneInfo.FindSystemTimeZoneById("US/Eastern"));
    }

  }
}