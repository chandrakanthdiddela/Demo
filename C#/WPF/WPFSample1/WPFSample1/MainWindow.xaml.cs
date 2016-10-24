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

namespace WPFSample1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        Grid lobjgrid1;

        LinearGradientBrush lobjbrush;
        GradientStopCollection lcolstopcollection;
        public MainWindow()
        {
            InitializeComponent();

            lobjgrid1 = new Grid();
            lobjbrush = new LinearGradientBrush();

            GradientStop gs1 = new GradientStop();
            gs1.Offset = 0.5;

            gs1.Color = Colors.Blue;

            GradientStop gs2 = new GradientStop();
            gs2.Color = Colors.Yellow;

            gs2.Offset = 1.0;


            lobjbrush.GradientStops.Add(gs1);
            lobjbrush.GradientStops.Add(gs2);


            lobjgrid1.Background = lobjbrush;
            

            this.Content = lobjgrid1;
        
            
            

        }

     

    }
}
