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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private PCItem _currentItems = new PCItem();
        public EditPage(PCItem selectedItems)
        {
            InitializeComponent();
            if (selectedItems != null)
                _currentItems = selectedItems;
            DataContext = _currentItems;
            ComboCountries.ItemsSource = ToursBaseEntities.GetContext().ItemStates.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentItems.Name))
                errors.AppendLine("Укажите наименование комплектующего");
            if (_currentItems.CountOfItems < 0)
                errors.AppendLine("Количество - число от 0");
            if (_currentItems.ItemState == null)
                errors.AppendLine("Выберите состояние");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentItems.id == 0)
                ToursBaseEntities.GetContext().PCItems.Add(_currentItems);
            try
            {
                ToursBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
