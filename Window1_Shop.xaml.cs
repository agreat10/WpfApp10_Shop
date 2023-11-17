using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp10_Shop
{
    /// <summary>
    /// Логика взаимодействия для Window1_Shop.xaml
    /// </summary>
    public partial class Window1_Shop : Window
    {
        InternetShopDbContext db = new InternetShopDbContext();
        List<Product> products;
        List<Product> saleproducts = new List<Product>();
        int selectedIndex = -1;
        public Window1_Shop()
        {
            InitializeComponent();
            products = db.Products.ToList();
            dataGrid.ItemsSource = products;
            dataGrid1.ItemsSource = saleproducts;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndex = dataGrid.SelectedIndex;
            var selectedRow = dataGrid.SelectedItem as Product;
            if (selectedRow != null)
            {
                // Создать новый экземпляр объекта для второго DataGrid
                var newRow = new Product
                {
                    Name = selectedRow.Name,
                    Color = selectedRow.Color,
                    Price = selectedRow.Price,
                    Description = selectedRow.Description,
                    Qty = selectedRow.Qty
                    // Заполните остальные свойства значениями из выбранной строки
                };

                // Добавить новую строку во второй DataGrid

                int temp = int.Parse(numericUpDown.Text);

                if (!saleproducts.Any(item => item.Name == newRow.Name))
                {
                    saleproducts.Add(new Product { Name= newRow.Name, Color = newRow.Color, Description = newRow.Description, Qty = 0});
                    numericUpDown.Text = "0";
                }
                else
                {
                    var tempProduct = saleproducts.FirstOrDefault(p => p.Name == newRow.Name);
                    if (tempProduct != null)
                    {
                        temp = tempProduct.Qty;
                        numericUpDown.Text = temp.ToString();
                    }

                }
                dataGrid1.Items.Refresh();
                
            }
        }
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получить доступ к DataGrid

            var selectedRow = dataGrid1.SelectedItem as Product;

            // Проверить, что DataGrid не пустой
            if (dataGrid != null)
            {
                // Найти строку с именем "Иван"
                foreach (var item in dataGrid.Items)
                {
                    if (item is Product dataItem && dataItem.Name == selectedRow.Name)
                    {
                        // Выбрать найденную строку в DataGrid
                        dataGrid.SelectedItem = item;
                        dataGrid.ScrollIntoView(item);
                        dataGrid1.Items.Refresh();
                        dataGrid.Items.Refresh();
                        break;
                    }
                }
            }
        }

        private void BtnUP_Click(object sender, RoutedEventArgs e)
        {
            int temp = int.Parse(numericUpDown.Text);
            if (selectedIndex >= 0 && selectedIndex < saleproducts.Count)
            {
                Product product = products[selectedIndex];
                if (product.Qty > 0)
                {
                    temp++;
                    numericUpDown.Text = temp.ToString();
                    product.Qty = product.Qty - 1;
                }
                var tempProduct = saleproducts.FirstOrDefault(p => p.Name == product.Name);
                if (tempProduct != null)
                {
                    tempProduct.Qty = temp;
                   // tempProduct.AllPrice = temp * tempProduct.Price;
                }
                decimal totalCost = 0.0m;
                //foreach (SaleProduct products in Product)
                //{
                //    totalCost += products.AllPrice;
                //}
                //accuredForCafe = totalCost;
                //TxtCafe.Text = totalCost.ToString();

                //СompletionAllPrices();
            }
            dataGrid1.Items.Refresh();
            dataGrid.Items.Refresh();
        }

        

        private void BtnDOWN_Click(object sender, RoutedEventArgs e)
        {
            int temp = int.Parse(numericUpDown.Text);
            if (selectedIndex >= 0 && selectedIndex < products.Count)
            {
                Product product = products[selectedIndex];
                if (temp > 0)
                {
                    temp--;
                    numericUpDown.Text = temp.ToString();
                    product.Qty = product.Qty + 1;
                }
                var tempProduct = saleproducts.FirstOrDefault(p => p.Name == product.Name);
                if (tempProduct != null)
                {
                    tempProduct.Qty = temp;
                    //tempProduct.AllPrice = temp * tempProduct.Price;
                }
                decimal totalCost = 0.0m;
                //foreach (SaleProduct products in ViewModel.saleproductsObserv)
                //{
                //    totalCost += products.AllPrice;
                //}
                //accuredForCafe = totalCost;
                //TxtCafe.Text = totalCost.ToString();
                //СompletionAllPrices();
            }
            dataGrid1.Items.Refresh();
            dataGrid.Items.Refresh();
        }
    }
}
