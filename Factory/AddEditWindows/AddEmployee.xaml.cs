using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;
using System.IO;
using System;
using System.Text;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        byte[] image_bytes = null;
        private Employee _currentEmp = new Employee();

        public AddEmployee(Employee selectedEmp)
        {
            InitializeComponent();

            if (selectedEmp != null)
            {
                _currentEmp = selectedEmp;
                addEditPage.Title = "Редактирование";
            }
            else
            {
                addEditPage.Title = "Добавление сотрудника";
            }

            DataContext = _currentEmp;

            if (_currentEmp.image_ == null)
            {
                label_image.Visibility = Visibility.Visible;
                image_myphoto.Visibility = Visibility.Hidden;
            }
            else
            {
                label_image.Visibility = Visibility.Hidden;
                image_myphoto.Visibility = Visibility.Visible;
            }
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentEmp.surname_employee))
                errors.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(_currentEmp.name_employee))
                errors.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(_currentEmp.patronymic_employee))
                errors.AppendLine("Укажите отчество");
            if (_currentEmp.date_birthday == null)
                errors.AppendLine("Укажите дату рождения");
            if (string.IsNullOrWhiteSpace(_currentEmp.number_phone))
                errors.AppendLine("Укажите номер телефона");
            if (string.IsNullOrWhiteSpace(_currentEmp.email))
                errors.AppendLine("Укажите адрес электронной почты");
            if (string.IsNullOrWhiteSpace(_currentEmp.post))
                errors.AppendLine("Укажите должность");
            if (string.IsNullOrWhiteSpace(_currentEmp.login_user))
                errors.AppendLine("Укажите логин пользователя");
            if (string.IsNullOrWhiteSpace(_currentEmp.password_user))
                errors.AppendLine("Укажите пароль пользователя");
            if (image_myphoto.Source == null)
                errors.AppendLine("Добавьте фотографию");

            if (errors.Length > 0)
            {
                System.Windows.MessageBox.Show(errors.ToString());
                return;
            }

            if (image_bytes == null)
            {
                image_bytes = _currentEmp.image_;
            }
            else {
                _currentEmp.image_ = image_bytes;
            } 

            if (_currentEmp.id_employee == 0)
            {
                FactoryEntities.GetContext().Employee.Add(_currentEmp);
                System.Windows.MessageBox.Show("Сотрудник добавлен в базу.");
            }    

            try
            {
                FactoryEntities.GetContext().SaveChanges();
            }
            catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message.ToString()); }

            this.Close();
        }

        private void label_image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image_bytes = File.ReadAllBytes(openFileDialog.FileName);
                ImageSource image = (ImageSource)new ImageSourceConverter().ConvertFrom(image_bytes);

                label_image.Visibility = Visibility.Hidden;
                image_myphoto.Visibility = Visibility.Visible;
                image_myphoto.Source = image;
            }
            else
            {
                System.Windows.MessageBox.Show("Фото не выбрано!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DatePickerTextBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dP_date.IsDropDownOpen = true;
        }
    }
}