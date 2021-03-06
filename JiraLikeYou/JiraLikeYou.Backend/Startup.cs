using JiraLikeYou.DAL.Repositories;
using JiraLikeYou.Backend.Hubs;
using JiraLikeYou.Backend.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using JiraLikeYou.BLL.Integration;
using JiraLikeYou.BLL.Mappers;
using JiraLikeYou.BLL.Services;
using JiraLikeYou.BLL.Validators;
using JiraLikeYou.DAL;
using JiraLikeYou.DAL.Repositories.Common;
using Microsoft.AspNetCore.Http;

namespace JiraLikeYou.Backend
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
            //Need for SignalR(need some investigaion about CORS for security reasons)
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:52001", "http://uk-osa-01:52001");
            }));
            services.AddControllers().AddNewtonsoftJson();
            services.AddSignalR();
            ConfigureContainer(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                context.Request.EnableBuffering();
                await next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<OccasionHub>("/occasionHub");
            });

            AutoMigrateDatabase(app);

        }

        private void ConfigureContainer(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(
                options => options.UseSqlite(Configuration.GetConnectionString("Db")
            ));


            AddClients(services);
            AddMappers(services);
            AddServices(services);
            AddRepositories(services);
            AddValidators(services);
        }

        private void AddValidators(IServiceCollection services)
        {
            services.AddSingleton<IStatusValidator, StatusValidator>();
            services.AddSingleton<IPriorityValidator, PriorityValidator>();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IConfigRepository, ConfigRepository>();
            services.AddTransient<IOccasionRepository, OccasionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<IPriorityRepository, PriorityRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private void AddClients(IServiceCollection services)
        {
            services.AddTransient<IJiraClient, JiraClient>();
            services.AddTransient<IUiClient, UiClient>();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddTransient<IOccasionCardBuilder, OccasionCardBuilder>();
            services.AddTransient<IUserUpdater, UserUpdater>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IOccasionHandler, OccasionHandler>();
        }

        private void AddMappers(IServiceCollection services)
        {
            services.AddTransient<OccasionSmallCardMapper>();
            services.AddTransient<OccasionFullCardMapper>();
            services.AddTransient<UserMapper>();
            
            services.AddTransient<OccasionMapper>();
            services.AddTransient<OccasionTypeMapper>();
            services.AddTransient<TriggerMapper>();
            services.AddTransient<PatternForOccasionMapper>();
            services.AddTransient<PatternForTriggerMapper>();
            services.AddTransient<JiraWebhookResponseMapper>();

            services.AddScoped<IStatusMapper, StatusMapper>();
            services.AddScoped<IPriorityMapper, PriorityMapper>();
            services.AddScoped<IPriorityDtoMapper, PriorityDtoMapper>();
            services.AddScoped<IStatusDtoMapper, StatusDtoDtoMapper>();
            services.AddTransient<ITicketMapper,TicketMapper>();
        }

        private void AutoMigrateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                context.Database.Migrate();
            }
        }
    }
}
