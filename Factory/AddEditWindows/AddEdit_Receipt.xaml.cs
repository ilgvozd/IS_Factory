using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System;
using System.Text;
using System.Collections.Generic;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для AddEdit_Receipt.xaml
    /// </summary>
    public partial class AddEdit_Receipt : Window
    {
        private Receipt _currentRec = new Receipt();
        private Receipt workCopy = new Receipt();

        public AddEdit_Receipt(Receipt selectedReceipt, IEnumerable<Model_clothes> models, IEnumerable<Employee> employees)
        {
            InitializeComponent();

            if (models is null)
            {
                throw new ArgumentNullException(nameof(models));
            }

            if (employees is null)
            {
                throw new ArgumentNullException(nameof(employees));
            }

            if (!models.Any())
            {
                throw new InvalidOperationException("Список моделей пуст!");
            }

            if (!employees.Any())
            {
                throw new InvalidOperationException("Список сотрудников пуст!");
            }

            if (selectedReceipt != null)
            {
                _currentRec = selectedReceipt;
                workCopy = new Receipt()
                { 
                    id_receipt = selectedReceipt.id_receipt,
                    id_model = selectedReceipt.id_model,
                    id_employee = selectedReceipt.id_employee,
                    date_receipt = selectedReceipt.date_receipt,
                    amount = selectedReceipt.amount,
                };

                addEditReceipt.Title = "Редактирование";
            }
            else
            {
                addEditReceipt.Title = "Добавление";
            }

            DataContext = workCopy;
            cBox_model.ItemsSource = models;
            cBox_employee.ItemsSource = employees;

            if (workCopy.id_model == 0)
            {
                workCopy.id_model = models.First().id_model;
            }
            if (workCopy.id_employee == 0)
            {
                workCopy.id_employee = employees.First().id_employee;
            }
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (workCopy.id_model == 0)
                errors.AppendLine("Укажите модель");
            if (workCopy.id_employee == 0)
                errors.AppendLine("Укажите кладовщика");
            if (workCopy.date_receipt == null)
                errors.AppendLine("Укажите дату поступления");
            if (workCopy.amount <= 0)
                errors.AppendLine("Укажите количество");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentRec.id_receipt == 0)
            {
                FactoryEntities.GetContext().Receipt.Add(workCopy);
                MessageBox.Show("Поступление добавлено в базу.");
            }
            else
            {
                _currentRec.id_receipt = workCopy.id_receipt;
                _currentRec.id_model = workCopy.id_model;
                _currentRec.id_employee = workCopy.id_employee;
                _currentRec.date_receipt = workCopy.date_receipt;
                _currentRec.amount = workCopy.amount;
            }

            try
            {
                FactoryEntities.GetContext().SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            this.Close();
        }

        private void DatePickerTextBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dP_date.IsDropDownOpen = true;
        }

        private void tbox_amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}