using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace SolveIt.DataLayer.Configurations.Locations;
public class StateConfiguration : IEntityTypeConfiguration<State>
{
	public void Configure(EntityTypeBuilder<State> builder)
	{
		builder.ToTable("States");

		builder.HasKey(k => k.Id);
		builder.Property(p => p.Title).IsRequired(true).HasMaxLength(100);

		#region Relations
		builder.HasOne(u => u.Parent)
			.WithMany(a => a.Children)
			.HasForeignKey(a => a.ParentId)
			.OnDelete(DeleteBehavior.Restrict);


		builder.HasMany(s => s.UserCities)
			.WithOne(u => u.City)
			.HasForeignKey(u => u.CityId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(s => s.UserCountries)
			.WithOne(u => u.Country)
			.HasForeignKey(u => u.CountryId)
			.OnDelete(DeleteBehavior.Restrict);

		#endregion Relations
	}
}
