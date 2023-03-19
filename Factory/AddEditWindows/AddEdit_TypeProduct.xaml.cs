using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для AddEdit_TypeProduct.xaml
    /// </summary>
    public partial class AddEdit_TypeProduct : Window
    {
        private Type_product orig = new Type_product();
        private Type_product workCopy = new Type_product();

        public AddEdit_TypeProduct(Type_product selectedType, IEnumerable<Category_product> productCategory)
        {
            if (productCategory is null)
            {
                throw new ArgumentNullException(nameof(productCategory));
            }

            if (!productCategory.Any())
            {
                throw new InvalidOperationException("Список категорий одежды пуст!");
            }

            InitializeComponent();

            if (selectedType != null)
            {
                orig = selectedType;
                workCopy = new Type_product()
                {
                    id_product = selectedType.id_product,
                    id_category = selectedType.id_category,
                    name_product = selectedType.name_product,
                };

                this.Title = "Редактирование";
            }
            else
            {
                this.Title = "Добавление";
            }

            DataContext = workCopy;
            cBox_category.ItemsSource = productCategory;

            if (workCopy.id_category == 0)
            {
                workCopy.id_category = productCategory.First().id_category;
            }
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (workCopy.id_category == 0)
                errors.AppendLine("Укажите категорию одежды");
            if (string.IsNullOrWhiteSpace(workCopy.name_product))
                errors.AppendLine("Укажите тип одежды");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (workCopy.id_product == 0)
            {
                FactoryEntities.GetContext().Type_product.Add(workCopy);
                MessageBox.Show("Тип одежды добавлен в базу.");
            }
            else
            {
                orig.id_product = workCopy.id_product;
                orig.id_category = workCopy.id_category;
                orig.name_product = workCopy.name_product;
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