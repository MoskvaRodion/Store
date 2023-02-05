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

namespace Store
{
    /// <summary>
    /// Логика взаимодействия для capcha.xaml
    /// </summary>
    public partial class capcha : Window
    {
        public capcha()
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

        private void btnCapcha_Click(object sender, RoutedEventArgs e)
        {
            var box = capchaBox.Text;
            var block = capchaBlock.Text;
            if (box == block)
            {
                MessageBox.Show("Капча пройдена");
            }
            else
            {
                captchs();
            }
        }
    }
}
