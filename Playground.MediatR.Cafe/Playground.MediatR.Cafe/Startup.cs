using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Playground.MediatR.Cafe.Hubs;
using Playground.MediatR.Cafe.Models;

namespace Playground.MediatR.Cafe
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddRazorPages();
            services.AddSignalR();
            
            services.AddSingleton<DrinkMachineHub>();

            services.AddSingleton<CoffeeDispenser>()
                    .AddSingleton<LatteDispenser>()
                    .AddSingleton<CappuccinoDispenser>()
                    .AddSingleton<TeaDispenser>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<DrinkMachineHub>("/machine");
                endpoints.MapRazorPages();
            });
        }
    }
}