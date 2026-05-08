using Escola.Application.Interfaces;
using Escola.Application.Services;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Escola.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Escola.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            services.AddScoped<INotaRepository, NotaRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ICursoServices, CursoService>();
            services.AddScoped<IMatriculaService, MatriculaService>();
            services.AddScoped<INotaService, NotaService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
