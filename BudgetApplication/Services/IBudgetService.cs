using BudgetApplication.Model;

namespace BudgetApplication.Services
{
    public interface IBudgetService
    {
        Task<double> GetTotalIncome(int userId);
        Task AddUser(User user);
        Task<IEnumerable<object>> GetMonthlyIncome(int userId);
        Task<IEnumerable<object>> GetQuarterlyIncome(int userId);
        Task<IEnumerable<object>> GetYearlyIncome(int userId);

        Task<IEnumerable<object>> GetHalfYearlyIncome(int userId);
        Task AddTransaction(Transaction transaction);

        Task<double> GetTotalExpenses(int userId);

        Task<IEnumerable<object>> GetMonthlyExpenses(int userId);
        Task<IEnumerable<object>> GetQuarterlyExpense(int userId);
        Task<IEnumerable<object>> GetHalfYearlyExpenses(int userId);
        Task<IEnumerable<object>> GetYearlyExpenses(int userId);
        Task<List<Transaction>> GetIncomeTransactions(int userId);
        Task<List<Transaction>> GetExpenseTransactions(int userId);

    }
}
