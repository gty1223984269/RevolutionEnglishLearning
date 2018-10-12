using EnglishLearningDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishLearningDomain.EntityConfigurations
{
   public class RelatedWordsEntityTypeConfiguration : IEntityTypeConfiguration<RelatedWords>
    {
        public void Configure(EntityTypeBuilder<RelatedWords> entityBuilder)
        {
            entityBuilder.ToTable("relatedWords");

            entityBuilder.HasKey(a => a.Id);
            entityBuilder.Property(a => a.CreatedDateTimeUtc).IsRequired();
            entityBuilder.Property(a => a.CreatedBy);
            entityBuilder.Property(a => a.UpdatedDateTimeUtc).IsRequired();
            entityBuilder.Property(a => a.UpdatedBy);
            entityBuilder.Property(a => a.IsActive).IsRequired();
            entityBuilder.Property(a => a.RootId).IsRequired();
            entityBuilder.Property(a => a.Word).IsRequired();
            entityBuilder.Property(a => a.ChineseMeaning).IsRequired();
            entityBuilder.Property(a => a.RememberLogic).IsRequired();
        }
    }

}