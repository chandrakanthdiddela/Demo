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

namespace WPFEventsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected int eventcounter = 0;
        private void somethingclicked(object sender , RoutedEventArgs e)
        {
            eventcounter = eventcounter + 1;

            string message = "#" + eventcounter.ToString() + ":\r\n" +
                "sender" + sender.ToString() + ":\r\n" +
                "source" + e.Source + ":\r\n" +
                "original source " + e.OriginalSource;

            listmessages.Items.Add(message);

            e.Handled = (bool)checkhandle.IsChecked;
        }

    }
}
