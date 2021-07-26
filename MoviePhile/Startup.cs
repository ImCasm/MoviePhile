using ApiNetCore.Filter;
using ApiNetCore.Middlewares;
using Application.Auth;
using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.HttpClient;
using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Application.Services;
using Application.Services.Auth;
using Domain.Common.Mapping;
using Domain.Entities;
using Infrastructure.MoviesDataClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Repositories;
using System;
using System.Text;

namespace MoviePhile
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            // Get JwtConfig Section from appsettings.json
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            // Conf EF with SQL Server
            services.AddDbContext<MoviePhileDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("AzureConnection")
            ));

            #region autenticación
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
                    IssuerSigningKey = new SymmetricSecurityKey(key), // Add the secret key to our Jwt encryption
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });
            #endregion

            services
               .AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<MoviePhileDbContext>();

            #region Inyeccion de repositorios
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommunityRepository, CommunityRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IScoreRepository, ScoreRepository>();
            //filmcomment
            services.AddScoped<IFilmCommentRepository, FilmCommentRepository>();
            services.AddScoped<IAdvertisingRepository, AdvertisingRepository>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();
            #endregion

            #region Inyeccion de servicios
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IHttpMovieClientService, HttpMovieClientService>();
            services.AddScoped<ICommunityService, CommunityService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ISerieService, SerieService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IAdvertisingService, AdvertisingService>();
            services.AddScoped<IFilmCommentService, FilmCommentService>();

            //Publicationservice
            services.AddScoped<IPublicationService, PublicationService>();

            //ScoreService
            services.AddScoped<IScoreService, ScoreService>();
            services.AddScoped<IPaymentsService, PaymentsTestService>();
            #endregion

            services.AddControllers();

            services.AddMvc(opt =>
            {
                opt.Filters.Add<ValidationFilter>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoviePhile", Version = "v1" });
            });

            services.AddHttpClient<IHttpMovieClient, HttpDataClient>(c =>
            {
                string uri = "https://api.themoviedb.org/3/";
                c.BaseAddress = new Uri(uri);
            });

            // Mapping for DTOs
            services.AddAutoMapper(c => c.AddProfile<MappingProfile>(), typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoviePhile v1"));
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
