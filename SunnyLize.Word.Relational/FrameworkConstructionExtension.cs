using Dna;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SunnyLize.Word.Core;


namespace SunnyLize.Word.Relational
{
    /// <summary>
    /// Extension method for the <see cref="FrameworkConstruction"></see>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        /// <summary>
        /// default ctor
        /// </summary>
        public static FrameworkConstruction AddClientDataStore(this FrameworkConstruction construction)
        {
            //Now we can inject our SQLite ef data store
            //construction.Services.AddDbContext<ClientDataStoreDbContext>(options => options.Sqlite(construction.Configuration.GetConnectionString("ClientDataStoreConnection")));
            construction.Services.AddDbContext<ClientDataStoreDbContext>(options =>
               options.UseSqlite(construction.Configuration.GetConnectionString("ClientDataStoreConnection")));


            //For easy acess to our db we add client data store for access\use backing of data store..so of global use
            //make it scoped so we inject the scoped DbContext

            construction.Services.AddScoped<IClientDataStore>(
               provider => new BaseClientDataStore(provider.GetService<ClientDataStoreDbContext>()));

            //return framework for chaining
            return construction;
        }
    }
}
