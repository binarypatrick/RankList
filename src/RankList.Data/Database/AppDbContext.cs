using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RankList.Common.Models;
using RankList.Data.Models;

namespace RankList.Data.Database;

public class AppDbContext(
    DbContextOptions<AppDbContext> contextOptions,
    ConnectionOptions options,
    IWebHostEnvironment env) : DbContext(contextOptions)
{
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ItemTagMapping> ItemTagMappings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (env.IsDevelopment())
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

        optionsBuilder.UseNpgsql(options.ConnectionString, dbOptions => { dbOptions.CommandTimeout(1); });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(builder =>
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Username)
                .HasMaxLength(500)
                .IsUnicode()
                .IsRequired();
            
            builder.Property(x => x.Email)
                .HasMaxLength(200)
                .IsUnicode()
                .IsRequired();
            
            builder.Property(x => x.Hash)
                .HasMaxLength(300)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.CreatedOn)
                .HasMaxLength(3800)
                .IsUnicode();
            
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
        });

        modelBuilder.Entity<Item>(builder =>
        {
            builder.HasKey(x => x.ItemId);

            builder.Property(x => x.Name)
                .HasMaxLength(500)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(3800)
                .IsUnicode();
            
            builder.Property(x => x.Url)
                .HasMaxLength(2000)
                .IsUnicode();

            builder.Property(x => x.AverageRating)
                .HasPrecision(4, 2);

            builder.Property(x => x.CreatedOn)
                .IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasIndex(x => x.Url).IsUnique();
            builder.HasIndex(x => x.AverageRating);

            builder.HasOne<User>(x => x.Creator)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.CreatedBy);
        });

        modelBuilder.Entity<Review>(builder =>
        {
            builder.HasKey(x => x.ReviewId);

            builder.Property(x => x.Notes)
                .HasMaxLength(2000)
                .IsUnicode();

            builder.Property(x => x.Rating)
                .HasPrecision(4, 2)
                .IsRequired();

            builder.Property(x => x.CreatedOn)
                .IsRequired();

            builder.HasIndex(x => new { x.CreatedBy, x.ItemId }).IsUnique();
            builder.HasIndex(x => x.ItemId);

            builder.HasOne<User>(x => x.Creator)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.CreatedBy);

            builder.HasOne<Item>(x => x.Item)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ItemId);
        });

        modelBuilder.Entity<Tag>(builder =>
        {
            builder.HasKey(x => x.TagId);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CreatedOn)
                .IsRequired();
            
            builder.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<ItemTagMapping>(builder =>
        {
            builder.HasKey(x => x.ItemTagMappingId);

            builder.Property(x => x.CreatedOn)
                .IsRequired();
            
            builder.HasIndex(x => new { x.ItemId, x.TagId })
                .IsUnique();
            
            builder.HasOne(x => x.Tag)
                .WithMany(x => x.ItemMappings)
                .HasForeignKey(x => x.TagId);

            builder.HasOne(x => x.Item)
                .WithMany(x => x.TagMappings)
                .HasForeignKey(x => x.ItemId);
        });
    }
}