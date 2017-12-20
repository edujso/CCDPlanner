using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Data.Access;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;
using Data.Access.Repositories;

namespace CCDPlanner.Api
{
    public class Startup
    {
        IConfigurationRoot _config;
        private IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
             .AddEnvironmentVariables();

            _env = env;
            _config = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton(_config);

            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddCors();

            // Add services
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddDbContext<CCDPlannerDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging());

#region Identity
            // Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<CCDPlannerDBContext>()
                .AddDefaultTokenProviders();


            // Authentication
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"])),

                    ValidateIssuer = true,
                    ValidIssuer = _config["Tokens:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = _config["Tokens:Audience"],

                    ValidateLifetime = true, //validate the expiration and not before values in the token

                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            // Enable the use of an [Authorize("Bearer")] attribute on methods and classes to protect.
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

#endregion

            services.AddTransient<CCDPlannerDBContext>();
            services.AddTransient<DbIdentityInitializer>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            CCDPlannerDBContext dbContext,
            DbIdentityInitializer dbIdentityInitializer
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(b => b.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
            );

            // Set up custom content types -associating file extension to MIME type
            var provider = new FileExtensionContentTypeProvider();
            // Add new mappings
            provider.Mappings[".woff"] = "application/font-woff";

            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = provider
            });

            // Identity
            app.UseAuthentication();

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404
                && !Path.HasExtension(context.Request.Path.Value)
                && !context.Request.Path.Value.StartsWith("api"))
                {
                    string actualpath = "/index.html";

                    context.Request.Path = actualpath;
                    context.Response.StatusCode = 200;
                    await next();
                }
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            DbInitializer.Initialize(dbContext);
            dbIdentityInitializer.Seed().Wait();
        }
    }
}
