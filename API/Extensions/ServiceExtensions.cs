using Application.AdminServices.Implementations;
using Application.AdminServices.Interfaces;
using Application.AuthServices.Implementations;
using Application.AuthServices.Interfaces;
using Application.EvaluatorServices.Implementations;
using Application.EvaluatorServices.Interfaces;
using Application.Helpers.Configs;
using Application.SharedServices.Implementations;
using Application.SharedServices.Interfaces;
using Application.StudentServices.Implementations;
using Application.StudentServices.Interfaces;
using Domain.Models;
using Infrastructure.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensions;

public static class ServiceExtensions
{
    public static void RegisterDbContext
        (this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(ConstantVariables.ConnectionString)
        );
    }
    public static void AddIdentityServer(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole<int>>(options =>
        {
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
    }

    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<UserManager<User>>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEvaluationSessionService, EvaluationSessionService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IScoreboardService, ScoreboardService>();
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEvaluationService, EvaluationService>();
        services.AddScoped<IPdfExportService, PdfExportService>();
        services.AddScoped<IStudentDashboardService, StudentDashboardService>();
    }

    public static void ConfigureAuthServices(this IServiceCollection services)
    {

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(authenticationScheme: "Bearer", options =>
            {
                options.Authority = ConstantVariables.jwtIssuer;
                options.RequireHttpsMetadata = false; // Set to true in production
                options.Audience = ConstantVariables.jwtAudience;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = ConstantVariables.jwtIssuer,
                    ValidateAudience = true,
                    ValidAudience = ConstantVariables.jwtAudience,
                    ValidateIssuerSigningKey = true, // Ensure signature is validated
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(ConstantVariables.jwtKey)!))
                };
            });
    }
}
