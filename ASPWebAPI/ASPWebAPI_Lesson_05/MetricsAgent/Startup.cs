using AutoMapper;
using FluentMigrator.Runner;
using MediatR;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Repository;
using MetricsAgent.Jobs;
using MetricsAgent.Jobs.MetricsJob;
using MetricsAgent.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Data.SQLite;

namespace MetricsAgent
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
            //var mapper = new MapperConfiguration(mapper => mapper.AddProfile(new MapperProfile())).CreateMapper();

            ConfigureSqlLiteConnection();
            services.AddControllers();
            services.AddMediatR(typeof(Startup));

            services.AddHostedService<QuartzHostedService>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricJob),
                cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<RamMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(RamMetricJob),
                cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<HddMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(HddMetricJob),
                cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<NetworkMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(NetworkMetricJob),
                cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<DotNetMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(DotNetMetricJob),
                cronExpression: "0/5 * * * * ?"));

            services.AddScoped<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddScoped<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddScoped<IHddMetricsRepository, HddMetricsRepository>();
            services.AddScoped<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddScoped<IRamMetricsRepository, RamMetricsRepository>();
            services.AddSingleton<IDBConnectionManager, SQLiteConnectionManager>();

            var mapper = new MapperConfiguration(mapper => mapper.AddProfile(new MapperProfile())).CreateMapper();
            services.AddSingleton(mapper);

            services.AddFluentMigratorCore().ConfigureRunner(rb => rb.AddSQLite().WithGlobalConnectionString(new SQLiteConnectionManager().ConnectionString).ScanIn(typeof(Startup).Assembly).For.Migrations()).AddLogging(lb => lb.AddFluentMigratorConsole());
        }

        private void ConfigureSqlLiteConnection()
        {
            var connection = new SQLiteConnectionManager().CreateOpenedConnection() as SQLiteConnection;
            SchemaTemplate(connection);
        }


        private void SchemaTemplate(SQLiteConnection connection)
        {
            var nameTable = new[] { "cpumetrics", "dotnetmetrics", "hddmetrics", "networkmetrics", "rammetrics" };
            // количество строк в таблице
            var tableLineSum = 5;

            Random rnd = new Random();

            using var command = new SQLiteCommand(connection);

            for (int i = 0; i < nameTable.Length; i++)
            {
                command.CommandText = $"DROP TABLE IF EXISTS {nameTable[i]}";
                command.ExecuteNonQuery();
                command.CommandText = $"CREATE TABLE {nameTable[i]}(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();

                for (int n = 0; n < tableLineSum; n++)
                {
                    var volume = rnd.Next(10, 40);
                    command.CommandText = $"INSERT INTO {nameTable[i]}(value, time) VALUES({volume},{n})";
                    command.ExecuteNonQuery();
                }
            }
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
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

            migrationRunner.MigrateUp();
        }
    }
}
