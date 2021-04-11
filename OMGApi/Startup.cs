using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OData.Swagger.Services;
using OMGApi.Data;
using OMGApi.Data.Interfaces;
using OMGApi.Logic;
using OMGApi.Logic.Interfaces;
using SimpleInjector;

namespace OMGApi
{
    public class Startup
    {

        private readonly Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            container.Options.ResolveUnregisteredConcreteTypes = false;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddOData();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OMG API", Version = "v1" });
            });

            services.AddOdataSwaggerSupport();

            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore().AddControllerActivation();
            });

            InitializeContainer();

        }

        private void InitializeContainer()
        {
            container.Register<IMovieLogic, MovieLogic>(Lifestyle.Singleton);
            container.Register<IMovieData, MovieData>(Lifestyle.Singleton);

            container.Register<IDataCache, DataCache>(Lifestyle.Singleton);
            container.Register<IDatabaseComs, DatabaseComs>(Lifestyle.Singleton);

            container.Register<IOMDbConnection, OMDbConnection>(Lifestyle.Singleton);
            container.Register<IWebApiClient, WebApiClient>(Lifestyle.Singleton);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(container);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "OMG API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Filter();
            });

            container.Verify();

        }
    }
}
