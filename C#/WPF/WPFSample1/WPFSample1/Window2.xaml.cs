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

namespace WPFSample1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        Grid lobjGrid1;

        TextBlock t1, t2, t3;

        RowDefinition rd1, rd2, rd3;
        public Window2()
        {
            InitializeComponent();

            this.lobjGrid1 = new Grid();


            this.lobjGrid1.ShowGridLines = true;


            this.rd1 = new RowDefinition();
            GridLength lobjgridlength = new GridLength();

            rd1.Height = GridLength.Auto;
            
            this.rd2 = new RowDefinition();

            rd2.Height = new GridLength(30,GridUnitType.Star);
            this.rd3 = new RowDefinition();

            rd3.Height = GridLength.Auto;
            this.lobjGrid1.RowDefinitions.Add(rd1);
            this.lobjGrid1.RowDefinitions.Add(rd2);
            this.lobjGrid1.RowDefinitions.Add(rd3);
            this.t1 = new TextBlock();
            t1.Text = "Hello";

            t1.FontSize = 30;
           
            this.t2 = new TextBlock();

            t2.Text = "WPF";

            t2.FontSize = 30;
            this.t3 = new TextBlock();
            t3.Text = "World";

            t3.FontSize = 30;


            Grid.SetRow(t1, 0);
            Grid.SetRow(t2, 1);
            Grid.SetRow(t3, 2);
            Grid.SetColumn(t1, 0);
            Grid.SetColumn(t2, 1);
            Grid.SetColumn(t3, 2);
            this.lobjGrid1.Children.Add(t1);
            this.lobjGrid1.Children.Add(t2);
            this.lobjGrid1.Children.Add(t3);
            this.Content= lobjGrid1;

        }
    }
}
