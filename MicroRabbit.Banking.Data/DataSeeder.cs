using System;
using System.Collections.Generic;
using System.Linq;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Data
{
    public class DataSeeder
    {
        public static void Initialize(BankingDbContext context)
        {
            if (!context.Accounts.Any())
            {
                var accounts = new List<Account>()
                {
                    new Account {Id = 1, AccountType = "Checking", AccountBalance = 100, RoutingNumber = "1234"},
                    new Account { Id = 2, AccountType = "Checking", AccountBalance = 100, RoutingNumber = "1234567" }
                };
                context.Accounts.AddRange(accounts);
                context.SaveChanges();
            }
        }
    }
}
