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
            //tbFame.Text = selectedRow.Fname.ToString();
            //tbMame.Text = selectedRow.Mname.ToString();
            //tbLame.Text = selectedRow.Lname.ToString();
            //tbPost.Text = selectedRow.Post.ToString();
            //tbSalary.Text = selectedRow.Salary.ToString();
            //tbPSalary.Text = selectedRow.PriorSalary.ToString();
            //tbPhone.Text = selectedRow.Phone.ToString();



        }
    }
}
