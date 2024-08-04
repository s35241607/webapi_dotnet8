using Microsoft.EntityFrameworkCore;
using webapi_dotnet8.Models;

namespace webapi_dotnet8.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserServer> UserServers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserChannelPermission> UserChannelPermissions { get; set; }
        public DbSet<ChannelType> ChannelTypes { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User 和 UserServer 的關係
            modelBuilder.Entity<UserServer>()
                .HasKey(us => new { us.UserId, us.ServerId });
            modelBuilder.Entity<UserServer>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserServers)
                .HasForeignKey(us => us.UserId);
            modelBuilder.Entity<UserServer>()
                .HasOne(us => us.Server)
                .WithMany(s => s.UserServers)
                .HasForeignKey(us => us.ServerId);

            // User 和 UserChannelPermission 的關係
            modelBuilder.Entity<UserChannelPermission>()
                .HasKey(ucp => new { ucp.UserId, ucp.ChannelId, ucp.PermissionId });
            modelBuilder.Entity<UserChannelPermission>()
                .HasOne(ucp => ucp.User)
                .WithMany(u => u.UserChannelPermissions)
                .HasForeignKey(ucp => ucp.UserId);
            modelBuilder.Entity<UserChannelPermission>()
                .HasOne(ucp => ucp.Channel)
                .WithMany(c => c.UserChannelPermissions)
                .HasForeignKey(ucp => ucp.ChannelId);
            modelBuilder.Entity<UserChannelPermission>()
                .HasOne(ucp => ucp.Permission)
                .WithMany(p => p.UserChannelPermissions)
                .HasForeignKey(ucp => ucp.PermissionId);

            // User 和 UserFriend 的關係
            modelBuilder.Entity<UserFriend>()
                .HasKey(uf => new { uf.UserId, uf.FriendId });
            modelBuilder.Entity<UserFriend>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.Friends)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // 其他模型配置
            modelBuilder.Entity<Channel>()
                .HasOne(c => c.Server)
                .WithMany(s => s.Channels)
                .HasForeignKey(c => c.ServerId);

            modelBuilder.Entity<Channel>()
                .HasOne(c => c.ChannelType)
                .WithMany(ct => ct.Channels)
                .HasForeignKey(c => c.ChannelTypeId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Channel)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChannelId);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<DirectMessage>()
                .HasOne(dm => dm.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(dm => dm.SenderId);
            modelBuilder.Entity<DirectMessage>()
                .HasOne(dm => dm.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(dm => dm.ReceiverId);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateTimeStamps();
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimeStamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimeStamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    entity.Property("CreatedAt").CurrentValue = now;
                }
                entity.Property("UpdatedAt").CurrentValue = now;
            }
        }
    }
}
