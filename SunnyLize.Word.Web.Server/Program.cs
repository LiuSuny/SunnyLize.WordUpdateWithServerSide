using Dna;
using Dna.AspNet;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SunnyLize.Word.Web.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            CreateBuildWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateBuildWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder()
                // Add Dna Framework
                .UseDnaFramework(construct =>
                {
                    // Configure framework

                    // Add file logger
                    construct.AddFileLogger();
                })
                .UseStartup<Startup>();
        }
    }
}
