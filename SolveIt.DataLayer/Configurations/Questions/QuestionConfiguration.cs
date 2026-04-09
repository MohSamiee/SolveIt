using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SolveIt.DataLayer.Configurations.Accounts;
public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
	public void Configure(EntityTypeBuilder<Question> builder)
	{
		builder.ToTable("Questions", "qa");

		builder.HasKey(k => k.Id);
		builder.Property(p => p.Title).IsRequired(true).HasMaxLength(300);
		builder.Property(p => p.Content).IsRequired(true);
		builder.Property(p => p.ViewCount).HasDefaultValue(0);
		builder.Property(p => p.Score).HasDefaultValue(0);
	}
}
