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

namespace ContentControlSample
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        //Grid lobjparentGrid;
        //ColumnDefinitionCollection lcolumncollection;
        //ColumnDefinition c1, c2;
        public Window5()
        {
            InitializeComponent();

            DrawGrid();


           
        }

       public void DrawGrid()
        {
            Grid lobjgrid = new Grid();
            lobjgrid.Name = "ParenGrid";
            lobjgrid.Height = 200;
            lobjgrid.Width = 200;
            lobjgrid.ShowGridLines = true;
            lobjgrid.Margin = new Thickness(10);
            lobjgrid.VerticalAlignment = VerticalAlignment.Top;
            lobjgrid.HorizontalAlignment = HorizontalAlignment.Center;

            ColumnDefinition c1 = new ColumnDefinition();
             ColumnDefinition c2 = new ColumnDefinition();
             ColumnDefinition c3 = new ColumnDefinition();

            c1.Width = new GridLength(50);
            c2.Width = new GridLength(50);
            c3.Width = GridLength.Auto;

            lobjgrid.ColumnDefinitions.Add(c1);
            lobjgrid.ColumnDefinitions.Add(c2);
            lobjgrid.ColumnDefinitions.Add(c3);

            this.Content = lobjgrid;

        }
    }
}
