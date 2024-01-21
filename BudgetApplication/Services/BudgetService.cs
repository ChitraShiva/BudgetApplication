using BudgetApplication.DB;
using BudgetApplication.Enums;
using BudgetApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace BudgetApplication.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly ApplicationDbContext _dbContext;
        public BudgetService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //income
        public async Task<double> GetTotalIncome(int userId)
        {
            var totalIncome = await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Income)
                .SumAsync(t => t.Amount);

            return totalIncome;
        }

        //transaction details
        public async Task AddTransaction(Transaction transaction)
        {
           
            try
            {
                _dbContext.Transactions.Add(transaction);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add transaction to the database", ex);
            }
        }

        //income-monthwise

        public async Task<IEnumerable<object>> GetMonthlyIncome(int userId)
        {
            var monthlyIncome = await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Income)
                .GroupBy(t => t.Month)
                .Select(group => new
                {
                    month = group.Key.ToString(),
                    totalincome = group.Sum(t => t.Amount)
                })
                .ToListAsync();

            foreach (var entry in monthlyIncome)
            {
                Console.WriteLine($"month: {entry.month}, totalincome: {entry.totalincome}");
            }

            return monthlyIncome;
        }
        //quartely income
        public async Task<IEnumerable<object>> GetQuarterlyIncome(int userId)
        {
            var monthNames = new[] { "January-March", "April-June", "July-September", "October-December" };

            var quarterlyIncome = await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Income)
                .GroupBy(t => ((int)t.Month - 1) / 3 + 1)
                .Select(group => new
                {
                    month = monthNames[group.Key - 1],
                    totalincome = group.Sum(t => t.Amount)
                })
                .ToListAsync();

            return quarterlyIncome;
        }



        //half-year income
        public async Task<IEnumerable<object>> GetHalfYearlyIncome(int userId)
        {
            var halfYearlyIncome = await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Income)
                .GroupBy(t => (t.Month <= TransactionMonths.June) ? "January - June" : "July - December")
                .Select(group => new
                {
                    month = group.Key,
                    totalincome = group.Sum(t => t.Amount)
                })
                .ToListAsync();

            foreach (var entry in halfYearlyIncome)
            {
                Console.WriteLine($"month: {entry.month}, totalincome: {entry.totalincome}");
            }

            return halfYearlyIncome;
        }

        //income-yearly
        public async Task<IEnumerable<object>> GetYearlyIncome(int userId)
        {
            var yearlyIncome = await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Income)
                .SumAsync(t => t.Amount);

            var result = new List<object>
            {
                new { month = "January-December", totalincome = yearlyIncome }
            };

            Console.WriteLine($"totalincome: {yearlyIncome}");

            return result;
        }


        //user
        public async Task AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User object cannot be null");
            }
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        //expense

        // Get total expenses
        public async Task<double> GetTotalExpenses(int userId)
        {
            var totalExpenses = await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Expense)
                .SumAsync(t => t.Amount);

            return totalExpenses;
        }


        // monthly expenses
        public async Task<IEnumerable<object>> GetMonthlyExpenses(int userId)
        {
            var monthlyIncome = await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Expense)
                .GroupBy(t => t.Month)
                .Select(group => new
                {
                    month = group.Key.ToString(),
                    totalexpense = group.Sum(t => t.Amount)
                })
                .ToListAsync();

            foreach (var entry in monthlyIncome)
            {
                Console.WriteLine($"month: {entry.month} , expense:  {entry.totalexpense}");
            }

            return monthlyIncome;
        }

        //quartely expense
        public async Task<IEnumerable<object>> GetQuarterlyExpense(int userId)
        {
            var monthNames = new[] { "January-March", "April-June", "July-September", "October-December" };

            var quarterlyIncome = await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Expense)
                .GroupBy(t => ((int)t.Month - 1) / 3 + 1)
                .Select(group => new
                {
                    month = monthNames[group.Key - 1],
                    totalexpense = group.Sum(t => t.Amount)
                })
                .ToListAsync();

            return quarterlyIncome;
        }


        // half-yearly expenses
        public async Task<IEnumerable<object>> GetHalfYearlyExpenses(int userId)
        {
            var halfYearlyIncome = await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Expense)
                .GroupBy(t => (t.Month <= TransactionMonths.June) ? "January - June" : "July - December")
                .Select(group => new
                {
                    month = group.Key,
                    totalexpense = group.Sum(t => t.Amount)
                })
                .ToListAsync();

            foreach (var entry in halfYearlyIncome)
            {
                Console.WriteLine($"month: {entry.month}, totalexpense: {entry.totalexpense}");
            }

            return halfYearlyIncome;
        }

        // yearly expenses

        public async Task<IEnumerable<object>> GetYearlyExpenses(int userId)
        {
            var yearlyIncome = await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Expense)
                .SumAsync(t => t.Amount);

            var result = new List<object>
            {
                new { Month = "January-December", totalexpense = yearlyIncome }
            };

            Console.WriteLine($"totalexpense: {yearlyIncome}");

            return result;
        }


        //list of income and expense for an user

        // Get all income transactions for a user
        public async Task<List<Transaction>> GetIncomeTransactions(int userId)
        {
            return await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Income)
                .ToListAsync();
        }

        // Get all expense transactions for a user
        public async Task<List<Transaction>> GetExpenseTransactions(int userId)
        {
            return await _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Expense)
                .ToListAsync();
        }


    }
}
