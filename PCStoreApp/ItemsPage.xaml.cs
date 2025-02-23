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
    /// Логика взаимодействия для ItemsPage.xaml
    /// </summary>
    public partial class ItemsPage : Page
    {
        private Type _selectedType;

        public ItemsPage(Type selectedType) // Конструктор с фильтрацией
        {
            InitializeComponent();
            _selectedType = selectedType;
            LoadItems(); // Вызов метода для загрузки отфильтрованных данных
        }


        private void LoadItems()
        {
            if (_selectedType != null)
            {
                DGridItems.ItemsSource = ToursBaseEntities.GetContext()
                    .PCItems
                    .Where(item => item.Types.Any(t => t.id == _selectedType.id)) // Сравнение по Id
                    .ToList();
            }
            else
            {
                DGridItems.ItemsSource = ToursBaseEntities.GetContext().PCItems.ToList();
            }
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var itemsForRemoving = DGridItems.SelectedItems.Cast<PCItem>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {itemsForRemoving.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ToursBaseEntities.GetContext().PCItems.RemoveRange(itemsForRemoving);
                    ToursBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    LoadItems(); // Обновляем список после удаления
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditPage((sender as Button).DataContext as PCItem));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ToursBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LoadItems(); // Обновляем список при возврате на страницу
            }
        }
    }
}