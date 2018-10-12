using EnglishLearningDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishLearningDomain.EntityConfigurations
{
    public class WordRootEntityTypeConfigrution
        : IEntityTypeConfiguration<WordRoots>
    {
        public void Configure(EntityTypeBuilder<WordRoots> entityBuilder)
        {
            entityBuilder.ToTable("WordRoots");

            entityBuilder.HasKey(a => a.Id);

            entityBuilder.Property(a => a.CreatedDateTimeUtc).IsRequired();
            entityBuilder.Property(a => a.CreatedBy);
            entityBuilder.Property(a => a.UpdatedDateTimeUtc).IsRequired();
            entityBuilder.Property(a => a.UpdatedBy);
            entityBuilder.Property(a => a.Word).IsRequired();
            entityBuilder.Property(a => a.ChineseMeaning).IsRequired();
            entityBuilder.Property(a => a.IsActive).IsRequired();
        }
    }
}

