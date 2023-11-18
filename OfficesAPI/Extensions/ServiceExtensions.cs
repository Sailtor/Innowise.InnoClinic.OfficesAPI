using Core.RepositoryInterfaces;
using FluentValidation;
using Infrastructure.Persistence.MongoDb;
using Infrastructure.Persistence.MongoDb.Configurations;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Options;
using OfficesAPI.Middleware;
using UseCases.PipelineBehaviors;

namespace OfficesAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();
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

        public static void ConfigureMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OfficesAPIDbSettings>(
                configuration.GetSection(nameof(OfficesAPIDbSettings)));

            services.AddSingleton<IOfficesAPIDbSettings>(provider =>
                provider.GetRequiredService<IOptions<OfficesAPIDbSettings>>().Value);
        }

        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UseCases.AssemblyReference).Assembly);
        }

        public static void CofigureAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer")
               .AddJwtBearer("Bearer", opt =>
               {
                   opt.RequireHttpsMetadata = false;
                   opt.Authority = configuration["AuthenticationAuthority"];
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

        #region Custom Middleware
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
        #endregion

    }
}
