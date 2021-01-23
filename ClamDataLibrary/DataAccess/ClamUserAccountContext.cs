using ClamDataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Caching.Memory;

namespace ClamDataLibrary.DataAccess
{
    public class ClamUserAccountContext : IdentityDbContext<ClamUserAccountRegister, ClamRoles, Guid, ClamUserClaim, ClamUserRole, ClamUserLogin, ClamRoleClaim, ClamUserToken>
    {
        public ClamUserAccountContext(DbContextOptions<ClamUserAccountContext> options) : base(options) { }


        public DbSet<ClamRoles> ClamRoles { get; set; }

        public DbSet<ClamSectionAcademicCategory> ClamSectionAcademicCategories { get; set; }

        public DbSet<ClamSectionAcademicSubCategory> ClamSectionAcademicSubCategories { get; set; }

        public DbSet<ClamSectionAcademicSubCategoryItem> ClamSectionAcademicSubCategoryItems { get; set; }

        public DbSet<ClamSectionTVShowSubCategory> ClamSectionTVShowSubCategories { get; set; }

        public DbSet<ClamSectionTVShowCategory> ClamSectionTVShowCategories { get; set; }

        public DbSet<ClamSectionTVShowSubCategorySeason> ClamSectionTVShowSubCategorySeasons { get; set; }

        public DbSet<ClamSectionTVShowSubCategorySeasonItem> ClamSectionTVShowSubCategorySeasonItems { get; set; }

        public DbSet<ClamUserAccountRegister> ClamUserAccountRegister { get; set; }

        public DbSet<ClamUserBooks> ClamUserBooks { get; set; }

        public DbSet<ClamUserBooksCategory> ClamUserBooksCategories { get; set; }

        public DbSet<ClamUserBooksJoinCategory> ClamUserBooksJoinCategories { get; set; }

        public DbSet<ClamUserClaim> ClamUserClaims { get; set; }

        public DbSet<ClamUserFilm> ClamUserFilms { get; set; }

        public DbSet<ClamUserFilmCategory> ClamUserFilmCategories { get; set; }

        public DbSet<ClamUserFilmJoinCategory> ClamUserFilmJoinCategories { get; set; }

        public DbSet<ClamUserMusic> ClamUserMusic { get; set; }

        public DbSet<ClamUserMusicCategory> ClamUserMusicCategories { get; set; }

        public DbSet<ClamUserMusicJoinCategory> ClamUserMusicJoinCategories { get; set; }

        public DbSet<ClamUserPersonalCategoryItem> ClamUserPersonalCategoryItems { get; set; }

        public DbSet<ClamUserRole> ClamUserRoles { get; set; }

        public DbSet<ClamUserSystemTicket> ClamUserSystemTickets { get; set; }

        public DbSet<ClamUserProjects> ClamUserProjects { get; set; }

        public DbSet<ClamProjectInterestsImageDisplay> ClamProjectInterestsImageDisplays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ####################################################### Custom Aspnet Identity Configuration

            modelBuilder.Entity<ClamUserAccountRegister>(b =>
            {
                b.ToTable("ClamUserAccount");
                b.Property(u => u.UserName).HasMaxLength(50);
                b.Property(u => u.NormalizedUserName).HasMaxLength(50);
                b.Property(u => u.Email).HasMaxLength(50);
                b.Property(u => u.NormalizedEmail).HasMaxLength(50);

            });

            modelBuilder.Entity<ClamUserToken>(b =>
            {
                b.ToTable("ClamUserToken");
                b.Property(u => u.LoginProvider).HasMaxLength(100);
                b.Property(u => u.Name).HasMaxLength(50);
            });

            // ClamRoles
            modelBuilder.Entity<ClamRoles>(b =>
            {
                b.ToTable("ClamRoles");

                // Each Role can have many entries in the User Role
                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(k => k.RoleId)
                .IsRequired();

                // Each Role can have many associated claims
                b.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(k => k.RoleId)
                .IsRequired();
            });

            // ClamUserClaim
            modelBuilder.Entity<ClamUserClaim>(b =>
            {
                b.ToTable("ClamUserClaim");
            });

            // ClamUserRole
            modelBuilder.Entity<ClamUserRole>(b =>
            {
                b.ToTable("ClamUserRole");
            });

            // ClamUserLogin
            modelBuilder.Entity<ClamUserLogin>(b =>
            {
                b.ToTable("ClamUserLogin");
            });

            // ClamRoleClaim
            modelBuilder.Entity<ClamRoleClaim>(b =>
            {
                b.ToTable("ClamRoleClaim");
            });

            // --------------------------------------------- Custom Table Names End Here

            // ClamUserAccount, User can have many objects
            modelBuilder.Entity<ClamUserAccountRegister>(b =>
            {

                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                .WithOne(e => e.User)
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                .WithOne(e => e.User)
                .HasForeignKey(k => k.UserId)
                .IsRequired();

                // Each User can have many User Tokens
                b.HasMany(e => e.Tokens)
                .WithOne(ut => ut.User)
                .HasForeignKey(fk => fk.UserId)
                .IsRequired();

                // Each User can have man User Books
                b.HasMany(e => e.ClamUserBooks)
                .WithOne(k => k.User)
                .HasForeignKey(k => k.UserId)
                .IsRequired();

                // Each User can have many Films
                b.HasMany(e => e.ClamUserFilms)
                .WithOne(k => k.User)
                .HasForeignKey(f => f.UserId)
                .IsRequired();

                // Each User can have many Songs
                b.HasMany(e => e.ClamUserMusics)
                .WithOne(k => k.User)
                .HasForeignKey(k => k.UserId)
                .IsRequired();

                // Each User can have many Personal Category Items
                b.HasMany(e => e.ClamUserPersonalCategoryItems)
                .WithOne(k => k.User)
                .HasForeignKey(k => k.UserId)
                .IsRequired();

                // Each User can have many projects to display : 12m
                b.HasMany(e => e.ClamUserProjects)
                .WithOne(k => k.User)
                .HasForeignKey(k => k.UserId)
                .IsRequired();

                // Each User can have many Image interests to display : 12m
                b.HasMany(e => e.ClamProjectInterestsImageDisplays)
                .WithOne(k => k.User)
                .HasForeignKey(k => k.UserId)
                .IsRequired();

                // Each User can have many System Tickets
                b.HasMany(e => e.ClamUserSystemTickets)
                .WithOne(k => k.User)
                .HasForeignKey(k => k.UserId)
                .IsRequired();

            });
            // ####################################################### Custom Identity Configuration Ends Here ^

            // #####################################################
            // ################## --> Below is Custom Default models 
            // ################## --> containing all models without
            // ################## --> Identity Models above.
            // #####################################################

            //// ###############################################################Start Section Academic Category --> 12M
            modelBuilder.Entity<ClamSectionAcademicCategory>(b =>
            {
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
                b.Property(x => x.DateAdded).IsRequired(true).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ClamSectionAcademicCategory>()
                .HasMany(ac => ac.ClamSectionAcademicSubCategories)
                .WithOne(k => k.ClamSectionAcademicCategory)
                .HasForeignKey(k => k.AcademicId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClamSectionAcademicCategory>()
                .HasMany(ac => ac.ClamSectionAcademicSubCategoryItems)
                .WithOne(k => k.ClamSectionAcademicCategory)
                .HasForeignKey(k => k.AcademicId)
                .OnDelete(DeleteBehavior.ClientCascade);
            //// End Section Academic Category Here -->

            //// #############################################################Start Section Academic Sub Category --> 12M
            modelBuilder.Entity<ClamSectionAcademicSubCategory>(b =>
            {
                b.Property(x => x.DateAdded).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ClamSectionAcademicSubCategoryItem>(b =>
            {
                b.Property(x => x.DateAdded).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ClamSectionAcademicSubCategory>()
                .HasMany(asc => asc.ClamSectionAcademicSubCategoryItems)
                .WithOne(k => k.ClamSectionAcademicSubCategory)
                .HasForeignKey(k => k.SubCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            //// End Section Academic Sub Category Here -->

            //// ###########################################################Start Section TVShow Category --> 12M
            modelBuilder.Entity<ClamSectionTVShowCategory>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ClamSectionTVShowCategory>()
                .HasMany(tvc => tvc.ClamSectionTVShowSubCategories)
                .WithOne(k => k.ClamSectionTVShowCategory)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClamSectionTVShowCategory>()
                .HasMany(tvc => tvc.ClamSectionTVShowSubCategorySeasons)
                .WithOne(k => k.ClamSectionTVShowCategory)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClamSectionTVShowCategory>()
                .HasMany(tvc => tvc.ClamSectionTVShowSubCategorySeasonItems)
                .WithOne(k => k.ClamSectionTVShowCategory)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.ClientCascade);
            //// End Section TV show Category

            //// ########################################################Start Section TV Show Items --> 12M
            modelBuilder.Entity<ClamSectionTVShowSubCategory>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ClamSectionTVShowSubCategorySeason>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ClamSectionTVShowSubCategorySeasonItem>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ClamSectionTVShowSubCategory>()
                .HasMany(tvsc => tvsc.ClamSectionTVShowSubCategorySeasonItems)
                .WithOne(k => k.ClamSectionTVShowSubCategory)
                .HasForeignKey(k => k.TVShowId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClamSectionTVShowSubCategory>()
                .HasMany(tvsc => tvsc.ClamSectionTVShowSubCategorySeasons)
                .WithOne(k => k.ClamSectionTVShowSubCategory)
                .HasForeignKey(k => k.TVShowId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ClamSectionTVShowSubCategorySeason>()
                .HasMany(tvsc => tvsc.ClamSectionTVShowSubCategorySeasonItems)
                .WithOne(k => k.ClamSectionTVShowSubCategorySeason)
                .HasForeignKey(k => k.SeasonId)
                .OnDelete(DeleteBehavior.ClientCascade);
            //// End Section TV Show Items

            //// Start Music Here --> 
            modelBuilder.Entity<ClamUserMusic>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ClamUserMusicCategory>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });
            //// Ends Here

            //// Start User Books Here --> 12M

            modelBuilder.Entity<ClamUserBooksCategory>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ClamUserBooks>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });
            //// End User Books -->

            // User Films Category
            modelBuilder.Entity<ClamUserFilmCategory>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ClamUserFilm>(b =>
            {
                b.Property(x => x.DateAdded).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            // Film Many to Many Relationship
            modelBuilder.Entity<ClamUserFilmJoinCategory>()
                .HasKey(fj => new { fj.FilmId, fj.CategoryId });

            modelBuilder.Entity<ClamUserFilmJoinCategory>()
                .HasOne(k => k.ClamUserFilm)
                .WithMany(p => p.ClamUserFilmJoinCategories)
                .HasForeignKey(fk => fk.FilmId);

            modelBuilder.Entity<ClamUserFilmJoinCategory>()
                .HasOne(k => k.ClamUserFilmCategory)
                .WithMany(p => p.ClamUserFilmJoinCategories)
                .HasForeignKey(fk => fk.CategoryId);

            // Music Many to Many Relationship
            modelBuilder.Entity<ClamUserMusicJoinCategory>()
                .HasKey(ck => new { ck.SongId, ck.CategoryId });

            modelBuilder.Entity<ClamUserMusicJoinCategory>()
                .HasOne(k => k.ClamUserMusic)
                .WithMany(p => p.ClamUserMusicJoinCategories)
                .HasForeignKey(fk => fk.SongId);

            modelBuilder.Entity<ClamUserMusicJoinCategory>()
                .HasOne(k => k.ClamUserMusicCategory)
                .WithMany(p => p.ClamUserMusicJoinCategories)
                .HasForeignKey(fk => fk.CategoryId);

            // Books Many to Many Relationship
            modelBuilder.Entity<ClamUserBooksJoinCategory>()
                .HasKey(ck => new { ck.BookId, ck.CategoryId });

            modelBuilder.Entity<ClamUserBooksJoinCategory>()
                .HasOne(k => k.ClamUserBooks)
                .WithMany(p => p.ClamUserBooksJoinCategories)
                .HasForeignKey(fk => fk.BookId);

            modelBuilder.Entity<ClamUserBooksJoinCategory>()
                .HasOne(k => k.ClamUserBooksCategory)
                .WithMany(p => p.ClamUserBooksJoinCategories)
                .HasForeignKey(fk => fk.CategoryId);

            // Personal Category ID
            modelBuilder.Entity<ClamUserPersonalCategoryItem>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            // Projects
            modelBuilder.Entity<ClamUserProjects>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            // Projects Image Interests
            modelBuilder.Entity<ClamProjectInterestsImageDisplay>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            // ###################################################################################
            // ########################################### Ticket System
            modelBuilder.Entity<ClamUserSystemTicket>(b =>
            {
                b.Property(x => x.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
                b.Property(x => x.LastModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
                b.Property(x => x.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
                b.Property(x => x.LastModified).Metadata.SetDefaultValueSql("getdate()");
            });

            //modelBuilder.Entity<ClamUserSystemTicket>()
            //    .Property(x => x.TicketStatus)
            //    .HasConversion(
            //    x => x.ToString(),
            //    x => (TicketStatus)Enum.Parse(typeof(TicketStatus), x));
        }
    }
}