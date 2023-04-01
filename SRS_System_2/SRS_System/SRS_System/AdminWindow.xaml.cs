using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SRS_System
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public List<User> UsersInDataBase { get; private set; }

        public AdminWindow()
        {
            InitializeComponent();
            read();
        }

        public void insert() 
        {
            using(DataBaseContext context=new DataBaseContext())
            {
                var firstName = txtfName.Text;
                var userName = txtuserName.Text;
                var password = txtpassword.Text;
                var lastName = txtlName.Text;
                int isAdmin = txtisAdmin.SelectedIndex;
              
               bool isAdminbool ;
                if(isAdmin==0)
                {
                     isAdminbool = true;
                }
                else
                {
                    isAdminbool = false;
                }


                if (firstName != null && userName != null && password != null && lastName != null)
                {
                    context.User.Add(new User() { fName = firstName, UserName = userName, Password = password, lName = lastName, IsAdmin = isAdminbool });
                    context.SaveChanges();
                }
            }

            read();
        }

        public void read() 
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                UsersInDataBase =context.User.ToList();
                UserList.ItemsSource = UsersInDataBase;
            }

        }


        public void update()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
               User selectedUser = UserList.SelectedItem as User;

                var firstName = txtfName.Text;
                var userName = txtuserName.Text;
                var password = txtpassword.Text;
                var lastName = txtlName.Text;
                int isAdmin = txtisAdmin.SelectedIndex;
                

                if (firstName != null && userName != null && password != null && lastName != null)
                {
                   User user =  context.User.Find(selectedUser.UserId);



                   user.fName = firstName;
                    user.UserName = userName;
                    user.Password = password;
                    user.lName = lastName;

                    bool isAdminbool;
                    if (isAdmin == 0)
                    {
                        isAdminbool = true;
                    }
                    else
                    {
                        isAdminbool = false;
                    }

                    user.IsAdmin = isAdminbool;
                    context.SaveChanges();
                }


            }
            read();
        }

        public void delete()
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                User selectedUser = UserList.SelectedItem as User;


                if (selectedUser != null)
                {
                    User user = context.User.Find(selectedUser.UserId);


                    context.Remove(user);
                    context.SaveChanges();  

                }
            

                    
            }
            read();

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            insert();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            delete();   
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            update();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            UserList.Items.Clear(); 
        }
    }
}
