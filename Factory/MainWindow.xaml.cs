using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Factory.ViewModels;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBase dataBase = new DataBase();
        DispatcherTimer timer; // Таймер.
        int time = 10;
        public static string id;

        private readonly LoginPictureVisibilityViewModel _loginPictureVisibilityViewModel = new LoginPictureVisibilityViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _loginPictureVisibilityViewModel;

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        // Работа таймера.
        private void timer_Tick(object sender, EventArgs e)
        {
            if(time >= 0)
            {
                labelTimer.Content = "Подождите " + time + " секунд";
                time--;
            }
            else 
            {
                timer.Stop();
                labelTimer.Content = "";
                watermarkCaptcha.IsEnabled = true;
                tBoxCaptcha.IsEnabled = true;
                btn_captcha.IsEnabled = true;
                time = 10;
            }   
        }

        private void btn_sign_Click(object sender, RoutedEventArgs e)
        {
            dataBase.openConnection();

            string query1 = "SELECT post FROM Employee WHERE [login_user] =\'" + tBoxLogin.Text + "\' and [password_user] =\'" + tBoxPassword.Password + "\'";

            SqlCommand command = new SqlCommand(query1, dataBase.getConnection());

            if (command.ExecuteScalar() != null)
            {
                _ = HelperUser.GetEmployee(tBoxLogin.Text, tBoxPassword.Password);
                _ = HelperUser.GetImageData();

                if (command.ExecuteScalar().ToString() == "Системный администратор")
                {
                    PageSysAdmin pageSysAdmin = new PageSysAdmin();
                    pageSysAdmin.Show();

                    this.Hide();
                }
                else if (command.ExecuteScalar().ToString() == "Кладовщик")
                {
                    PageRecipient pageRecipient = new PageRecipient();
                    pageRecipient.Show();

                    this.Hide();
                }
                else if (command.ExecuteScalar().ToString() == "Администратор")
                {
                    PageAdministrator pageAdministrator = new PageAdministrator();
                    pageAdministrator.Show();

                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _loginPictureVisibilityViewModel.Visibility = Visibility.Visible;
                watermarkCaptcha.Visibility = Visibility.Visible;
                tBoxCaptcha.Visibility = Visibility.Visible;
                btn_captcha.Visibility = Visibility.Visible;
                btn_sign.IsEnabled = false;
                image_eye.IsEnabled = false;
            }
            dataBase.closeConnection();
        }

        private void btn_captcha_Click(object sender, RoutedEventArgs e)
        {
            if (image_captcha.IsVisible == true && tBoxCaptcha.IsVisible == true)
            {
                if (tBoxCaptcha.Text == "dsp4dks")
                {
                    tBoxCaptcha.Text = "";
                    _loginPictureVisibilityViewModel.Visibility = Visibility.Hidden;
                    watermarkCaptcha.Visibility = Visibility.Hidden;
                    tBoxCaptcha.Visibility = Visibility.Hidden;
                    btn_captcha.Visibility = Visibility.Hidden;
                    btn_sign.IsEnabled = true;
                    tBoxLogin.IsEnabled = true;
                    tBoxPassword.IsEnabled = true;
                    image_eye.IsEnabled = true;
                }
                else
                {
                    tBoxCaptcha.Text = "";                   
                    tBoxLogin.IsEnabled = false;
                    tBoxPassword.IsEnabled = false;
                    image_eye.IsEnabled = false;
                    watermarkCaptcha.IsEnabled = false;
                    tBoxCaptcha.IsEnabled = false;
                    btn_captcha.IsEnabled = false;
                    timer.Start();
                }
            }
        }

        private void tBoxCaptcha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tBoxCaptcha.Text))
            {
                tBoxCaptcha.Visibility = Visibility.Collapsed;
                watermarkCaptcha.Visibility = Visibility.Visible;
            }
        }

        private void watermarkCaptcha_GotFocus(object sender, RoutedEventArgs e)
        {
            watermarkCaptcha.Visibility = Visibility.Collapsed;
            tBoxCaptcha.Visibility = Visibility.Visible;
            tBoxCaptcha.Focus();
        }

        private void image_eye_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (tBoxVisiblePassword.Visibility == Visibility.Hidden) 
            {
                tBoxVisiblePassword.Text = tBoxPassword.Password;
                tBoxVisiblePassword.Visibility = Visibility.Visible;
                tBoxPassword.Visibility = Visibility.Hidden;
                image_eye.Source = new BitmapImage(new Uri($"/Resources/eye_hide.png", UriKind.Relative));
            }
            else
            {
                tBoxPassword.Password = tBoxVisiblePassword.Text; 
                tBoxVisiblePassword.Visibility = Visibility.Hidden;
                tBoxPassword.Visibility = Visibility.Visible;
                image_eye.Source = new BitmapImage(new Uri($"/Resources/eye_visible.png", UriKind.Relative));
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}