using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TradeWise.Web.Models;

namespace TradeWise.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets para as entidades
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configurações da entidade User
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Balance).HasDefaultValue(10000m);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
            });

            // Configurações da entidade Asset
            builder.Entity<Asset>(entity =>
            {
                entity.HasIndex(e => e.Symbol).IsUnique();
                entity.HasIndex(e => e.CoinGeckoId).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
                entity.Property(e => e.LastUpdated).HasDefaultValueSql("NOW()");
            });

            // Configurações da entidade Order
            builder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.CreatedAt });
                entity.HasIndex(e => new { e.AssetId, e.Status });
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
                
                // Relacionamentos
                entity.HasOne(e => e.User)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(e => e.Asset)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.AssetId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Configurações da entidade Portfolio
            builder.Entity<Portfolio>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.AssetId }).IsUnique();
                entity.Property(e => e.FirstPurchaseAt).HasDefaultValueSql("NOW()");
                entity.Property(e => e.LastUpdated).HasDefaultValueSql("NOW()");
                
                // Relacionamentos
                entity.HasOne(e => e.User)
                    .WithMany(e => e.Portfolios)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(e => e.Asset)
                    .WithMany(e => e.Portfolios)
                    .HasForeignKey(e => e.AssetId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Configurações da entidade Transaction
            builder.Entity<Transaction>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.CreatedAt });
                entity.HasIndex(e => e.Type);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
                
                // Relacionamentos
                entity.HasOne(e => e.User)
                    .WithMany(e => e.Transactions)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(e => e.Order)
                    .WithMany(e => e.Transactions)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.NoAction);
                
                entity.HasOne(e => e.Asset)
                    .WithMany()
                    .HasForeignKey(e => e.AssetId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Configurações da entidade PriceHistory
            builder.Entity<PriceHistory>(entity =>
            {
                entity.HasIndex(e => new { e.AssetId, e.Timestamp, e.Interval });
                entity.HasIndex(e => e.Timestamp);
                
                // Relacionamentos
                entity.HasOne(e => e.Asset)
                    .WithMany(e => e.PriceHistories)
                    .HasForeignKey(e => e.AssetId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Seed data para ativos principais
            SeedAssets(builder);
        }

            private static void SeedAssets(ModelBuilder builder)
    {
        var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        builder.Entity<Asset>().HasData(
            new Asset
            {
                Id = 1,
                Symbol = "BTC",
                Name = "Bitcoin",
                Description = "A primeira e mais conhecida criptomoeda",
                CoinGeckoId = "bitcoin",
                CurrentPrice = 50000m,
                PreviousPrice = 49000m,
                IsActive = true,
                CreatedAt = seedDate,
                LastUpdated = seedDate
            },
            new Asset
            {
                Id = 2,
                Symbol = "ETH",
                Name = "Ethereum",
                Description = "Plataforma de contratos inteligentes",
                CoinGeckoId = "ethereum",
                CurrentPrice = 3000m,
                PreviousPrice = 2950m,
                IsActive = true,
                CreatedAt = seedDate,
                LastUpdated = seedDate
            },
            new Asset
            {
                Id = 3,
                Symbol = "ADA",
                Name = "Cardano",
                Description = "Blockchain sustentável e escalável",
                CoinGeckoId = "cardano",
                CurrentPrice = 1.20m,
                PreviousPrice = 1.15m,
                IsActive = true,
                CreatedAt = seedDate,
                LastUpdated = seedDate
            },
            new Asset
            {
                Id = 4,
                Symbol = "DOT",
                Name = "Polkadot",
                Description = "Protocolo de interoperabilidade entre blockchains",
                CoinGeckoId = "polkadot",
                CurrentPrice = 25m,
                PreviousPrice = 24m,
                IsActive = true,
                CreatedAt = seedDate,
                LastUpdated = seedDate
            }
        );
    }
    }
} 