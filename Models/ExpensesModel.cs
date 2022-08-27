using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Budgeteer
{
    public class ExpensesModel
    {
        private IBudgetRepository repository;
        private BudgetMapper mapper = new BudgetMapper();
        private DatabaseProvider provider = new DatabaseProvider("Data Source=expenses.db");
        public List<ExpensesModel> expenses = new List<ExpensesModel>();
        public List<string> expenseWriteOut = new List<string>();
        public List<ExpensesModel> newExpenses = new List<ExpensesModel>();

        
        private static ExpensesModel instance;
        public static ExpensesModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExpensesModel();
                }
                return instance;
            }
        }
       
        public int ID { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public ExpenseType Type { get; set; }

        public void GetExpenses()
        {
            repository = new BudgetRepository(provider, mapper);
            repository.Open();
            var budgetEntries = repository.GetAllEntries();

            foreach (BudgetEntry entry in budgetEntries)
            {
                expenses.Add(new ExpensesModel(){ID = entry.ID, Name = entry.Name, Cost = entry.Cost, Type = entry.Type });
            }
            ExpensesToString();
            repository.Close();
        }

        public void ExpensesToString()
        {
            foreach (ExpensesModel e in expenses)
            {
                expenseWriteOut.Add($"ID: {e.ID} Name: {e.Name} Cost: {e.Cost} Interval: {e.Type}".ToString());
            }
        }

        public void SaveExpenses()
        {
            repository.Open();

            if (newExpenses.Count != 0)
            {
                foreach (ExpensesModel expense in newExpenses)
                {
                    repository.AddExpense(expense.Name, expense.Cost, expense.Type);
                }
                newExpenses.Clear();
            }
         

            repository.Close();

        }
    }
}
