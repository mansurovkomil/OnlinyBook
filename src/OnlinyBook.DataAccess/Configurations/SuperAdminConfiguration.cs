using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinyBook.Domain.Entities.Employees;

namespace OnlinyBook.DataAccess.Configurations
{
	public class SuperAdminConfiguration : IEntityTypeConfiguration<Administator>
	{
		public void Configure(EntityTypeBuilder<Administator> builder)
		{
			builder.HasData(new Administator()
			{
				Id = 1,
				FirstName = "System",
				LastName = "Admin",
				Email = "SystemAdmin@gmail.com",
				EmailConfirmed = true,
				IsHead = true,
				PhoneNumber = "+99897436861",
				PhoneNumberConfirmed = true,
				Money = 3000000,
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,
				Description = "This is super admin",
				ImagePath = "",
				PassportSeria = "AB",
				PassportNumber = 1345411,
				PasswordHash = "$2a$11$wflp2.VTsZmykmMsAydOa.iFXPipGum.T8d9bMa0wDKlfFV9hdbjS",
				Salt = "e036118f-34b1-4955-8cdf-057bce929bcb"
			});
		}
	}

}
