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

namespace PCStoreApp
{
    /// <summary>
    /// Логика взаимодействия для TypePage.xaml
    /// </summary>
    public partial class TypePage : Page
    {
        public TypePage()
        {
            InitializeComponent();
            var currentType = ToursBaseEntities.GetContext().Types.ToList();
            LViewType.ItemsSource = currentType;
        }
        private void TypeSelected(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid && grid.DataContext is Type selectedType)
            {
                Manager.MainFrame.Navigate(new ItemsPage(selectedType));
            }
        }

    }
}
