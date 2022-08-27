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
    /// Interaction logic for BudgetHome.xaml
    /// </summary>
    public partial class BudgetHome : Page
    {
        public BudgetHome()
        {
            InitializeComponent();
           
        }

        private void ViewOverview_Click(object sender, RoutedEventArgs e)
        {
            ExpensesModel.Instance.GetExpenses();
            NavigationService.Navigate(new BudgetDisplay());
        }
    }
}
