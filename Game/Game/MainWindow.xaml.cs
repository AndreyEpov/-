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
        Rectangle HP = new Rectangle();
        Rectangle FRAME = new Rectangle();
        Rectangle Enemy = new Rectangle();

        int x = 0, y = 0, pic = 0;

        int hph = 32, hpw = 96;

        int currentFrame = 1, currentRow = 0, cr = 4;
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

            FRAME.Height = 32;
            FRAME.Width = 96;
            FRAME.Stroke = Brushes.Black;
            FRAME.HorizontalAlignment = HorizontalAlignment.Left;
            FRAME.VerticalAlignment = VerticalAlignment.Center;
            FRAME.Margin = new Thickness(696, 0, 0, 0);
            screen.Children.Add(FRAME);

            HP.Height = hph;
            HP.Width = hpw;
            HP.Stroke = Brushes.Black;
            HP.Fill = Brushes.Green;
            HP.HorizontalAlignment = HorizontalAlignment.Left;
            HP.VerticalAlignment = VerticalAlignment.Center;
            HP.Margin = new Thickness(696, 0, 0, 0);
            screen.Children.Add(HP);            Enemy.Height = 96;
            Enemy.Width = 96;
            Enemy.Stroke = Brushes.Black;
            Enemy.Fill = Brushes.Red;
            Enemy.HorizontalAlignment = HorizontalAlignment.Left;
            Enemy.VerticalAlignment = VerticalAlignment.Center;
            Enemy.Margin = new Thickness(398, 200, 0, 0);
            screen.Children.Add(Enemy);
            
            myRect.Height = 96;
            myRect.Width = 96;
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            //ib.AlignmentY = AlignmentY.Top;
            ib.Stretch = Stretch.None;
            ib.Viewbox = new Rect(0, 0, 96, 96);
            ib.ViewboxUnits = BrushMappingMode.Absolute;
            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/zomb.gif", UriKind.Absolute));
            myRect.Fill = ib;
            myRect.Margin = new Thickness(0, 0, 0, 0);
            screen.Children.Add(myRect);
        }

        //public void damage()
        //{
        //    TranslateTransform tt = new TranslateTransform(x, y);
        //    TransformGroup tg = new TransformGroup();
        //    tg.Children.Add(tt);
        //    myRect.RenderTransform = tg;

        //    Point e1 = new Point(398, 200);
        //    Point e2 = new Point(494, 200);
        //    Point e3 = new Point(398, 296);
        //    Point e4 = new Point(494, 296);

        //    Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

        //    if ((rect.Contains(e1) == true) || (rect.Contains(e2) == true) || (rect.Contains(e3) == true) || (rect.Contains(e4) == true)) // из первой во вторую
        //    {
        //        hpw -= 8;
        //    }
        //}

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
            if ((e.Key != Key.Right) && (e.Key != Key.Left))
            {
                myRect.Height = 96;
                myRect.Width = 96;
                ImageBrush ib = new ImageBrush();
                ib.AlignmentX = AlignmentX.Left;
                ib.Viewbox = new Rect(0, 0, 96, 96);
                ib.ViewboxUnits = BrushMappingMode.Absolute;
                Rect Rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
                ib.Stretch = Stretch.None;
                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/zomb.gif", UriKind.Absolute));
                myRect.Fill = ib;
                myRect.Margin = new Thickness(0, 0, 0, 0);
            }

                if (e.Key == Key.Right)
            {
                //if (boolat == false)
                //{
                    //Timer.Start();
                    myRect.Height = 96;
                    myRect.Width = 96;
                    ImageBrush ib = new ImageBrush();
                    ib.AlignmentX = AlignmentX.Left;
                    ib.Viewbox = new Rect(0, 0, 96, 96);
                    ib.ViewboxUnits = BrushMappingMode.Absolute;
                    Rect Rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
                    ib.Stretch = Stretch.None;
                    ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/zombie test forward.gif", UriKind.Absolute));
                    myRect.Fill = ib;
                    myRect.Margin = new Thickness(0, 0, 0, 0);
                    boolat = true;
                //}
                x += 8;
                //Timer.Start();
                //myRect.Height = 96;
                //myRect.Width = 96;
                //ImageBrush ib = new ImageBrush();
                ////ib.AlignmentY = AlignmentY.Top;

                //ib.ImageSource = new BitmapImage(new Uri("C:\\Users\\Bulat\\Desktop\\zombie test forward.gif", UriKind.Absolute));
                //myRect.Fill = ib;

                ////boolat = bulat
                //if (boolat == false)
                //{
                //    screen.Children.Add(myRect);
                //    boolat = true;
                //}
            }
            //if ((e.Key != Key.Right) && (e.Key != Key.Left))
            //{
            //    screen.Children.Add(notmyRect);
            //    notmyRect.Height = 96;
            //    notmyRect.Width = 96;
            //    ImageBrush id = new ImageBrush();
            //    id.AlignmentX = AlignmentX.Left;
            //    //ib.AlignmentY = AlignmentY.Top;
            //    id.Stretch = Stretch.None;
            //    id.Viewbox = new Rect(0, 0, 96, 96);
            //    id.ViewboxUnits = BrushMappingMode.Absolute;
            //    id.ImageSource = new BitmapImage(new Uri("C:\\Users\\Bulat\\Desktop\\zomb.gif", UriKind.Absolute));
            //    myRect.Fill = id;
            //    myRect.Margin = new Thickness(0, 0, 0, 0);
            //}

            if (e.Key == Key.Left)
            {
                //if (boolat == false)
                //{
                    //Timer.Start();
                    myRect.Height = 96;
                    myRect.Width = 96;
                    ImageBrush ib = new ImageBrush();
                    ib.AlignmentX = AlignmentX.Left;
                    ib.Viewbox = new Rect(0, 0, 96, 96);
                    ib.ViewboxUnits = BrushMappingMode.Absolute;
                    Rect Rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
                    ib.Stretch = Stretch.None;
                    ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/zombie test.gif", UriKind.Absolute));
                    myRect.Fill = ib;
                    myRect.Margin = new Thickness(0, 0, 0, 0);
                    boolat = true;
                //}
                x -=8;
                //Timer.Start();
                ////myRect.Height = 96;
                ////myRect.Width = 96;
                //ImageBrush ib = new ImageBrush();

                //Rect Rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

                //ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/zombie test forward.gif", UriKind.Absolute));
                //myRect.Fill = ib;
                ////ib.AlignmentX = AlignmentX.Left;
                ////ib.AlignmentY = AlignmentY.Top;
                ////ib.Stretch = Stretch.None;
                ////ib.Viewbox = new Rect(0, 0, 96, 96);
                ////ib.ViewboxUnits = BrushMappingMode.Absolute;
                ////ib.ImageSource = new BitmapImage(new Uri("C:\\Users\\Bulat\\Desktop\\zombie test.gif", UriKind.Absolute));
                ////myRect.Fill = ib;
                ////myRect.Margin = new Thickness(0, 0, 0, 0);
                //x -= 10;
                //boolat = bulat
                //if (boolat == false)
                //{
                //    screen.Children.Add(myRect);
                //    boolat = true;
                //}
            }

            if (e.Key == Key.Up)
            {
                y -=8;
            }

            if (e.Key == Key.Down)
            {
                y +=8;
            }

            //TranslateTransform tt1 = new TranslateTransform(x, y);
            //TransformGroup tg1 = new TransformGroup();
            //tg1.Children.Add(tt1);
            //myRect.RenderTransform = tg1;

            Point e1 = new Point(398, 200);
            Point e2 = new Point(494, 200);
            Point e3 = new Point(398, 296);
            Point e4 = new Point(494, 296);

            Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

            

            if ((rect.Contains(e1) == true) || (rect.Contains(e2) == true) || (rect.Contains(e3) == true) || (rect.Contains(e4) == true)) // из первой во вторую
            {
                hpw -= 8;
                
                if (hpw == 0)
                    if (MessageBox.Show("LOL You Died :D. Want to restart?", "/n", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
                    {
                        x = 0;
                        y = 0;
                        hpw = 96;
                    }
                    //else
                    //{
                        
                    //}
                HP.Width = hpw;
            }



            TranslateTransform tt = new TranslateTransform(x, y);
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(tt);
            myRect.RenderTransform = tg;

            Point point1 = new Point(790, 175);

            Point point2 = new Point(10, 175);

            Point point3 = new Point(395, 10);

            Point point4 = new Point(395, 350);


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
        //public void asd()
        //{
        //    HP.Height = hph;
        //    HP.Width = hpw;
        //    HP.Stroke = Brushes.Black;
        //    HP.Fill = Brushes.Green;
        //    HP.HorizontalAlignment = HorizontalAlignment.Left;
        //    HP.VerticalAlignment = VerticalAlignment.Center;
        //    HP.Margin = new Thickness(696, 0, 0, 0);
        //    screen.Children.Add(HP);
        //}
    }
}
