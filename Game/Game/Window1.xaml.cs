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
using System.Threading;


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
        //bool final = false;

        System.Windows.Threading.DispatcherTimer FinalTimer;
        public Window1()
        {
            InitializeComponent();
           
            //timerStart();
            MP.MediaOpened += MP_MediaOpened;
            MP.MediaEnded += MP_MediaEnded;
            if (game.final == false)
            {
                MP.Source = new Uri("video/begin.wmv", UriKind.RelativeOrAbsolute);
                //MP.Source = new Uri(@"pack://application:,,,/video/begin.wmv", UriKind.RelativeOrAbsolute);
                //string filename = Game.Properties.Resources.Начало.ToString();
                //MP.Source = new Uri(filename, UriKind.RelativeOrAbsolute);
                MP.Volume = 1;
            }
            //MP.Source = new Uri(@"pack://application:,,,/video/predhistor.wmv", UriKind.Absolute);
            MP.Play();
            MP.SpeedRatio = 20;

            FinalTimer = new System.Windows.Threading.DispatcherTimer();
            FinalTimer.Tick += new EventHandler(FinalTimer_Tick);
            FinalTimer.Interval = new TimeSpan(0, 0, 0, 0, 400);
        }

        private void FinalTimer_Tick(object sender, EventArgs e)
        {
            if (game.final==true)
            {
                this.Show();
                FinalTimer.Stop();
                //MP.Source = new Uri(@"pack://application:,,,/video/final.wmv");
                MP.Source = new Uri(@"video/begin.wmv", UriKind.RelativeOrAbsolute);
                //string filename = Game.Properties.Resources.Начало.ToString();
                //MP.Source = new Uri(filename, UriKind.RelativeOrAbsolute);
                MP.Volume = 1;
                MP.Play();
                MP.SpeedRatio = 20;
            }
        }

        private void MP_MediaOpened(object sender,RoutedEventArgs e)
        {
            MP.Play();
        }

        private void MP_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (game.final == true)
                game.Close();
            if (game.final == false)
            {
                MP.Stop();
                this.Hide();
                FinalTimer.Start();
                Thread.Sleep(1000);

                if (MessageBox.Show("Я спал, когда снаружи послышались какие-то крики(а может петух). \n" +
    " Так как рядом с моим домом только располагалась деревенская tavern, взяв первое, что попалось под руку," +
    " я решил направиться туда", "\n", MessageBoxButton.OK) == MessageBoxResult.OK)
                    game.ShowDialog();
            }
        }

    }
}
    

