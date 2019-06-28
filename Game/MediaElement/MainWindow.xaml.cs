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

namespace MediaElement
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            //timerStart();
            MP.MediaOpened += MP_MediaOpened;
            MP.MediaEnded += MP_MediaEnded;
            MP.Source=new ();
        }

        private void MP_MediaEnded(object sender, RoutedEventArgs e)
        {
            MP.Stop();
        }

        private void MP_MediaOpened(object sender, RoutedEventArgs e)
        {
            MP.Play();
        }
    }
}
