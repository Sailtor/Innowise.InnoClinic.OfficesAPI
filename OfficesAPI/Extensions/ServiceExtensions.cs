using Core.Repositories;
using FluentMigrator.Runner;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Migrations;
using MassTransit;
using MediatR;
using OfficesAPI.Middleware;
using UseCases.PipelineBehaviors;

namespace OfficesAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void ConfigureEntityServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(UseCases.AssemblyReference).Assembly);
        }

        public static void ConfigureCQRSServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UseCases.AssemblyReference).Assembly));
        }

        public static void ConfigureDapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddSingleton<Database>();
            services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSqlServer2016()
                    .WithGlobalConnectionString(configuration.GetConnectionString("OfficesDb"))
                    .ScanIn(typeof(Infrastructure.Persistence.AssemblyReference).Assembly).For.Migrations());
        }

        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UseCases.AssemblyReference).Assembly);
        }

        public static void CofigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
               .AddJwtBearer("Bearer", opt =>
               {
                   opt.RequireHttpsMetadata = false;
                   opt.Authority = "https://localhost:5005";
                   opt.Audience = "offices";
               });
        }

        public static void CofigureExceptionHandlerMiddleware(this IServiceCollection services)
        {
            services.AddTransient<ExceptionHandlingMiddleware>();
        }

        public static void CofigureMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });
        }

        /* --- CUSTOM MIDDLEWARE --- */
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

    }
}
