using System;
using System.Text;
using System.Windows;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для AddEdit_Category.xaml
    /// </summary>
    public partial class AddEdit_Category : Window
    {
        private Category_product _currentCategory = new Category_product();

        public AddEdit_Category(Category_product selectedCategory)
        {
            InitializeComponent();

            if (selectedCategory != null)
            {
                _currentCategory = selectedCategory;
                this.Title = "Редактирование";
            }
            else
            {
                this.Title = "Добавление сотрудника";
            }

            DataContext = _currentCategory;
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentCategory.name_category))
                errors.AppendLine("Укажите категорию");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentCategory.id_category == 0)
            {
                FactoryEntities.GetContext().Category_product.Add(_currentCategory);
                MessageBox.Show("Категория добавлена в базу.");
            }

            try
            {
                FactoryEntities.GetContext().SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            this.Close();
        }
    }
}