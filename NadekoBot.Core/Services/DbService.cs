using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using EvilMortyBot.Core.Services.Database;
using System;
using System.IO;
using System.Linq;

namespace EvilMortyBot.Core.Services
{
    public class DbService
    {
        private readonly DbContextOptions<EvilMortyContext> options;
        private readonly DbContextOptions<EvilMortyContext> migrateOptions;

        public DbService(IBotCredentials creds)
        {
            var builder = new SqliteConnectionStringBuilder(creds.Db.ConnectionString);
            builder.DataSource = Path.Combine(AppContext.BaseDirectory, builder.DataSource);
            
            var optionsBuilder = new DbContextOptionsBuilder<EvilMortyContext>();
            optionsBuilder.UseSqlite(builder.ToString());
            options = optionsBuilder.Options;

            optionsBuilder = new DbContextOptionsBuilder<EvilMortyContext>();
            optionsBuilder.UseSqlite(builder.ToString(), x => x.SuppressForeignKeyEnforcement());
            migrateOptions = optionsBuilder.Options;
        }

        public EvilMortyContext GetDbContext()
        {
            var context = new EvilMortyContext(options);
            if (context.Database.GetPendingMigrations().Any())
            {
                var mContext = new EvilMortyContext(migrateOptions);
                mContext.Database.Migrate();
                mContext.SaveChanges();
                mContext.Dispose();
            }
            context.Database.SetCommandTimeout(60);
            context.EnsureSeedData();

            //set important sqlite stuffs
            var conn = context.Database.GetDbConnection();
            conn.Open();

            context.Database.ExecuteSqlCommand("PRAGMA journal_mode=WAL");
            using (var com = conn.CreateCommand())
            {
                com.CommandText = "PRAGMA journal_mode=WAL; PRAGMA synchronous=OFF";
                com.ExecuteNonQuery();
            }

            return context;
        }

        public IUnitOfWork UnitOfWork =>
            new UnitOfWork(GetDbContext());
    }
}