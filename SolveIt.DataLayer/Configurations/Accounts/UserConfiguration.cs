using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace SolveIt.DataLayer.Configurations.Accounts;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users", "auth");

		builder.HasKey(k => k.Id);
		builder.Property(p => p.FirstName).IsRequired(false).HasMaxLength(200);
		builder.Property(p => p.LastName).IsRequired(false).HasMaxLength(200);
		builder.Property(p => p.Email).IsRequired(false).HasMaxLength(200);
		builder.Property(p => p.NormalizedEmail).IsRequired(false).HasMaxLength(200);
		builder.Property(p => p.EmailActivationCode).IsRequired(false).HasMaxLength(50);
		builder.Property(p => p.ExpireEmailActivationCode).IsRequired(false);
		builder.Property(p => p.IsEmailConfirmed).HasDefaultValue(false);
		builder.Property(p => p.HashedPassword).IsRequired(true);
		builder.Property(p => p.Mobile).IsRequired(false).HasMaxLength(20);
		builder.Property(p => p.MobileActivationCode).IsRequired(false).HasMaxLength(10);
		builder.Property(p => p.IsMobileConfirmed).HasDefaultValue(false);
		builder.Property(p => p.ExpireMobileActivationCode).IsRequired(false);
		builder.Property(p => p.MobileActivationCode).IsRequired(false).HasMaxLength(100);
		builder.Property(p => p.AccessFailedCount).HasDefaultValue(0);
		builder.Property(p => p.LastLoginTime).IsRequired(false);
		builder.Property(p => p.IsAdmin).HasDefaultValue(false);
	}
}
