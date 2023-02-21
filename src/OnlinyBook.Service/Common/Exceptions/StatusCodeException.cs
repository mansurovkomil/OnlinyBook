using System.Net;

namespace OnlinyBook.Service.Common.Exceptions
{
	public class StatusCodeException : Exception
	{
		public HttpStatusCode StatusCode { get; set; }

		public StatusCodeException(HttpStatusCode statusCode, string message)
			: base(message)
		{
			StatusCode = statusCode;
		}

	}
}
