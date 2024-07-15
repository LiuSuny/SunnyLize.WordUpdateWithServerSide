using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyLize.Word.Relational
{
    /// <summary>
    /// The database context for the client data store
    /// using EntityFramework and SQLite
    /// </summary>
    public class ClientDataStoreDbContext : DbContext
    {
        #region DbSet
        /// <summary>
        /// the client login credential
        /// </summary>
          public DbSet<LoginCredentialDataModel> loginCredentials { get; set; }
        #endregion
        /// <summary>
        ///  ctor
        /// </summary>
        public ClientDataStoreDbContext(DbContextOptions<ClientDataStoreDbContext> options) : base(options) { }

        #region Model creation
        /// <summary>
        /// configure the databse structure and relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent Api --way of validating our db instead of using attribute inside of core app

            //Configure login credential
            //--------------
            //
            //Set id as primary key
            modelBuilder.Entity<LoginCredentialDataModel>().HasKey(p => p.Id);

            //TODO: Set up limit and we can configure this for all our other LoginCredentialDataModel property
            //modelBuilder.Entity<LoginCredentialDataModel>().Property(p => p.FirstName).HasMaxLength(50);


        }
        #endregion

    }
}
