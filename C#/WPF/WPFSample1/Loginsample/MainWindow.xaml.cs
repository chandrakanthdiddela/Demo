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

namespace Loginsample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        StackPanel sp1;
        Label L1;
        TextBox T1;
        StackPanel sp2;
        Button b1;

 

        public MainWindow()
        {
            InitializeComponent();

            this.sp1 = new StackPanel();

            this.L1 = new Label();

            L1.Content = "name";
            L1.Width = 50;
            L1.Height = 50;

            this.T1 = new TextBox();
            T1.Width = 100;
            T1.Height = 50;
            this.b1 = new Button();

            b1.Content = "submit";
            b1.Width = 100;
            b1.Height = 50;
            this.sp2 = new StackPanel();
            sp2.Children.Add(L1);
            sp2.Children.Add(T1);

            this.sp1.Children.Add(sp2);
            this.sp1.Children.Add(b1);
            this.Content = sp1;




        }
    }
}
