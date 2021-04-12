using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.InMemory.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;
using ExcellentTaste.Infrastructure.Sql.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellentTaste
{
    public class Startup
    {
        private enum InfrastructureOrigin
        {
            InMemory,
            Sql
        }
        private const InfrastructureOrigin infrastructureOrigin = InfrastructureOrigin.InMemory;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if(infrastructureOrigin == InfrastructureOrigin.InMemory)
            {
                services.AddSingleton<IBtwTypeData, InMemoryBtwTypeData>();
                services.AddSingleton<ICatagoryData, InMemoryCatagorydata>();
                services.AddSingleton<IFillingData, InMemoryFillingData>();
                services.AddSingleton<IItemData, InMemoryItemData>();
                services.AddSingleton<IReservationData, InMemoryReservationData>();
                services.AddSingleton<IReservationItemData, InMemoryReservationItemData>();
                services.AddSingleton<IStationData, InMemoryStationData>();
                services.AddSingleton<ITableData, InMemoryTableData>();
                services.AddSingleton<IWaiterData, InMemoryWaiterData>();
            }
            else if(infrastructureOrigin == InfrastructureOrigin.Sql)
            {
                services.AddDbContextPool<BtwTypeDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ExcellentTaste"));
                });
                services.AddDbContextPool<CatagoryDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ExcellentTaste"));
                });
                services.AddDbContextPool<FillingDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ExcellentTaste"));
                });
                services.AddDbContextPool<ItemDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ExcellentTaste"));
                });
                services.AddDbContextPool<ReservationDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ExcellentTaste"));
                });
                services.AddDbContextPool<ReservationItemDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ExcellentTaste"));
                });
                services.AddDbContextPool<StationDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ExcellentTaste"));
                });
                services.AddDbContextPool<TableDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ExcellentTaste"));
                });
                services.AddDbContextPool<WaiterDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ExcellentTaste"));
                });

                services.AddScoped<IBtwTypeData, SqlBtwTypeData>();
                services.AddScoped<ICatagoryData, SqlCatagoryData>();
                services.AddScoped<IFillingData, SqlFillingData>();
                services.AddScoped<IItemData, SqlItemData>();
                services.AddScoped<IReservationData, SqlReservationData>();
                services.AddScoped<IReservationItemData, SqlReservationItemData>();
                services.AddScoped<IStationData, SqlStationData>();
                services.AddScoped<ITableData, SqlTableData>();
                services.AddScoped<IWaiterData, SqlWaiterData>();
            }

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
