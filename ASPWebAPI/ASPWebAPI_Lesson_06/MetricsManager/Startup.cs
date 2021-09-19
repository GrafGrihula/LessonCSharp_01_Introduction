using AutoMapper;
using FluentMigrator.Runner;
using MediatR;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Repositories;
using MetricsManager.Mapper;
using MetricsManager.Quartz;
using MetricsManager.Quartz.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace MetricsManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFluentMigratorCore()
                        .ConfigureRunner(rb => rb
                        .AddSQLite()
                        .WithGlobalConnectionString(new SQLiteConnectionManager().ConnectionString)
                        .ScanIn(typeof(Startup).Assembly).For.Migrations())
                        .AddLogging(lb => lb
                        .AddFluentMigratorConsole());

            services.AddControllers();

            services.AddMediatR(typeof(Startup));

            var mapper = new MapperConfiguration(mapper => mapper.AddProfile(new MapperProfile())).CreateMapper();
            services.AddSingleton(mapper);

            services.AddHttpClient<IMetricsAgentClient, MetricsAgentClient>();
            //        .AddTransientHttpErrorPolicy(p => p
            //        .WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(1000)));

            services.AddHostedService<QuartzHostedService>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<CpuMetricsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricsJob),
                cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<IDBConnectionManager, SQLiteConnectionManager>();
            services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddSingleton<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
            services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();
            services.AddSingleton<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddSingleton<IAgentRepository, AgentRepository>();
        }


        public void Configure(IApplicationBuilder app,
                      IWebHostEnvironment env,
                      IMigrationRunner migrationRunner)
        {
            migrationRunner.MigrateUp();

            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
