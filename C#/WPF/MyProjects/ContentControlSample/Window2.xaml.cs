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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder content1 = new StringBuilder();
            int count=0;
            foreach (var ctrl in this.stackpanel1.Children)
            {

                if (ctrl is RadioButton)
                {
                    RadioButton r=(RadioButton)ctrl;
                    if(r.IsChecked==true)
                    {
                        count = count + 1;
                       // content1.Append(r.Content.ToString);

                        //content += r.Content.ToString;
                    }
                }
            }

            MessageBox.Show(count.ToString());
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
