


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SunnyLize.Word.Web.Server
{
    /// <summary>
    /// Short hand access class to get DI service with nice clean short code
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// The scoped instance of the <see cref="ApplicationDbContext"/>
        /// </summary>
        public static ApplicationDbContext ApplicationDbContext => IOCContainer.Provider.GetService<ApplicationDbContext>();
    }

    /// <summary>
    /// The DI Container making use of the built in .net core service provide
    /// </summary>
    public static class IOCContainer
    {
        /// <summary>
        /// the service provide for this application
        /// </summary>
        public static ServiceProvider Provider { get; set; }

        /// <summary>
        /// This configuration manager for the application
        /// </summary>
        public static IConfiguration Configuration { get; set; }
    }


}
