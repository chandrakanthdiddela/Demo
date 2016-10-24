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

namespace Calculatorsample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //
            // button
            //
            UIElementCollection lobjuielement = this.Grid1.Children;

           UIElementCollection lobjbuttoncollection=  this.unifromgrid1.Children;
            


        }

        private void listofbutton()
        {

            foreach (Control c in this.unifromgrid1.Children)
            {
                if (c is Button)
                {
                    Button btname = (Button)c;

                    btname.Content.ToString
                }
            }

        }


    }
}
