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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {

        StackPanel stackpanel1, stackpanel2;
        RadioButton rd1, rd2, rd3, rd4, rd5;
        Button btn1, btn2;


        public Window3()
        {
            InitializeComponent();

            this.stackpanel1 = new StackPanel();

            stackpanel1.Margin = new Thickness(10);

            stackpanel1.Name = "Friststackpanel";


          

            this.rd1 = new RadioButton();

            rd1.Content = "C";
            rd1.Margin = new Thickness(10);

            this.rd2 = new RadioButton();

            rd2.Content = "C#";
            rd2.Margin = new Thickness(10);
            this.rd3 = new RadioButton();
            rd3.Content = "VB";
            rd3.Margin = new Thickness(10);
            this.rd4 = new RadioButton();
            rd4.Content = "java";
            rd4.Margin = new Thickness(10);
            this.rd5 = new RadioButton();
            rd5.Content = "python";
            rd5.Margin = new Thickness(10);

            stackpanel1.Children.Add(rd1);
            stackpanel1.Children.Add(rd2);
            stackpanel1.Children.Add(rd3);
            stackpanel1.Children.Add(rd4);
            stackpanel1.Children.Add(rd5);
            this.btn1 = new Button();
            this.btn2 = new Button();

            btn1.Content = "Submit";
            btn1.Margin = new Thickness(10);
            btn1.Click += new RoutedEventHandler(Btn_submit);
            
            btn2.Content = "Cancel";
            btn2.Margin = new Thickness(10);
           
            this.stackpanel2 = new StackPanel();
            stackpanel2.Children.Add(btn1);
            stackpanel2.Children.Add(btn2);
            this.stackpanel1.Children.Add(stackpanel2);
            this.Content = stackpanel1;
            //this.Content(stackpanel2);
          // this.children.add(stackpanel1);
          // this.children.add(stackpanel1);
           // this.AddChild(stackpanel1);

        }

        private void Btn_submit(object sender, RoutedEventArgs e)
        {
        }
    }
}
