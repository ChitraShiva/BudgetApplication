using BudgetApplication.Controllers;
using BudgetApplication.Services;
using Moq;

namespace BudgetApplicationTests
{
    public class Tests
    {
        public ExpenseController _expenseController;
        public IncomeController _incomeController;
        public TransactionController _transactionController;
        public UserController _userController;
        public Mock<IBudgetService> _mockbudgetService;

        [SetUp]
        public void Setup()
        {
            _mockbudgetService = new Mock<IBudgetService>();
            _expenseController= new ExpenseController( _mockbudgetService.Object );
            _incomeController=new IncomeController( _mockbudgetService.Object );
            _transactionController=new TransactionController( _mockbudgetService.Object );
            _userController=new UserController( _mockbudgetService.Object );
        }

        [Test]
        [TestCase(1)]
        public async Task GetAllIncome_ReturnAllIncome(int userId)
        {

        }
    }
}