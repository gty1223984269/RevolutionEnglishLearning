using EnglishLearningDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishLearningDomain.EntityConfigurations
{
    public class AdministratorEntityTypeConfiguration
      : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> entityBuilder)
        {
            entityBuilder.ToTable("administrators");

            entityBuilder.HasKey(a => a.Id);

            entityBuilder.Property(a => a.CreatedDateTimeUtc).IsRequired();
            entityBuilder.Property(a => a.CreatedBy);
            entityBuilder.Property(a => a.UpdatedDateTimeUtc).IsRequired();
            entityBuilder.Property(a => a.UpdatedBy);

            entityBuilder.Property(a => a.Email).IsRequired();
            entityBuilder.Property(a => a.NormalizedEmail).IsRequired();
            entityBuilder.Property(a => a.IsActive).IsRequired();
        }
    }
}