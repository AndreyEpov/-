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

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow game = new MainWindow();
        //Window1 intro = new Window1();
        //MainWindow video = new MainWindow();
        public Window1()
        {
            InitializeComponent();
           
            //timerStart();
            MP.MediaOpened += MP_MediaOpened;
            MP.MediaEnded += MP_MediaEnded;
            MP.Source = new Uri("C:\\Users\\user\\Desktop\\Я сам испугался.wmv");
            //MP.Source = new Uri("@pack://application:,,,/video/Я сам испугался.wmv", UriKind.RelativeOrAbsolute); 
            MP.Volume = 1;

            //MP.Source = new Uri(@"pack://application:,,,/video/predhistor.wmv", UriKind.Absolute);
            MP.Play();
            MP.SpeedRatio = 20;
        }

        private void MP_MediaOpened(object sender,RoutedEventArgs e)
        {
            MP.Play();
        }

        private void MP_MediaEnded(object sender, RoutedEventArgs e)
        {
            MP.Stop();
            this.Hide();
            game.ShowDialog();
        }

    }
}
    

