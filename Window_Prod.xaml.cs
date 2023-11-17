using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace WpfApp10_Shop
{
    /// <summary>
    /// Логика взаимодействия для Window_Prod.xaml
    /// </summary>
    public partial class Window_Prod : Window
    {
        private Product selectedRow;
        public Window_Prod(Product myObject)
        {
            InitializeComponent();
            this.selectedRow = myObject;
            tbName.Text = selectedRow.Name;
            tbColor.Text = selectedRow.Color;
            tbDescr.Text = selectedRow.Description;
            tbPrice.Text = selectedRow.Price.ToString();
            tbQty.Text = selectedRow.Qty.ToString();


        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            using (InternetShopDbContext db = new InternetShopDbContext())
            {
                Product temp = new Product()
                {
                    Name = tbName.Text,
                    Color = tbColor.Text,
                    Description = tbDescr.Text,
                    Price = decimal.Parse(tbPrice.Text),
                    Qty = int.Parse(tbQty.Text)
                };
                try
                {
                    db.Products.Add(temp);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (InternetShopDbContext db = new InternetShopDbContext())
            {
                try
                {
                    var temp = db.Products.Find(selectedRow.Id);
                    if (temp is null) return;
                    temp.Name = tbName.Text;
                    temp.Color = tbColor.Text;
                    temp.Description = tbDescr.Text;
                    temp.Price = decimal.Parse(tbPrice.Text);
                    temp.Qty = int.Parse(tbQty.Text);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                this.Close();

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (InternetShopDbContext db = new InternetShopDbContext())
            {
                try
                {
                    db.Products.Remove(selectedRow);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            this.Close();
        }
    }
}
