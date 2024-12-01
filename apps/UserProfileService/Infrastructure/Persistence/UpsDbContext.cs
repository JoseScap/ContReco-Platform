using Microsoft.EntityFrameworkCore;
using UPS.Domain.Entities;

namespace UPS.Infrastructure.Persistence;

public class UpsDbContext(DbContextOptions<UpsDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserPreferences> Preferences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(x =>
        {
            // PKs, FKs and indexes
            x.HasKey(x => x.Id);
            x.HasIndex(x => x.UserName)
                .IsUnique();
            x.HasIndex(x => x.Email)
                .IsUnique();

            // Simple props
            x.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            x.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);
            x.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(50);
            x.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);
            x.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(1024);
            x.Property(x => x.Birthday)
                .IsRequired()
                .HasColumnType("date");

            // Timestamps
            x.Property(x => x.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("date");
            x.Property(x => x.ModifiedDate)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("date")
                .ValueGeneratedOnAddOrUpdate();
            
        });

        modelBuilder.Entity<UserPreferences>(x =>
        {
            // PKs, FKs and indexes
            x.HasKey(x => x.Id);

            x.Property(x => x.Tags)
                .IsRequired(false);

            // Timestamps
            x.Property(x => x.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("date");
            x.Property(x => x.ModifiedDate)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("date")
                .ValueGeneratedOnAddOrUpdate();
        });
    }
}
