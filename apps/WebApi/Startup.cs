using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using src.CsharpBasicSkeleton.Items.Application.SearchByCriteria;
using src.CsharpBasicSkeleton.Items.Domain;
using src.CsharpBasicSkeleton.Items.Infrastructure;
using src.CsharpBasicSkeleton.Shared;
using src.CsharpBasicSkeleton.Shared.Domain.Bus.Queries;
using src.CsharpBasicSkeleton.Shared.Infrastructure.Bus.Queries;

namespace FiltersByCriteria
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddQueryServices(typeof(Query).Assembly);
            services.AddScoped<QueryBus, InMemoryQueryBus>();
            services.AddSingleton<ItemRepository, InMemoryItemRepository>();
            services.AddScoped<ItemsByCriteriaSearcher, ItemsByCriteriaSearcher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}