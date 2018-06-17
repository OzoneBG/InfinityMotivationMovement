namespace IMM.Web
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using System.Threading.Tasks;
    using NLog.Web;
    using NLog;
    using System;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            Logger logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            try
            {
                logger.Debug("init main");
                var host = BuildWebHost(args);

                await host.RunAsync();
            }
            catch (Exception e)
            {
                logger.Error(e, "Stopping program because an exception has occured!");
                throw;
            }

            await BuildWebHost(args).RunAsync();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog()
                .Build();
    }
}
