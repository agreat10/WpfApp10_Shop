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

namespace WpfApp10_Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InternetShopDbContext db = new InternetShopDbContext();
        int selectedIndex = -1;
        public MainWindow()
        {
            InitializeComponent();
            InitializeComponent();
            List<string> data = new List<string>
            {
                "1.Покупатели",
                "2.Сотрудники",
                "3.Продукция",                
                "4.Покупки"
            };
            myListBox.ItemsSource = data;
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndex = myListBox.SelectedIndex;
            if (selectedIndex != -1)
            {// проверка индекса выбранного элемента
                switch (selectedIndex)
                {

                    case 0:
                        var p0 = db.Customers.ToList();
                        dataGrid1.ItemsSource = p0;
                        break;

                    case 1:
                        var p1 = db.Employees.ToList();
                        dataGrid1.ItemsSource = p1;
                        break;
                    case 2:
                        var p2 = db.Products.ToList();
                        dataGrid1.ItemsSource = p2;
                        break;

                    default:
                        break;
                }  
            }

        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndexDG = dataGrid1.SelectedIndex;
            Title = selectedIndexDG.ToString();
            switch (selectedIndex)
            {
                case 0: break;
                case 1:
                    {
                        var selectedRow = dataGrid1.SelectedItem as Employee;
                        if (selectedRow != null)
                        {
                            Window_Empl mw = new Window_Empl(selectedRow);
                            mw.ShowDialog();
                            using (InternetShopDbContext db = new InternetShopDbContext())
                            {
                                var temp = db.Employees.ToList();                               
                                dataGrid1.ItemsSource = temp;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        var selectedRow = dataGrid1.SelectedItem as Product;
                        if (selectedRow != null)
                        {
                            Window_Prod mw = new Window_Prod(selectedRow);
                            mw.ShowDialog();
                            using (InternetShopDbContext db = new InternetShopDbContext())
                            {
                                var temp = db.Products.ToList();
                                dataGrid1.ItemsSource = temp;
                            }
                        }
                    }
                     break;
                    
                default:
                    break;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Window1_Shop mw = new Window1_Shop();
            mw.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Product> pp = db.Products.ToList();

            dataGrid1.ItemsSource = pp;
        }
    }
}
