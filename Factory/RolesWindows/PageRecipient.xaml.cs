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
    /// Логика взаимодействия для PageRecipient.xaml
    /// </summary>
    public partial class PageRecipient : Window
    {
        private readonly ObservableCollection<Receipt> receipts = new ObservableCollection<Receipt>();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        byte[] image_bytes = null;

        public PageRecipient()
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
            dgReceipt.ItemsSource = FactoryEntities.GetContext().Receipt.ToList();

            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgModel_clothes.ItemsSource = FactoryEntities.GetContext().Model_clothes.ToList();
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

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_Receipt addEditPageRec = new AddEdit_Receipt((sender as Button).DataContext as Receipt, GetModel(), GetEmployee());
            addEditPageRec.ShowDialog();
        }
        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            AddEdit_Model addEditPageMod = new AddEdit_Model((sender as Button).DataContext as Model_clothes, GetProductTypes());
            addEditPageMod.ShowDialog();
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

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_Receipt addEdit_Receipt = new AddEdit_Receipt(null, GetModel(), GetEmployee());
            addEdit_Receipt.ShowDialog();
        }
        private void Btn_add_model_Click(object sender, RoutedEventArgs e)
        {
            AddEdit_Model addEdit_Model = new AddEdit_Model(null, GetProductTypes());
            addEdit_Model.ShowDialog();
        }
        private void Btn_delete_Click(object sender, RoutedEventArgs e)
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
        private void Btn_delete_model_Click(object sender, RoutedEventArgs e)
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

        private void img_refresh_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgReceipt.ItemsSource = FactoryEntities.GetContext().Receipt.ToList();
        }

        private void img_refresh_model_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgModel_clothes.ItemsSource = FactoryEntities.GetContext().Model_clothes.ToList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgReceipt.ItemsSource = FactoryEntities.GetContext().Receipt.ToList();
                dgModel_clothes.ItemsSource = FactoryEntities.GetContext().Model_clothes.ToList();
            }
        }
    }
}