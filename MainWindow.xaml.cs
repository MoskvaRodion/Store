using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
            captchs();
        }
 
        private void captchs()
        {
            Random rand = new Random();
            int num = rand.Next(6, 8);
            string captcha = "";
            int totl = 0;
            do
            {
                int chr = rand.Next(48, 123);
                if ((chr >= 48 && chr <= 58) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    captcha += (char)chr;
                    totl++;
                    if (totl == num)
                        break;
                    {

                    }
                }
            } while (true);
            capchaBlock.Text = captcha;
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var currentUser = db.user.FirstOrDefault(p => p.login == Login.Text && p.password == password.Password);
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
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль введён неверно");
                }
            }
        }
        private void btnCapcha_Click(object sender, RoutedEventArgs e)
        {
            var box = capchaBox.Text;
            var block = capchaBlock.Text;
            if (box == block)
            {
                MessageBox.Show("Капча пройдена");
                btn_login.IsEnabled = true;
            }
            else
            {
                captchs();
            }
        }

    }
}
