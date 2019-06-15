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

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer;

        Rectangle myRect = new Rectangle();

        int x = 0, y = 0, pic = 0;

        int currentFrame = 1, currentRow = 0, cr = 64;
        int frameW = 96, frameH = 96;
        bool boolat = false;
        int time = DateTime.Now.Second;

        ImageBrush ib = new ImageBrush();

        public MainWindow()
        {
            InitializeComponent();  

            InitializeComponent();
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            
            screen.KeyDown += Window_KeyDown;            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
                var frameLeft = currentFrame * frameW;
                var frameTop = currentRow * frameH;
                (myRect.Fill as ImageBrush).Viewbox = new Rect(frameLeft, frameTop, frameLeft + frameW, frameTop + frameH);
                if (currentFrame % cr == 0)
                {
                    currentRow++;
                    currentFrame = 0;
                }
                currentFrame++;
        }

        public void zdraste()
        {

        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {          
            
            if (e.Key==Key.Right)
            {
                Timer.Start();
                myRect.Height = 96;
                myRect.Width = 96;
                ImageBrush ib = new ImageBrush();
                ib.AlignmentX = AlignmentX.Left;
                ib.AlignmentY = AlignmentY.Top;
                ib.Stretch = Stretch.None;
                ib.Viewbox = new Rect(0, 0, 96, 96);
                ib.ViewboxUnits = BrushMappingMode.Absolute;
                ib.ImageSource = new BitmapImage(new Uri("C:\\Users\\Bulat\\Desktop\\zombie test forward.gif", UriKind.Absolute));
                myRect.Fill = ib;
                myRect.Margin = new Thickness(0, 0, 0, 0);
                x += 5;
                //boolat = bulat
                if (boolat == false)
                {
                    screen.Children.Add(myRect);
                    boolat = true;
                }
            }

            if (e.Key == Key.Left)
            {
                myRect.Height = 96;
                myRect.Width = 96;

                ImageBrush ib = new ImageBrush();
                ib.AlignmentX = AlignmentX.Left;
                ib.AlignmentY = AlignmentY.Top;
                ib.Stretch = Stretch.None;
                ib.Viewbox = new Rect(0, 0, 100, 100);
                ib.ViewboxUnits = BrushMappingMode.Absolute;
                ib.ImageSource = new BitmapImage(new Uri("C:\\Users\\Bulat\\Desktop\\zombie test.gif", UriKind.Absolute));
                myRect.Fill = ib;
                myRect.Margin = new Thickness(0, 0, 0, 0);
                screen.Children.Add(myRect);
                x -=10;
                Timer.Start();
            }

            if (e.Key == Key.Up)
            {
                y -=10;            }

            if (e.Key == Key.Down)
            {
                y +=10;
            }

            TranslateTransform tt = new TranslateTransform(x, y);
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(tt);
            myRect.RenderTransform = tg;

            Point point1 = new Point(790, 175);

            Point point2 = new Point(10, 175);

            Point point3 = new Point(395, 10);

            Point point4 = new Point(395, 350);

            Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

            if ((rect.Contains(point1) == true) && (pic==0)) // из первой во вторую
            {
                x = 25;
                y = 175;
                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/greensward.jpg", UriKind.Absolute));
                screen.Background = ib;
                pic = 1;
            }

            if ((rect.Contains(point2) == true) && (pic == 1)) // из второй в первую
            {
                x = 770;
                y = 175;
                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Рисунок1.jpg", UriKind.Absolute));
                screen.Background = ib;
                pic = 0;
            }

            if ((rect.Contains(point3)==true) && (pic==1)) // из второй в третью
            {
                x = 395;
                y = 340;
                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/250px-Darkwing.JPG", UriKind.Absolute));
                screen.Background = ib;
                pic = 2;
            }

            if ((rect.Contains(point4) == true) && (pic == 2)) // из третьей во вторую
            {
                x = 395;
                y = 20;
                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/greensward.jpg", UriKind.Absolute));
                screen.Background = ib;
                pic = 1;
            }
        }
    }
}
