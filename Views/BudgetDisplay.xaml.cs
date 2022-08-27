using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Budgeteer
{
    /// <summary>
    /// Interaction logic for BudgetDisplay.xaml
    /// </summary>
    public partial class BudgetDisplay : Page
    {
        public string expenseName;
        public BudgetDisplay()
        {

            InitializeComponent();
            DataContext = this;
            

        }



        public List<ExpensesModel> Expenses
        {
            get { return ExpensesModel.Instance.expenses; }
        }

        public List<string> Items
        {
            get { return ExpensesModel.Instance.expenseWriteOut; }
        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            if (WrongInputPopup.IsOpen)
            {
                WrongInputPopup.IsOpen = false;
            }
            string[] entry = new string[3];

            entry = NewEntryTextBox.Text.ToString().Split(',');

            try
            {

                string name = entry[0];
                int cost = Convert.ToInt32(entry[1]);
                int type = Convert.ToInt32(entry[2]);

                ExpensesModel.Instance.expenses.Add(new ExpensesModel() {Cost = cost, Name = name, Type = (Repository.ExpenseType)type });
                ExpensesModel.Instance.newExpenses.Add(new ExpensesModel() { Cost = cost, Name = name, Type = (Repository.ExpenseType)type });
                NewEntryTextBox.Clear();
                NewEntryTextBox.Text = "Name, Cost, Interval";
                budgetDisplayDataGrid.Items.Refresh();

            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException)
                {
                    Debug.WriteLine("Index out of range");
                    WrongInputText.Text = $"'{NewEntryTextBox.Text}' is unfortunately a wrong format";
                    NewEntryTextBox.Clear();
                    NewEntryTextBox.Text = "Name, Cost, Interval";
                    WrongInputPopup.IsOpen = true;

                }
                else if (ex is FormatException)
                {
                    Debug.WriteLine("Wrong format");
                    WrongInputText.Text = $"'{NewEntryTextBox.Text}' is unfortunately a wrong input";
                    NewEntryTextBox.Clear();
                    NewEntryTextBox.Text = "Name, Cost, Interval";
                    WrongInputPopup.IsOpen = true;

                }

            }



        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpensesModel.Instance.SaveExpenses();
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCell dataGridCellTarget = (DataGridCell)sender;
           
           // expenseName = dataGridCellTarget.;
        }

       
    }

}
