using BudgetApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace BudgetApplication.DB
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }


    }

}
