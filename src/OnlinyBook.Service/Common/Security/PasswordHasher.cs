namespace OnlinyBook.Service.Common.Security
{
	public class PasswordHasher
	{
		public static (string passwordHash, string salt) Hash(string password)
		{
			string salt = Guid.NewGuid().ToString();
			string passwordHash = BCrypt.Net.BCrypt.HashPassword(salt + password);
			return (passwordHash, salt);
		}

		public static bool Verify(string password, string salt, string passwordHash)
		{
			return BCrypt.Net.BCrypt.Verify(salt + password, passwordHash);
		}

		public static string ChangePassword(string password, string salt)
		{
			return BCrypt.Net.BCrypt.HashPassword(salt + password);
		}

		private static string GenerateSalt()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
