using System;
using System.IO;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MicroRabbit.Banking.Data.Context
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BankingDbContext>
    {
        public BankingDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(Directory.GetCurrentDirectory() + "/../MicroRabbit.Banking.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<BankingDbContext>();
            var connectionString = configuration.GetConnectionString("BankingDbConnection");
            builder.UseSqlServer(connectionString);
            //builder.UseSqlServer("Server=localhost,1401;Database=BankingDB;User=SA;Password=1StrongPassword!;MultipleActiveResultSets=true");
            return new BankingDbContext(builder.Options);
        }
    }
}
