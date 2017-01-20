using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Etg.Data.Entry;
using System.ServiceProcess;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Etg.Service
{
    public class Program
    {
        IConfigurationRoot Configuration { get; }

        private IServiceProvider serviceProvider;

        public Program(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true);
                //.AddCommandLine(args);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            Configure(loggerFactory);
        }


        public void Configure(ILoggerFactory loggerFactory)
        {
            LogLevel lvl = LogLevel.Information;
            if(Configuration["logLevel"] != null)
            {
                if(Configuration["logLevel"] == "Debug")
                {
                    lvl = LogLevel.Debug;
                }
            }
            loggerFactory.AddConsole(lvl)
                .AddDebug()
                .AddEventLog(lvl);

            

        }

        public void ConfigureServices(ServiceCollection services)
        {
            services.AddOptions();
            services.Configure<EtgServiceOptions>(Configuration.GetSection("ports"));
            services.Configure<EntryDataServiceOptions>(Configuration.GetSection("entryData"));

            services.AddLogging();
            services.AddSingleton<EntryDataServiceImpl>();
            services.AddSingleton<EtgService>();
        }

        public void RunAsService()
        {
            
            ServiceBase.Run(serviceProvider.GetRequiredService<EtgService>());
        }

        public void Run()
        {
            var etgService = serviceProvider.GetRequiredService<EtgService>();
            etgService.StartServer();
            Console.WriteLine("Press any key to stop server.");
            Console.ReadKey(true);
            etgService.StopServer();
        }

        public static void Main(string[] args)
        {
            CommandLineApplication app = new CommandLineApplication();
            var runAsServiceOption = app.Option("-s|--service", "Run as Windows Service", CommandOptionType.NoValue);
            app.HelpOption("-?|-h|--help");
            app.OnExecute(() =>
            {
                var program = new Program(args);
                if (runAsServiceOption.HasValue())
                {
                    program.RunAsService();
                }
                else
                {
                    program.Run();
                }
                return 0;
            });
            app.Execute(args);
        }
    }
}
