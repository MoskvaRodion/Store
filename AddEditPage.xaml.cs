using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Glasses currentGlasses = new Glasses();


        public AddEditPage(Glasses selectedGlasses)
        {
            InitializeComponent();
            if (selectedGlasses != null)
                currentGlasses = selectedGlasses;

            DataContext = currentGlasses;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentGlasses.nazvanie))
                errors.AppendLine("Укажите название очков");
            if (string.IsNullOrWhiteSpace(Convert.ToString(currentGlasses.price)))
                errors.AppendLine("Укажите цену");
            if (string.IsNullOrWhiteSpace(Convert.ToString(currentGlasses.type)))
                errors.AppendLine("Укажите модель очков");
            if (string.IsNullOrWhiteSpace(currentGlasses.model))
                errors.AppendLine("Укажите модель очков");
            if (string.IsNullOrWhiteSpace(currentGlasses.pol))
                errors.AppendLine("Укажите пол клиента");
            if (string.IsNullOrWhiteSpace(Convert.ToString(currentGlasses.price_on_glass)))
                errors.AppendLine("Укажите цену линз очков");
            if (string.IsNullOrWhiteSpace(currentGlasses.proizvoditel))
                errors.AppendLine("Укажите производителя очков");
            if (string.IsNullOrWhiteSpace(currentGlasses.color))
                errors.AppendLine("Укажите цвет очков");
            if (string.IsNullOrWhiteSpace(Convert.ToString(currentGlasses.actual)))
                errors.AppendLine("Укажите актуальность очков");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (currentGlasses.id == 0)
            {
                ApplicationContext.GetContext().glasses.Add(currentGlasses);
            }
            ApplicationContext.GetContext().SaveChanges();



            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.SaveChanges();
                }
                MessageBox.Show("Информация сохранения!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.GoBack();

        }

/*        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
            string strFinam = ofd.FileName;
        }*/
    }
}
