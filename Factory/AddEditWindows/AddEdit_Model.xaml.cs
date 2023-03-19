using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для AddEdit_Model.xaml
    /// </summary>
    public partial class AddEdit_Model : Window
    {
        private Model_clothes orig = new Model_clothes();
        private Model_clothes workCopy = new Model_clothes();

        public AddEdit_Model(Model_clothes selectedClothes, IEnumerable<Type_product> productTypes)
        {
            if (productTypes is null)
            {
                throw new ArgumentNullException(nameof(productTypes));
            }

            if (!productTypes.Any())
            {
                throw new InvalidOperationException("Список типов продуктов пуст!");
            }

            InitializeComponent();

            if (selectedClothes != null)
            {
                orig = selectedClothes;
                workCopy = new Model_clothes()
                {
                    id_model = selectedClothes.id_model,
                    id_product = selectedClothes.id_product,
                    name_model = selectedClothes.name_model,
                    price_model = selectedClothes.price_model,
                };

                addEditModel.Title = "Редактирование";
            }
            else
            {
                addEditModel.Title = "Добавление";
            }

            DataContext = workCopy;
            cBox_product.ItemsSource = productTypes;

            if (workCopy.id_product == 0)
            {
                workCopy.id_product = productTypes.First().id_product;
            }

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (workCopy.id_product == 0)
                errors.AppendLine("Укажите товар");
            if (string.IsNullOrWhiteSpace(workCopy.name_model))
                errors.AppendLine("Укажите название модели");
            if (string.IsNullOrWhiteSpace(workCopy.price_model))
                errors.AppendLine("Укажите цену");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (workCopy.id_model == 0)
            {
                FactoryEntities.GetContext().Model_clothes.Add(workCopy);
                MessageBox.Show("Модель добавлена в базу.");
            }
            else
            {
                orig.id_model = workCopy.id_model;
                orig.id_product = workCopy.id_product;
                orig.name_model = workCopy.name_model;
                orig.price_model = workCopy.price_model;
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