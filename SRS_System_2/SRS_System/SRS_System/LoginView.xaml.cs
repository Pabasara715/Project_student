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
using System.Windows.Shapes;

namespace SRS_System
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUser.Text;
            var password = txtPassword.Password;

            using (DataBaseContext context = new DataBaseContext())
            {  
                var user = context.User.FirstOrDefault(user => user.UserName == username && user.Password == password);
                if (user !=null)
                {
                    var userRole = user.IsAdmin;//check the whether admin or not
                    int intRole = userRole ? 1 : 0;//boot converted into interger
                    OpenRelevent(intRole);
                    Close();
                }
                else
                {
                    MessageBox.Show("User Not Found");
                }
            }
        }

        public void OpenRelevent(int role)
        {
            if (role == 1)
            {
                AdminWindow Admin = new AdminWindow();
                Admin.Show();
            }
            else
            {
                MainWindow main = new MainWindow();
                main.Show();
            }
        }

        private void usernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateLoginButton();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UpdateLoginButton();
        }

        private void UpdateLoginButton()
        {
            btnLogin.IsEnabled = !string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPassword.Password);
        }



    }
}
