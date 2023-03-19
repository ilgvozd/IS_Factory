using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Button = System.Windows.Controls.Button;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для PageSysAdmin.xaml
    /// </summary>
    public partial class PageSysAdmin : Window
    {
        private readonly ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        byte[] image_bytes = null;

        public PageSysAdmin()
        {
            InitializeComponent();

            dgEmployee.ItemsSource = _employees;

            if (HelperUser.Employee.image_ != null)
            {
                ImageSource imgsour = (ImageSource)new ImageSourceConverter().ConvertFrom(HelperUser.Employee.image_);
                image_myphoto.Source = imgsour;
            }

            label_surname.Content = HelperUser.Employee.surname_employee;
            label_name.Content = HelperUser.Employee.name_employee;
            label_patronymic.Content = HelperUser.Employee.patronymic_employee;
            label_date.Content = HelperUser.Employee.date_birthday.ToString("dd:MM:yyyy");
            label_number.Content = HelperUser.Employee.number_phone;
            label_email.Content = HelperUser.Employee.email;
            label_post.Content = HelperUser.Employee.post;
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new FactoryEntities())
            {
                var emps = context.Employee.ToList();
                _employees.Clear();
                emps.ForEach(emp => _employees.Add(emp));
                dgEmployee.Items.Refresh();
            }
        }

        private void image_exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow auth = new MainWindow();
            auth.Show();

            this.Hide();
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

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee(null);
            addEmployee.ShowDialog();
        }

        private void img_refresh_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgEmployee.ItemsSource = FactoryEntities.GetContext().Employee.ToList();
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
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

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee editPage = new AddEmployee((sender as Button).DataContext as Employee);
            editPage.ShowDialog();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FactoryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgEmployee.ItemsSource = FactoryEntities.GetContext().Employee.ToList();
            }
        }
    }
}