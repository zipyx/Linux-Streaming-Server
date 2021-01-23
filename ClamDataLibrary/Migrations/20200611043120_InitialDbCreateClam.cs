using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClamDataLibrary.Migrations
{
    public partial class InitialDbCreateClam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClamRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClamSectionAcademicCategories",
                columns: table => new
                {
                    AcademicId = table.Column<Guid>(nullable: false),
                    AcademicDisciplineTitle = table.Column<string>(maxLength: 50, nullable: false),
                    AcademicDisciplineDescription = table.Column<string>(maxLength: 100, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamSectionAcademicCategories", x => x.AcademicId);
                });

            migrationBuilder.CreateTable(
                name: "ClamSectionTVShowCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    Genre = table.Column<string>(maxLength: 50, nullable: false),
                    ItemPath = table.Column<string>(maxLength: 300, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamSectionTVShowCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 50, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<string>(maxLength: 20, nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    AcceptTermsAndConditions = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserBooksCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(maxLength: 30, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserBooksCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserFilmCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(maxLength: 30, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserFilmCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserMusicCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(maxLength: 30, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserMusicCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ClamRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClamRoleClaim_ClamRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ClamRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamSectionAcademicSubCategories",
                columns: table => new
                {
                    SubCategoryId = table.Column<Guid>(nullable: false),
                    SubCategoryTitle = table.Column<string>(maxLength: 50, nullable: false),
                    SubCategoryDescription = table.Column<string>(maxLength: 100, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    AcademicId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamSectionAcademicSubCategories", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_ClamSectionAcademicSubCategories_ClamSectionAcademicCategories_AcademicId",
                        column: x => x.AcademicId,
                        principalTable: "ClamSectionAcademicCategories",
                        principalColumn: "AcademicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamSectionTVShowSubCategories",
                columns: table => new
                {
                    TVShowId = table.Column<Guid>(nullable: false),
                    TVShowTitle = table.Column<string>(maxLength: 50, nullable: false),
                    ItemPath = table.Column<string>(maxLength: 300, nullable: false),
                    TVShowSeasonNumberTotal = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamSectionTVShowSubCategories", x => x.TVShowId);
                    table.ForeignKey(
                        name: "FK_ClamSectionTVShowSubCategories_ClamSectionTVShowCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ClamSectionTVShowCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamProjectInterestsImageDisplays",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 60, nullable: false),
                    ImageLocation = table.Column<string>(maxLength: 300, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamProjectInterestsImageDisplays", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_ClamProjectInterestsImageDisplays_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserBooks",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    ItemPath = table.Column<string>(maxLength: 300, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 300, nullable: false),
                    Size = table.Column<long>(nullable: false),
                    BookTitle = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(maxLength: 30, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserBooks", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_ClamUserBooks_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClamUserClaim_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserFilms",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(nullable: false),
                    ItemPath = table.Column<string>(maxLength: 300, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 300, nullable: false),
                    WallpaperPath = table.Column<string>(maxLength: 300, nullable: false),
                    UrlEmbeddedVideo = table.Column<string>(maxLength: 200, nullable: true),
                    Size = table.Column<long>(nullable: false),
                    FilmTitle = table.Column<string>(maxLength: 60, nullable: false),
                    Year = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<bool>(maxLength: 30, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserFilms", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_ClamUserFilms_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_ClamUserLogin_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserMusic",
                columns: table => new
                {
                    SongId = table.Column<Guid>(nullable: false),
                    ItemPath = table.Column<string>(maxLength: 300, nullable: false),
                    SongTitle = table.Column<string>(maxLength: 30, nullable: false),
                    SongArtist = table.Column<string>(maxLength: 30, nullable: false),
                    Size = table.Column<long>(nullable: false),
                    Status = table.Column<bool>(maxLength: 30, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserMusic", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_ClamUserMusic_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserPersonalCategoryItems",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(maxLength: 60, nullable: false),
                    ItemPath = table.Column<string>(maxLength: 300, nullable: false),
                    Size = table.Column<long>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserPersonalCategoryItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ClamUserPersonalCategoryItems_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserProjects",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 60, nullable: false),
                    Author = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: false),
                    ImageGifLocation = table.Column<string>(maxLength: 300, nullable: false),
                    Language = table.Column<string>(maxLength: 30, nullable: true),
                    GithubLink = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserProjects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_ClamUserProjects_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ClamUserRole_ClamRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ClamRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClamUserRole_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserSystemTickets",
                columns: table => new
                {
                    SystemTicketId = table.Column<Guid>(nullable: false),
                    TicketTitle = table.Column<string>(maxLength: 30, nullable: false),
                    TicketMessage = table.Column<string>(maxLength: 300, nullable: false),
                    TicketResponse = table.Column<string>(maxLength: 300, nullable: true),
                    TicketStatus = table.Column<string>(maxLength: 30, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DesignatedMember = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserSystemTickets", x => x.SystemTicketId);
                    table.ForeignKey(
                        name: "FK_ClamUserSystemTickets_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_ClamUserToken_ClamUserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "ClamUserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamSectionAcademicSubCategoryItems",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    ItemPath = table.Column<string>(maxLength: 250, nullable: true),
                    ItemTitle = table.Column<string>(maxLength: 60, nullable: true),
                    ItemDescription = table.Column<string>(maxLength: 100, nullable: true),
                    Size = table.Column<long>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    SubCategoryId = table.Column<Guid>(nullable: false),
                    AcademicId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamSectionAcademicSubCategoryItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ClamSectionAcademicSubCategoryItems_ClamSectionAcademicCategories_AcademicId",
                        column: x => x.AcademicId,
                        principalTable: "ClamSectionAcademicCategories",
                        principalColumn: "AcademicId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClamSectionAcademicSubCategoryItems_ClamSectionAcademicSubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "ClamSectionAcademicSubCategories",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamSectionTVShowSubCategorySeasons",
                columns: table => new
                {
                    SeasonId = table.Column<Guid>(nullable: false),
                    TVShowSeasonNumber = table.Column<int>(nullable: false),
                    ItemPath = table.Column<string>(maxLength: 300, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    TVShowId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamSectionTVShowSubCategorySeasons", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_ClamSectionTVShowSubCategorySeasons_ClamSectionTVShowCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ClamSectionTVShowCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClamSectionTVShowSubCategorySeasons_ClamSectionTVShowSubCategories_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "ClamSectionTVShowSubCategories",
                        principalColumn: "TVShowId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserBooksJoinCategories",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserBooksJoinCategories", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ClamUserBooksJoinCategories_ClamUserBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "ClamUserBooks",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClamUserBooksJoinCategories_ClamUserBooksCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ClamUserBooksCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserFilmJoinCategories",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserFilmJoinCategories", x => new { x.FilmId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ClamUserFilmJoinCategories_ClamUserFilmCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ClamUserFilmCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClamUserFilmJoinCategories_ClamUserFilms_FilmId",
                        column: x => x.FilmId,
                        principalTable: "ClamUserFilms",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamUserMusicJoinCategories",
                columns: table => new
                {
                    SongId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamUserMusicJoinCategories", x => new { x.SongId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ClamUserMusicJoinCategories_ClamUserMusicCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ClamUserMusicCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClamUserMusicJoinCategories_ClamUserMusic_SongId",
                        column: x => x.SongId,
                        principalTable: "ClamUserMusic",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClamSectionTVShowSubCategorySeasonItems",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    ItemPath = table.Column<string>(maxLength: 300, nullable: false),
                    ItemTitle = table.Column<string>(maxLength: 80, nullable: false),
                    Size = table.Column<long>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    SeasonId = table.Column<Guid>(nullable: false),
                    TVShowId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClamSectionTVShowSubCategorySeasonItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ClamSectionTVShowSubCategorySeasonItems_ClamSectionTVShowCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ClamSectionTVShowCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClamSectionTVShowSubCategorySeasonItems_ClamSectionTVShowSubCategorySeasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "ClamSectionTVShowSubCategorySeasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClamSectionTVShowSubCategorySeasonItems_ClamSectionTVShowSubCategories_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "ClamSectionTVShowSubCategories",
                        principalColumn: "TVShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClamProjectInterestsImageDisplays_UserId",
                table: "ClamProjectInterestsImageDisplays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamRoleClaim_RoleId",
                table: "ClamRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "ClamRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClamSectionAcademicSubCategories_AcademicId",
                table: "ClamSectionAcademicSubCategories",
                column: "AcademicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamSectionAcademicSubCategoryItems_AcademicId",
                table: "ClamSectionAcademicSubCategoryItems",
                column: "AcademicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamSectionAcademicSubCategoryItems_SubCategoryId",
                table: "ClamSectionAcademicSubCategoryItems",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamSectionTVShowSubCategories_CategoryId",
                table: "ClamSectionTVShowSubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamSectionTVShowSubCategorySeasonItems_CategoryId",
                table: "ClamSectionTVShowSubCategorySeasonItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamSectionTVShowSubCategorySeasonItems_SeasonId",
                table: "ClamSectionTVShowSubCategorySeasonItems",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamSectionTVShowSubCategorySeasonItems_TVShowId",
                table: "ClamSectionTVShowSubCategorySeasonItems",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamSectionTVShowSubCategorySeasons_CategoryId",
                table: "ClamSectionTVShowSubCategorySeasons",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamSectionTVShowSubCategorySeasons_TVShowId",
                table: "ClamSectionTVShowSubCategorySeasons",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "ClamUserAccount",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ClamUserAccount",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserBooks_UserId",
                table: "ClamUserBooks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserBooksJoinCategories_CategoryId",
                table: "ClamUserBooksJoinCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserClaim_UserId",
                table: "ClamUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserFilmJoinCategories_CategoryId",
                table: "ClamUserFilmJoinCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserFilms_UserId",
                table: "ClamUserFilms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserLogin_UserId",
                table: "ClamUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserMusic_UserId",
                table: "ClamUserMusic",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserMusicJoinCategories_CategoryId",
                table: "ClamUserMusicJoinCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserPersonalCategoryItems_UserId",
                table: "ClamUserPersonalCategoryItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserProjects_UserId",
                table: "ClamUserProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserRole_RoleId",
                table: "ClamUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClamUserSystemTickets_UserId",
                table: "ClamUserSystemTickets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClamProjectInterestsImageDisplays");

            migrationBuilder.DropTable(
                name: "ClamRoleClaim");

            migrationBuilder.DropTable(
                name: "ClamSectionAcademicSubCategoryItems");

            migrationBuilder.DropTable(
                name: "ClamSectionTVShowSubCategorySeasonItems");

            migrationBuilder.DropTable(
                name: "ClamUserBooksJoinCategories");

            migrationBuilder.DropTable(
                name: "ClamUserClaim");

            migrationBuilder.DropTable(
                name: "ClamUserFilmJoinCategories");

            migrationBuilder.DropTable(
                name: "ClamUserLogin");

            migrationBuilder.DropTable(
                name: "ClamUserMusicJoinCategories");

            migrationBuilder.DropTable(
                name: "ClamUserPersonalCategoryItems");

            migrationBuilder.DropTable(
                name: "ClamUserProjects");

            migrationBuilder.DropTable(
                name: "ClamUserRole");

            migrationBuilder.DropTable(
                name: "ClamUserSystemTickets");

            migrationBuilder.DropTable(
                name: "ClamUserToken");

            migrationBuilder.DropTable(
                name: "ClamSectionAcademicSubCategories");

            migrationBuilder.DropTable(
                name: "ClamSectionTVShowSubCategorySeasons");

            migrationBuilder.DropTable(
                name: "ClamUserBooks");

            migrationBuilder.DropTable(
                name: "ClamUserBooksCategories");

            migrationBuilder.DropTable(
                name: "ClamUserFilmCategories");

            migrationBuilder.DropTable(
                name: "ClamUserFilms");

            migrationBuilder.DropTable(
                name: "ClamUserMusicCategories");

            migrationBuilder.DropTable(
                name: "ClamUserMusic");

            migrationBuilder.DropTable(
                name: "ClamRoles");

            migrationBuilder.DropTable(
                name: "ClamSectionAcademicCategories");

            migrationBuilder.DropTable(
                name: "ClamSectionTVShowSubCategories");

            migrationBuilder.DropTable(
                name: "ClamUserAccount");

            migrationBuilder.DropTable(
                name: "ClamSectionTVShowCategories");
        }
    }
}
