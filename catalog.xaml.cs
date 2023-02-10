﻿using System;
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
using System.IO;
using System.Windows.Media.Animation;

namespace Store
{

    public partial class catalog : Page
    {
        public catalog()
        {
            InitializeComponent();
            
            ImportPhoto();

            using (ApplicationContext context = new ApplicationContext())
            {
                Tovars.ItemsSource = context.glasses.ToList(); 
                
            }

            var allProducts = ApplicationContext.GetContext().material_type.ToList();
            allProducts.Insert(0, new Material
            {
                Name_type = "Все товары"
            });
            ComboType.ItemsSource = allProducts;

            CheckActual.IsChecked = false;
            ComboType.SelectedIndex = 0;

            UpdateProducte();

        }
        private static void ImportPhoto()
        {
            var images = Directory.GetFiles(@"C:\Users\mosko\source\repos\Store\Resources\");
            using (ApplicationContext db = new ApplicationContext())
            {
                var entitys = db.glasses;

                foreach (var entity in entitys)
                {
                    try
                    {
                        entity.Image = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(entity.nazvanie)));
                        db.glasses.Update(entity);
                    }
                    catch
                    {
                        entity.Image = null;
                    }
                }
                db.SaveChanges();
            }
        }
        private void UpdateProducte()
        {
            var currentProd = ApplicationContext.GetContext().glasses.ToList();
            int maxCount = currentProd.Count;

            if (ComboType.SelectedIndex > 0)
                currentProd = currentProd.Where(p => p.type == ComboType.SelectedIndex).ToList();



            currentProd = currentProd.Where(p => p.nazvanie.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (CheckActual.IsChecked.Value)
                currentProd = currentProd.Where(p => p.actual).ToList();
                

            Tovars.ItemsSource = currentProd.OrderBy(p => p.price).ToList();
            _Count_.Content = Convert.ToString(Tovars.Items.Count + "/" + maxCount);
        }


        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducte();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducte();
        }
        private void CheckActual_checked(object sender, RoutedEventArgs e)
        {
            UpdateProducte();
        }

        private void ButtonAddList_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new AddEditPage(null));
        }

        private void ButtonEditList_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Glasses));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var glassRemove = Tovars.SelectedItems.Cast<Glasses>().ToList();

            if (MessageBox.Show($" Удалить { glassRemove.Count() } элементов" , "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ApplicationContext.GetContext().glasses.RemoveRange(glassRemove);
                    ApplicationContext.GetContext().SaveChanges();

                    MessageBox.Show("Удалены данные");

                    Tovars.ItemsSource = ApplicationContext.GetContext().glasses.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                
            }
        }

        private void update_click(object sender, RoutedEventArgs e)
        {
            Tovars.ItemsSource = ApplicationContext.GetContext().glasses.ToList();
        }
    }
}
