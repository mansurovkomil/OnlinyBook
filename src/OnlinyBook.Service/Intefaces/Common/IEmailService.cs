using OnlinyBook.Service.Dtos.Common;

namespace OnlinyBook.Service.Intefaces.Common
{
	public interface IEmailService
	{
		public Task<bool> SendAsync(EmailMessage emailMessage);
	}
}
