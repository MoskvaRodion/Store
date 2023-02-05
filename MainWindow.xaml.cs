using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int count;

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var currentUser = db.user.FirstOrDefault(p => p.login == Login.Text && p.password == password.Password);
                count = 0; 
                var x = db.role.Where(p => p.id == User.CurrentUser.Role_id);


                if (currentUser != null)
                {                 
                    User.CurrentUser = currentUser;
                    var HomeForm = new home();
                    this.Hide();
                    HomeForm.Show();

                    foreach (Role name in x)
                    {
                        MessageBox.Show($"Вы авторизовались как {name.Name}");
                        count = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль введён неверно");
                    count += 1;
                    if (count == 3) 
                    {
                        Manager.mainFrame.Navigate(new capcha());
                    }
                }
            }
        }
    }
}
