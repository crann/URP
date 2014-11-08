using System;
using System.Data.Entity;
using System.IO;
using URP.DataAccess.Scaffolding.Implementation;

namespace URP.DataAccess
{
    /// <summary>
    /// Responsible for creating and seeding the application's database.
    /// </summary>
    public class DatabaseSeed : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(ApplicationContext context)
        {   
            LoadTestData(context);
            base.Seed(context);
        }

        /// <summary>
        /// Seeds the database with required test data.
        /// </summary>
        private void LoadTestData(ApplicationContext context)
        {
            // Test Data - Insert [Movie] data into the database.
            string appDataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            string scriptPath = Path.Combine(appDataPath, @"DatabaseScripts\TestData\InsertMovies.sql");
            string sql = File.ReadAllText(scriptPath);
            context.Database.ExecuteSqlCommand(sql);
        }
    }
}