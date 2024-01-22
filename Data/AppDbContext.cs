using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "post.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");
        public IList<OrganizationEntity> GetOrganizationsWithPosts()//zmieniona nazwa
        {
            return Organizations
                .Include(o => o.Posts)
                .ToList();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            // dodanie roli administratora
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            // utworzenie administratora jako użytkownika
            var admin = new IdentityUser()
            {
                Id = ADMIN_ID,
                Email = "adam@adam.pl",
                EmailConfirmed = true,
                UserName = "adam@adam.pl",
                NormalizedUserName = "ADAM@ADAM.PL",
                NormalizedEmail = "ADAM@ADAM.PL",
            };
           
            // haszowanie hasła
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!");

            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);

            // przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address);

             modelBuilder.Entity<PostEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Posts)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>().HasData(
         new OrganizationEntity()
         {
             Id = 1,
             Title = "WSEI",
             Nip = "83492384",
             Regon = "13424234",
         },
         new OrganizationEntity()
         {
             Id = 2,
             Title = "Firma",
             Nip = "2498534",
             Regon = "0873439249",
         }

         );
            modelBuilder.Entity<Content>()
                .HasData
                (
                    new Content() { Id = 100, Title = "ASP.NET"},
                    new Content() { Id = 101, Title = "C# 10.0"},
                    new Content() { Id = 102, Title = "Java 19"}
                );
            modelBuilder.Entity<Author>()
                .HasData
                (
                    new Author() { Id = 201, Name = "Adam"},
                    new Author() { Id = 202, Name = "Karol"},
                    new Author() { Id = 203, Name = "Ewa"}
                );

            modelBuilder.Entity<Content>()
               .HasMany<Author>(b => b.Authors)
               .WithMany(a => a.Contents)
               .UsingEntity
               (
                 join => join.HasData
                 (
                     new { ContentsId = 101, AuthorsId = 201 },
                     new { ContentsId = 101, AuthorsId = 202 },
                     new { ContentsId = 102, AuthorsId = 201 }
                 )
                );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address)
                .HasData(
                    new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                    new { OrganizationEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" }
                );

            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity { Id = 1, Content = "Wojna na Ukrainie kwitnie", Author = "siergiej96", PublicationDate = DateTime.Now, Tags = "Tag1", Comment = "Comment 1" },
                new PostEntity { Id = 2, Content = "PIS wygrał wybory", Author = "Antoni Macierewicz", PublicationDate = DateTime.Now, Tags = "Tag2", Comment = "Comment 2" },
                new PostEntity { Id = 3, Content = "Barcelona na szczycie", Author = "maciek2006", PublicationDate = DateTime.Parse("2010-10-10"), Tags = "Tag3", Comment = "Comment 3" }
            );
        }
    }
}
