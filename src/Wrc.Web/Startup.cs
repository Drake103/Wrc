using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wrc.Web.Common;
using Wrc.Web.Dal;
using Wrc.Web.Dal.Replays;
using Wrc.Web.Domain;
using Wrc.Web.Domain.Replays;
using Wrc.Web.Domain.Replays.Dictionaries;
using Wrc.Web.Services.ReplayParsing;
using Wrc.Web.Services.Replays;

namespace Wrc.Web
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
            services.AddMvc();

            services.AddScoped<IUnitOfWorkFactory, WrcContextFactory>();
            services.AddScoped<IReplayService, ReplayService>();
            services.AddScoped<IReplayParser, ReplayParser>();
            services.AddScoped<IParsedReplayToGameInfoTransformer, ParsedReplayToGameInfoTransformer>();
            services.AddScoped<IDictionaryItemStorage<IGameMode>, GameModeStorage>();
            services.AddScoped<IDictionaryItemStorage<IGameMap>, GameMapStorage>();
            services.AddScoped<IDictionaryItemStorage<IVictoryCondition>, VictoryConditionStorage>();
            services.AddScoped<IDictionaryItemStorage<IGameType>, GameTypeStorage>();
            services.AddScoped<GameInfoBuilderFactory>();
            services.AddScoped<LightReplayProjectionToLightReplayTransformer>();
            services.AddScoped<ReplayRecordToReplayTransformer>();
            services.AddScoped<IReplayRepositoryFactory, ReplayRepositoryFactory>();
            services.AddScoped<ITimeService, TimeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    "spa-fallback",
                    new {controller = "Home", action = "Index"});
            });
        }
    }
}