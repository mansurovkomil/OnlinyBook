using OnlinyBook.Domain.Constants;

namespace OnlinyBook.Service.Common.Helpers
{
	public class TimeHelper
	{
		public static DateTime GetCurrentServerTime()
		{
			var date = DateTime.UtcNow;
			return date.AddDays(TimeConstants.UTC);
		}
	}
}
