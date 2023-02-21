﻿using Microsoft.AspNetCore.Http;

namespace OnlinyBook.Service.Common.Helpers
{
	public class HttpContextHelper
	{
		public static IHttpContextAccessor Accessor { get; set; }
		public static HttpResponse Response => Accessor.HttpContext.Response;

		public static IHeaderDictionary ResponseHeaders => Response.Headers;

		public static HttpContext HttpContext => Accessor?.HttpContext;
		public static long UserId => GetUserId();

		public static string UserRole => HttpContext?.User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
		private static long GetUserId()
		{
			long id;
			bool canParse = long.TryParse(HttpContext.User?.Claims.FirstOrDefault(p => p.Type == "Id")?.Value, out id);
			return canParse ? id : 0;
		}

		public static double UserMoney => GetUserMoney();
		private static double GetUserMoney()
		{
			double money;
			bool canParse = double.TryParse(HttpContext.User?.Claims.FirstOrDefault(p => p.Type == "Money")?.Value, out money);
			return canParse ? money : 10;
		}
	}
}
