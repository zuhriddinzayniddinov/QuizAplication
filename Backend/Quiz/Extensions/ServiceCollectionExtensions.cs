using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
/*using Serilog;*/
using System.Text;
using Infrastructure.Repositories.Questions;
using Infrastructure.Repositories.Quizzes;
using QuizApplication.Application.Services.Authentication;
using QuizApplication.Application.Services.Questions;
using QuizApplication.Application.Services.Quizzes;
using QuizApplication.Application.Services.Users;
using QuizApplication.Domain.Enums;
using QuizApplication.Infrastructure.Authentication;
using QuizApplication.Infrastructure.Repositories.Users;

namespace QuizApplication.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContexts(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("SqlServer");

            services.Configure<JwtOption>(configuration
                .GetSection("JwtSettings"));

            services.AddSwaggerService();

            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("Temploy");

                /*options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure();
                });*/
            });

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IQuizzisServiceis, QuizzisServiceis>();
            services.AddScoped<IQuestionsServiceis,QuestionsServiceis>();
            services.AddHttpContextAccessor();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IJwtTokenHandler, JwtTokenHandler>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IQuizzesRepasitory,QuizzesRepasitory>();
            services.AddScoped<IQuestionRepository,QuestionRepository>();

            return services;
        }

        public static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserPolicy", authorizationPolicyBuilder =>
                {
                    authorizationPolicyBuilder.RequireRole(
                        UserRole.User.ToString(),
                        UserRole.Worker.ToString(),
                        UserRole.Maker.ToString(),
                        UserRole.Admin.ToString());
                });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }

        private static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AloShop.Api", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            });
        }

   /*     public static WebApplicationBuilder AddLogging(
            this WebApplicationBuilder builder,
            IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            return builder;
        }*/
}