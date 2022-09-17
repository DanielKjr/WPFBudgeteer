using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for CustomColumns.xaml
    /// </summary>
    public partial class CustomColumns : Page
    {
        public string expenseName;
        public CustomColumns()
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
    }
}
