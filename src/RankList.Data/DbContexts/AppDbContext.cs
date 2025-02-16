using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RankList.Common.Models;
using RankList.Data.Models;

namespace RankList.Data.DbContexts;

internal class AppDbContext(DbContextOptions<AppDbContext> contextOptions, IOptions<ConnectionOptions> options, IHostingEnvironment env) : DbContext(contextOptions)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (env.IsDevelopment()) {
            builder.EnableSensitiveDataLogging();
            builder.EnableDetailedErrors();
        }
        
        builder.UseNpgsql(options.Value.ConnectionString, optionsBuilder =>
        {
            optionsBuilder.CommandTimeout(1);
        });
    }
    
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ItemTagMapping> ItemTagMappings { get; set; }

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
            
            builder.Property(x => x.CreatedOn)
                .HasMaxLength(3800)
                .IsUnicode();
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
            
            builder.Property(x => x.CreatedOn)
                .IsRequired();

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
        });

        modelBuilder.Entity<ItemTagMapping>(builder =>
        {
            builder.HasKey(x => x.ItemTagMappingId);
            
            builder.Property(x => x.CreatedOn)
                .IsRequired();
            
            builder.HasOne(x => x.Tag)
                .WithMany(x => ItemTagMappings)
                .HasForeignKey(x => x.TagId);

            builder.HasOne(x => x.Item)
                .WithMany(x => x.TagMappings)
                .HasForeignKey(x => x.ItemId);
        });
    }
}