using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Button = System.Windows.Controls.Button;
using System.Collections.Generic;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для PageAdministrator.xaml
    /// </summary>
    public partial class PageAdministrator : Window
    {
        private readonly ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        private readonly ObservableCollection<Receipt> receipts = new ObservableCollection<Receipt>();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        byte[] image_bytes = null;

        public PageAdministrator()
        {
            InitializeComponent();

            if (HelperUser.Employee.image_ != null)
            {
                ImageSource imgsour = (ImageSource)new ImageSourceConverter().ConvertFrom(HelperUser.Employee.image_);
                image_myphoto.Source = imgsour;
            }

            label_surname.Content = HelperUser.Employee.surname_employee;
            label_name.Content = HelperUser.Employee.name_employee;
            label_patronymic.Content = HelperUser.Employee.patronymic_employee;
            label_date.Content = HelperUser.Employee.date_birthday;
            label_number.Content = HelperUser.Employee.number_phone;
            label_email.Content = HelperUser.Employee.email;
            label_post.Content = HelperUser.Employee.post;

            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgEmployee.ItemsSource = FactoryEntities.GetContext().Employee.ToList();

            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgReceipt.ItemsSource = FactoryEntities.GetContext().Receipt.ToList();

            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgCategory.ItemsSource = FactoryEntities.GetContext().Category_product.ToList();

            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgModel_clothes.ItemsSource = FactoryEntities.GetContext().Model_clothes.ToList();

            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgType_product.ItemsSource = FactoryEntities.GetContext().Type_product.ToList();
        }

        private void image_myphoto_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image_bytes = File.ReadAllBytes(openFileDialog.FileName);
                ImageSource image = (ImageSource)new ImageSourceConverter().ConvertFrom(image_bytes);
                image_myphoto.Source = image;

                using (FactoryEntities db = new FactoryEntities())
                {
                    var us = db.Employee.FirstOrDefault((par) => par.id_employee == HelperUser.Employee.id_employee);
                    us.image_ = image_bytes;
                    db.SaveChanges();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Фото не выбрано!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void image_exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow auth = new MainWindow();
            auth.Show();

            this.Hide();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private IEnumerable<Type_product> GetProductTypes()
        {
            var productTypes = FactoryEntities.GetContext().Type_product.ToList();
            return productTypes;
        }

        private IEnumerable<Model_clothes> GetModel()
        {
            var model = FactoryEntities.GetContext().Model_clothes.ToList();
            return model;
        }

        private IEnumerable<Employee> GetEmployee()
        {
            var employee = FactoryEntities.GetContext().Employee.ToList();
            return employee;
        }

        private IEnumerable<Category_product> GetCategoryProducts()
        {
            var category = FactoryEntities.GetContext().Category_product.ToList();
            return category;
        }

        private void img_refreshEmp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgEmployee.ItemsSource = FactoryEntities.GetContext().Employee.ToList();
        }
        private void img_refreshReceipt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgReceipt.ItemsSource = FactoryEntities.GetContext().Receipt.ToList();
        }
        private void img_refreshModel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgModel_clothes.ItemsSource = FactoryEntities.GetContext().Model_clothes.ToList();
        }
        private void img_refreshCategory_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgCategory.ItemsSource = FactoryEntities.GetContext().Category_product.ToList();
        }
        private void Btn_deleteEmp_Click(object sender, RoutedEventArgs e)
        {
            var CurrentEmployees = dgEmployee.SelectedItems.Cast<Employee>().ToList();

            if (dgEmployee.SelectedItems is null)
            {
                System.Windows.MessageBox.Show("Сотрудник не выбран!", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error);
            }
            else
            {
                if (System.Windows.MessageBox.Show($"Вы действительно хотите удалить следующие {CurrentEmployees.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FactoryEntities.GetContext().Employee.RemoveRange(CurrentEmployees);
                        FactoryEntities.GetContext().SaveChanges();
                        System.Windows.MessageBox.Show("Удаление сотрудника прошло успешно!");
                        dgEmployee.ItemsSource = FactoryEntities.GetContext().Employee.ToList();
                    }
                    catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message.ToString()); }
                }
            }
        }
        private void Btn_deleteREceipt_Click(object sender, RoutedEventArgs e)
        {
            var CurrentReceipt = dgReceipt.SelectedItems.Cast<Receipt>().ToList();

            if (dgReceipt.SelectedItems is null)
            {
                System.Windows.MessageBox.Show("Поступление не выбрано!", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error);
            }
            else
            {
                if (System.Windows.MessageBox.Show($"Вы действительно хотите удалить следующие {CurrentReceipt.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FactoryEntities.GetContext().Receipt.RemoveRange(CurrentReceipt);
                        FactoryEntities.GetContext().SaveChanges();
                        System.Windows.MessageBox.Show("Удаление поступления прошло успешно!");
                        dgReceipt.ItemsSource = FactoryEntities.GetContext().Receipt.ToList();
                    }
                    catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message.ToString()); }
                }
            }
        }
        private void Btn_deleteModel_Click(object sender, RoutedEventArgs e)
        {
            var CurrentModel = dgModel_clothes.SelectedItems.Cast<Model_clothes>().ToList();

            if (dgModel_clothes.SelectedItems is null)
            {
                System.Windows.MessageBox.Show("Модель не выбрана!", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error);
            }
            else
            {
                if (System.Windows.MessageBox.Show($"Вы действительно хотите удалить следующие {CurrentModel.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FactoryEntities.GetContext().Model_clothes.RemoveRange(CurrentModel);
                        FactoryEntities.GetContext().SaveChanges();
                        System.Windows.MessageBox.Show("Удаление модели прошло успешно!");
                        dgModel_clothes.ItemsSource = FactoryEntities.GetContext().Model_clothes.ToList();
                    }
                    catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message.ToString()); }
                }
            }
        }
        private void Btn_deleteCategory_Click(object sender, RoutedEventArgs e)
        {
            var CurrentCategory = dgCategory.SelectedItems.Cast<Category_product>().ToList();

            if (dgCategory.SelectedItems is null)
            {
                System.Windows.MessageBox.Show("Категория не выбрана!", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error);
            }
            else
            {
                if (System.Windows.MessageBox.Show($"Вы действительно хотите удалить следующие {CurrentCategory.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FactoryEntities.GetContext().Category_product.RemoveRange(CurrentCategory);
                        FactoryEntities.GetContext().SaveChanges();
                        System.Windows.MessageBox.Show("Удаление категории прошло успешно!");
                        dgCategory.ItemsSource = FactoryEntities.GetContext().Category_product.ToList();
                    }
                    catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message.ToString()); }
                }
            }
        }
        private void Btn_addModel_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_Model addEdit_Model = new AddEdit_Model(null, GetProductTypes());
            addEdit_Model.ShowDialog();
        }
        private void Btn_addReceipt_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_Receipt addEdit_Receipt = new AddEdit_Receipt(null, GetModel(), GetEmployee());
            addEdit_Receipt.ShowDialog();
        }
        private void Btn_addEmp_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee(null);
            addEmployee.ShowDialog();
        }
        private void Btn_addCategory_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_Category addEdit_Category = new AddEdit_Category(null);
            addEdit_Category.ShowDialog();
        }
        private void BtnEditEmp_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee editPage = new AddEmployee((sender as Button).DataContext as Employee);
            editPage.ShowDialog();
        }
        private void BtnEditReceipt_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_Receipt addEditPageRec = new AddEdit_Receipt((sender as Button).DataContext as Receipt, GetModel(), GetEmployee());
            addEditPageRec.ShowDialog();
        }
        private void BtnEditModel_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_Model addEditPageMod = new AddEdit_Model((sender as Button).DataContext as Model_clothes, GetProductTypes());
            addEditPageMod.ShowDialog();
        }
        private void BtnEditCategory_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_Category addEdit_Category = new AddEdit_Category((sender as Button).DataContext as Category_product);
            addEdit_Category.ShowDialog();
        }

        private void BtnEditType_product_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_TypeProduct addEdit_TypeProduct = new AddEdit_TypeProduct((sender as Button).DataContext as Type_product, GetCategoryProducts());
            addEdit_TypeProduct.ShowDialog();
        }

        private void Btn_addType_product_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_TypeProduct addEdit_TypeProduct = new AddEdit_TypeProduct(null, GetCategoryProducts());
            addEdit_TypeProduct.ShowDialog();
        }

        private void Btn_deleteType_product_Click(object sender, RoutedEventArgs e)
        {
            var CurrentType = dgType_product.SelectedItems.Cast<Type_product>().ToList();

            if (dgType_product.SelectedItems is null)
            {
                System.Windows.MessageBox.Show("Тип одежды не выбран!", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error);
            }
            else
            {
                if (System.Windows.MessageBox.Show($"Вы действительно хотите удалить следующие {CurrentType.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FactoryEntities.GetContext().Type_product.RemoveRange(CurrentType);
                        FactoryEntities.GetContext().SaveChanges();
                        System.Windows.MessageBox.Show("Удаление типа одежды прошло успешно!");
                        dgType_product.ItemsSource = FactoryEntities.GetContext().Type_product.ToList();
                    }
                    catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message.ToString()); }
                }
            }
        }

        private void img_refreshType_product_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgType_product.ItemsSource = FactoryEntities.GetContext().Type_product.ToList();
        }
    }
}