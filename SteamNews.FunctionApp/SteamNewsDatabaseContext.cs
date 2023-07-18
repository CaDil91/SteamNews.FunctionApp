using System;
using Microsoft.EntityFrameworkCore;

namespace SteamNews.FunctionApp;

public class SteamNewsDatabaseContext : DbContext
{
    public SteamNewsDatabaseContext(DbContextOptions<SteamNewsDatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FollowedSteamApp>()
            .HasKey(followedSteamApp => followedSteamApp.AppId);
        
        modelBuilder.Entity<Webhook>()
            .HasKey(webhook => webhook.WebhookUrl);

        modelBuilder.HasDefaultSchema("SteamNews");
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<FollowedSteamApp> FollowedSteamApps { get; set; }

    public DbSet<Webhook> Webhooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SteamNewsDbConnectionString"));
}