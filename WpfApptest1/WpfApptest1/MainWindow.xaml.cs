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

namespace WpfApptest1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PrinterUserControl currentPrinter;
        Queue<PrinterUserControl> queue;
        public MainWindow() 
        {


            InitializeComponent();
            queue = new Queue<PrinterUserControl>();

            foreach (Control item in printersGrid.Children)
            {
                if(item is PrinterUserControl)
                {
                    PrinterUserControl printer = item as PrinterUserControl; //

                    queue.Enqueue(printer);
                }
            }
            currentPrinter = queue.Dequeue();
        }
    }
}
