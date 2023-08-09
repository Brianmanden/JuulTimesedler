using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using JuulTimesedler_BE.Interfaces;
using JuulTimesedler_BE.Services;

namespace JuulTimesedler_BE;

public class Program
{
    public static void Main(string[] args)
        => CreateHostBuilder(args)
            .Build()
            .Run();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(
                services =>
                    services.AddScoped<IWorkersService, WorkersService>()
                            .AddScoped<ITimeService, TimeService>()
                            .AddScoped<ITimesheetService, TimesheetService>()
                )
            .ConfigureUmbracoDefaults()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices(
                    services => services.AddCors(
                        options => options.AddPolicy(
                            "MyCors", policy =>
                                {
                                    policy
                                    .AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                                }
                        )
                    )
                );
                webBuilder.UseStaticWebAssets();
                webBuilder.UseStartup<Startup>();
            });
}

#region CORS
public class MyComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                x => x.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod()
            );
        });

        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            options.AddFilter(new UmbracoPipelineFilter(nameof(MyComposer))
            {
                PostPipeline = appBuilder => appBuilder.UseCors()
            });
        });
    }
}
#endregion
