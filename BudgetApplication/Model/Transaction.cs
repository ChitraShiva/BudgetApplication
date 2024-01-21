using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BudgetApplication.Enums;

namespace BudgetApplication.Model
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public string Name { get; set; }
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public TransactionMonths Month {  get; set; } 


    }
}
