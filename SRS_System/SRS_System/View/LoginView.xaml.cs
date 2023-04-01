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

namespace SRS_System.View
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
                bool uFound = context.User.Any(user => user.UserName == username && user.Password == password);
                if (uFound)
                {
                    OpenRelevent();
                    Close();
                }
                else
                {
                    MessageBox.Show("User Not Found");
                }
            }
        }

        public void OpenRelevent()
        {
            MainWindow main =new MainWindow();
            main.Show();
        }
    }
}
