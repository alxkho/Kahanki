using Duende.IdentityServer.EntityFramework.Options;
using Kahanki.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Kahanki.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<UserSettings> UserSettings { get; set; } = null!;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<UserMatchAction> UserMatchActions { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Chat> Chats { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserMatchAction>()
                .HasOne(c => c.ActedUser)
                .WithMany(c => c.OwnMatchActions)
                .HasForeignKey(c => c.ActedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<UserMatchAction>()
                .HasOne(c => c.TargetUser)
                .WithMany(c => c.TargetMatchActions)
                .HasForeignKey(c => c.TargetUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Message>()
                .HasOne(c => c.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(c => c.ChatId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Chat>()
                .HasMany(c => c.Users)
                .WithMany(c => c.Chats);
        }
    }
} 