using Microsoft.EntityFrameworkCore;
using DataAccesLayer.Models;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>()
                .HasOne(b => b.LentByUser)
                .WithMany(u => u.BooksLent)
                .HasForeignKey(b => b.LentByUserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookModel>()
            .HasOne(b => b.CurrentlyBorrowedByUser)
            .WithMany()
            .HasForeignKey(b => b.CurrentlyBorrowedById)
            .OnDelete(DeleteBehavior.SetNull);  


			modelBuilder.Entity<UserModel>().HasData(
			   new UserModel
			   {
				   Id = Guid.NewGuid().ToString(),
				   Name = "Priyesh Zope",
				   Username = "zopepriyesh",
				   Password = "Pzoistbpl@2001",
				   TokensAvailable = 10
			   },
			   new UserModel
			   {
				   Id = Guid.NewGuid().ToString(),
				   Name = "Demo User 1",
				   Username = "Demouser1",
				   Password = "Password",
				   TokensAvailable = 10
			   },
			   new UserModel
			   {
				   Id = Guid.NewGuid().ToString(),
				   Name = "Demo User 2",
				   Username = "DemoUser2",
				   Password = "Password",
				   TokensAvailable = 10
			   },
			   new UserModel
			   {
				   Id = Guid.NewGuid().ToString(),
				   Name = "Demo User 3",
				   Username = "DemoUser3",
				   Password = "password",
				   TokensAvailable = 10
			   }
		   );

			base.OnModelCreating(modelBuilder);
		}
	}
}
