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
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace WpfApp10_Shop
{
    /// <summary>
    /// Логика взаимодействия для Window_Empl.xaml
    /// </summary>
    public partial class Window_Empl : Window
    {
        
        
           private Employee selectedRow;
        public Window_Empl(Employee myObject)
        {
            InitializeComponent();
            this.selectedRow = myObject;
            tbFame.Text = selectedRow.Fname.ToString();
            tbMame.Text = selectedRow.Mname.ToString();
            tbLame.Text = selectedRow.Lname.ToString();
            tbPost.Text = selectedRow.Post.ToString();
            tbSalary.Text = selectedRow.Salary.ToString();
            tbPSalary.Text = selectedRow.PriorSalary.ToString();           
            tbPhone.Text = selectedRow.Phone.ToString();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            using (InternetShopDbContext db = new InternetShopDbContext())
            {
                Employee temp = new Employee()
                {
                    Fname = tbFame.Text,
                    Mname = tbMame.Text,
                    Lname = tbLame.Text,
                    Post = tbPost.Text,
                    Salary = decimal.Parse(tbSalary.Text),
                    PriorSalary = decimal.Parse(tbPSalary.Text),
                    Phone = tbPhone.Text
                };
                try
                {
                    db.Employees.Add(temp);
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
                   var temp = db.Employees.Find(selectedRow.Id);
                    if (temp is null) return;
                    temp.Fname = tbFame.Text;
                    temp.Mname = tbMame.Text;
                    temp.Lname = tbLame.Text;
                    temp.Post = tbPost.Text;
                    temp.Salary = decimal.Parse(tbSalary.Text);
                    temp.PriorSalary = decimal.Parse(tbPSalary.Text);
                    temp.Phone = tbPhone.Text;
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
                    db.Employees.Remove(selectedRow);
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
