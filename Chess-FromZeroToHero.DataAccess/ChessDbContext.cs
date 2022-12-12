using Chess_FromZeroToHero.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions;

namespace Chess_FromZeroToHero.DataAccess
{
    public class ChessDbContext : DbContext
    {
        public ChessDbContext()
        {
        }

        public ChessDbContext(DbContextOptions<ChessDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.Property(x => x.Username).HasMaxLength(100).IsRequired();
                u.HasIndex(x => x.Username).IsUnique();
                u.Property(x => x.Password).IsRequired();
                u.Property(x => x.Name).HasMaxLength(300).IsRequired();
                u.Property(x => x.Age).IsRequired();
                u.Property(x => x.Rating).HasDefaultValue(1200).IsRequired();
            });

            modelBuilder.Entity<Position>(p =>
            {
                p.Property(x => x.FEN).HasMaxLength(100).IsRequired();
                p.Property(x => x.Turn).IsRequired();

                p.HasOne(x => x.Game).WithMany(x => x.Positions);
                p.HasOne(x => x.Puzzle).WithOne(x => x.Position).HasForeignKey<Puzzle>(x => x.PositionId);
            });

            modelBuilder.Entity<Game>(g =>
            {
                g.Property(x => x.TimeControl).IsRequired();
                g.Property(x => x.TimeIncrement).IsRequired();
                g.Property(x => x.Result).IsRequired();
                g.Property(x => x.WhiteUserId).IsRequired();
                g.Property(x => x.BlackUserId).IsRequired();
                g.Property(x => x.CreatedDate).IsRequired();
                g.Property(x => x.IsRated).IsRequired();

                g.HasOne(x => x.WhiteUser).WithMany(x => x.WhiteGames).HasForeignKey(x => x.WhiteUserId);
                g.HasOne(x => x.BlackUser).WithMany(x => x.BlackGames).HasForeignKey(x => x.BlackUserId);
            });

            modelBuilder.Entity<Puzzle>(p =>
            {
                p.Property(x => x.Rating).IsRequired();
                p.Property(x => x.Likes).HasDefaultValue(0).IsRequired();
                p.Property(x => x.Solution).HasMaxLength(1000).IsRequired();
                p.Property(x => x.PositionId).IsRequired();

                p.HasOne(x => x.Position).WithOne(x => x.Puzzle);
            });

            modelBuilder.Entity<UserPuzzle>(up =>
            {
                up.Property(x => x.IsSuccessful).IsRequired();
                up.Property(x => x.UserId).IsRequired();
                up.Property(x => x.PuzzleId).IsRequired();

                up.HasKey(x => new { x.UserId, x.PuzzleId });

                up.HasOne(x => x.User).WithMany(x => x.UserPuzzles);
                up.HasOne(x => x.Puzzle).WithMany(x => x.UserPuzzles);
            });
        }
    }
}
