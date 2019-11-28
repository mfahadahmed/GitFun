//using GitFun.API.Models;
using GitFun.API.Models;
using GitFun.API.Models.SQLiteModels;
using GitFun.API.Repositories;
using GitFun.API.Repositories.SQLiteRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace GitFun.API
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
            services.Configure<GitFunDatabaseSettings>(Configuration.GetSection(
                nameof(GitFunDatabaseSettings)));
            services.AddSingleton<IGitFunDatabaseSettings>(
                sp => sp.GetRequiredService<IOptions<GitFunDatabaseSettings>>().Value);

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IRepoRepository, RepoRepository>();
            services.AddSingleton<IAuthRepository, AuthRepository>();

            services.AddDbContext<SQLiteDatabaseContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ISQLiteUsersRepository, SQLiteUsersRepository>();

            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
