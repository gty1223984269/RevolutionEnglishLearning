using EnglishLearningDomain.Entities;
using EnglishLearningDomain.EntityConfigurations;
using EnglishLearningDomain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using EnglishLearningInfrastructure;

namespace EnglishLearning
{
    public class EnglishLearningDbContext : DbContext, IUnitOfWork
    {
        public EnglishLearningDbContext(
          DbContextOptions<EnglishLearningDbContext> options)
          : base(options)
        {

        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<WordRoots> WordRoots { get; set; }
        public DbSet<RelatedWords> RelatedWords { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await SaveChangesAsync(cancellationToken);
            return true;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AuditEntities();

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AdministratorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WordRootEntityTypeConfigrution());
            modelBuilder.ApplyConfiguration(new RelatedWordsEntityTypeConfiguration());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Replace table names
                entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();

                // Replace column names
                foreach (var property in entity.GetProperties())
                {
                    property.Relational().ColumnName = property.Name.ToSnakeCase();
                }

                foreach (var key in entity.GetKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.Relational().Name = index.Relational().Name.ToSnakeCase();
                }
            }
        }

        private void AuditEntities()
        {
            var userName = "none";
            var utcNow = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(e => e.CreatedBy).CurrentValue = userName;
                    entry.Property(e => e.CreatedDateTimeUtc).CurrentValue = utcNow;
                    entry.Property(e => e.UpdatedBy).CurrentValue = userName;
                    entry.Property(e => e.UpdatedDateTimeUtc).CurrentValue = utcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property(e => e.UpdatedBy).CurrentValue = userName;
                    entry.Property(e => e.UpdatedDateTimeUtc).CurrentValue = utcNow;
                }
            }
        }
    }
}
