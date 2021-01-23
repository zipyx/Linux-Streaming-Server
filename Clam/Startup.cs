using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clam.Repository;
using ClamDataLibrary.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using ClamDataLibrary.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Identity;
using Clam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using Clam.Areas.Identity.Pages.Account.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Clam.Areas.Clamflix.Models;
using Clam.Areas.Music.Models;
using Clam.Areas.EBooks.Models;
using Clam.Interface;

namespace Clam
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region IdentityAddedHere
            services.AddIdentity<ClamUserAccountRegister, ClamRoles>(options =>
            {
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<ClamUserAccountContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();
            #endregion

            services.AddDbContext<ClamUserAccountContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddTransient<ClamUserAccountContext>(); // ----------> Required to go with Database string
            services.AddScoped<UnitOfWork>(); // -------------------------> Repository Pattern with Controller
            services.AddScoped<UserAccountRegister>(); // ----------------> Added for Controller[Repository] Pattern
            services.AddAutoMapper(typeof(Startup)); // ------------------> Model Mapper Converter
            services.AddControllersWithViews(); // -----------------------> Default Stored in Core App Creation

            // ################################################################################################
            // ################################################################################################
            // ################################################################ Work With Claims

            services.AddAuthorization(options =>
            {
                // Group Permission Status/Types defining access level, lowest to highest
                // ----------------> All Role Access
                // ---|-----> Group Level Heirarchy Permission Sets
                // ---|-----> Clamflix
                // ---|-----> Book Library
                // ---|-----> Music Library
                options.AddPolicy("Level-One", policy => policy.RequireRole("Member", "Student",
                    "Contributor", "Moderator", "Admin", "Engineer", "Developer", "Owner")
                    .RequireAuthenticatedUser()
                );

                // -----------> Multi Segrated Level Permissions on Controllers
                options.AddPolicy("Level-Two", policy => policy.RequireRole("Contributor", "Moderator", "Admin", "Engineer", "Developer", "Owner")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Level-Three", policy => policy.RequireRole("Moderator", "Admin", "Engineer", "Developer", "Owner")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Level-Four", policy => policy.RequireRole("Admin", "Engineer", "Developer", "Owner")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Level-Five", policy => policy.RequireRole("Engineer", "Developer", "Owner")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Level-Six", policy => policy.RequireRole("Owner")
                    .RequireAuthenticatedUser()
                );

                // Permission Discriminators on Post Methods within controllers
                options.AddPolicy("Permission-Create", policy => policy.RequireClaim("10100313")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Permission-Update", policy => policy.RequireClaim("10100314")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Permission-Remove", policy => policy.RequireClaim("10100315")
                    .RequireAuthenticatedUser()
                );

                // Group Role & Policy Authorisation Model
                options.AddPolicy("Contributor-Access", policy => policy.RequireRole("Contributor", "Moderator", "Admin", "Engineer", "Developer", "Owner")
                    .RequireClaim("2000106224")
                    .RequireClaim("10100225")
                    .RequireAuthenticatedUser()
                );

                // Group Account/Role/Claim Authorisation Model
                options.AddPolicy("Account-Access", policy => policy.RequireRole("Admin", "Engineer", "Developer", "Owner")
                    .RequireClaim("2000106223")
                    .RequireClaim("10100233")
                    .RequireAuthenticatedUser()
                );

                // Group Role Authorisation Model
                options.AddPolicy("Role-Access", policy => policy.RequireRole("Engineer", "Developer", "Owner")
                    .RequireClaim("2000106221")
                    .RequireClaim("10100221")
                    .RequireAuthenticatedUser()
                );

                // Group Claim Authorisation Model
                options.AddPolicy("Claim-Access", policy => policy.RequireRole("Engineer", "Developer", "Owner")
                    .RequireClaim("2000106222")
                    .RequireClaim("10100229")
                    .RequireAuthenticatedUser()
                );

                // Group All Access
                options.AddPolicy("All-Access", policy => policy.RequireRole("Engineer", "Developer", "Owner")
                    .RequireClaim("2000106225")
                    .RequireAuthenticatedUser()
                );

                // Project Owner
                options.AddPolicy("Project-Owner", policy => policy.RequireRole("Owner")
                    .RequireClaim("10100314")
                    .RequireAuthenticatedUser()
                );

                // Account Policies
                options.AddPolicy("Account-Create", policy => policy.RequireClaim("10100234")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Account-Update", policy => policy.RequireClaim("10100235")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Account-Remove", policy => policy.RequireClaim("10100236")
                    .RequireAuthenticatedUser()
                );

                // Role Policies
                options.AddPolicy("Role-Create", policy => policy.RequireClaim("10100222")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Role-Update", policy => policy.RequireClaim("10100223")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Role-Remove", policy => policy.RequireClaim("10100224")
                    .RequireAuthenticatedUser()
                );

                // Claim Policies
                options.AddPolicy("Claim-Add", policy => policy.RequireClaim("10100230")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Claim-Update", policy => policy.RequireClaim("10100231")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Claim-Remove", policy => policy.RequireClaim("10100232")
                    .RequireAuthenticatedUser()
                );

                // Contributor|Content Policies
                options.AddPolicy("Contributor-Create", policy => policy.RequireClaim("10100226")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Contributor-Update", policy => policy.RequireClaim("10100227")
                    .RequireAuthenticatedUser()
                );
                options.AddPolicy("Contributor-Remove", policy => policy.RequireClaim("10100228")
                    .RequireAuthenticatedUser()
                );

                // All Access Policy Claim
                options.AddPolicy("All-Rights", policy => policy.RequireClaim("10100226")
                    .RequireAuthenticatedUser()
                );

            });

            // ################################################################################################
            // ################################################################################################
            // ################################################################# Stream File Models

            services.AddTransient<StreamFileUploadDatabase>();
            services.AddTransient<StreamFileData>();
            services.AddTransient<FormData>();
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = long.MaxValue;
            });
            // TV Show Section
            services.AddTransient<StreamTVShowFileUploadDatabase>();
            services.AddTransient<StreamFormData>();
            // Clamflix Area
            services.AddTransient<StreamFilmflixUpload>();
            services.AddTransient<StreamFormFilmflixData>();
            // Music Area
            services.AddTransient<StreamMusicDataUpload>();
            services.AddTransient<StreamFormDataMusic>();
            // Books Area
            services.AddTransient<StreamBooksDataUpload>();
            services.AddTransient<StreamFormDataBooks>();

            // ################################################################################################
            // ################################################################################################
            // ################################################################# Added Json Absolute File Paths
            var physicalProvider = new PhysicalFileProvider(Configuration.GetValue<string>("AcademiaStoredFilesC"));
            var absoluteBaseFileStorage = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteRootFilePathStore"));
            var locationAcademia = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Acad"));
            var locationTVShow = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Show"));
            var locationFlix = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Flix"));
            var locationMusic = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Music"));
            var locationBook = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Book"));
            var locationStorage = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Storage"));
            var locationProject = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Project"));
            services.AddSingleton<IFileProvider>(physicalProvider);
            services.AddSingleton<IFileProvider>(absoluteBaseFileStorage);
            services.AddSingleton<IFileProvider>(locationAcademia);
            services.AddSingleton<IFileProvider>(locationTVShow);
            services.AddSingleton<IFileProvider>(locationFlix);
            services.AddSingleton<IFileProvider>(locationMusic);
            services.AddSingleton<IFileProvider>(locationBook);
            services.AddSingleton<IFileProvider>(locationStorage);
            services.AddSingleton<IFileProvider>(locationProject);
            // ################################################################################################
            // ################################################################################################
            // ################################################################################################

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Manage");
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            services.AddSingleton<IEmailSender, EmailSender>();
            //----------------------------------------------------------------------------^
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // using Forwarded Headers for Linux Testing
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Test Status Code
            app.UseStatusCodePages();

            // Create Custom Route for data files outside of webroot path and contentPath
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "AppData")),
                RequestPath = "/AppData"
            });

            // TV-Shows
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Show")),
                RequestPath = "/AfpSData"
            });

            // Academia
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Acad")),
                RequestPath = "/AfpAData"
            });

            // Flix
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Flix")),
                RequestPath = "/AfpFData"
            });

            // Image
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Image")),
                RequestPath = "/AfpIData"
            });

            // Books
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Book")),
                RequestPath = "/AfpBData"
            });

            // Music
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Music")),
                RequestPath = "/AfpMData"
            });

            // Storage
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Storage")),
                RequestPath = "/AfpSData"
            });

            // Project
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("AbsoluteFilePath-Project")),
                RequestPath = "/AfpPData"
            });

            // Location for App.Routing originally placed here <---

            // #### Order Matters 1) Authentication, 2) Authorisation #### ==> When using Identity
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();

                // Academia
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaAcademia",
                    areaName: "Academia",
                    pattern: "academia/{controller=Home}/{action=Index}/{id?}"
                    );

                // Clamflix
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaClamflix",
                    areaName: "Clamflix",
                    pattern: "clamflix/{controller=Home}/{action=Index}/{id?}"
                    );

                // Music
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaMusic",
                    areaName: "Music",
                    pattern: "music/{controller=Home}/{action=Index}/{id?}"
                    );

                // Books
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaEBooks",
                    areaName: "EBooks",
                    pattern: "ebooks/{controller=Home}/{action=Index}/{id?}"
                    );

                // TV Shows
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaTVShows",
                    areaName: "TVShows",
                    pattern: "tvshows/{controller=Home}/{action=Index}/{id?}"
                    );

                // User Storage
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaStorage",
                    areaName: "Storage",
                    pattern: "storage/{controller=Home}/{action=Index}/{id?}"
                    );

                // Ticket System
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaTickets",
                    areaName: "Tickets",
                    pattern: "tickets/{controller=Home}/{action=Index}/{id?}"
                    );

                // Projects
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaProjects",
                    areaName: "Projects",
                    pattern: "projects/{controller=Home}/{action=Index}/{id?}"
                    );

                // Default Site Home
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
