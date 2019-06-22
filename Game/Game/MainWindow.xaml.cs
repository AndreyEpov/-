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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer;
        System.Windows.Threading.DispatcherTimer JumpTimer;
        System.Windows.Threading.DispatcherTimer FallTimer;
        System.Windows.Threading.DispatcherTimer MoveTimer;
        System.Windows.Threading.DispatcherTimer ConfirmTimer;

        Rectangle myRect = new Rectangle();
        Rectangle HP = new Rectangle();
        Rectangle FRAME = new Rectangle();
        Rectangle Enemy = new Rectangle();

        Point f0t1 = new Point(792, 312);
        Point f1t0 = new Point(0, 312);
        Point f1t2 = new Point(750, 312);
        Point f1t3 = new Point(264,312);
        Point f1t4 = new Point(528,312);
        Point f2t1 = new Point(0,312);
        Point f2t5 = new Point(600,312);
        Point f3t1 = new Point(0,312);
        Point f3t5 = new Point(696,312);
        Point f4t1 = new Point(696,312);
        Point f4t5 = new Point(400,312);
        Point f5t2 = new Point(0,312);
        Point f5t3 = new Point(150,312);
        Point f5t4 = new Point(300,312);
        Point f5t67 = new Point(650,312);
        Point f5t9 = new Point(792,312);
        Point f6t8 = new Point(0, 312);
        Point f6t5 = new Point(696, 312);
        Point f8t6 = new Point(792, 312);
        Point f7t5 = new Point(792, 312);
        Point f9t11 = new Point(696, 312);
        Point f11t12 = new Point(396, 312);
        Point f12t14 = new Point(600, 312);
        Point f14t15 = new Point(400, 312);

        int x = 0, y = 312, pic = 0;
        int up = 0, down = 0;


        int hph = 16, hpw = 96;

        //int currentFrame = 1, currentRow = 0, cr = 4;
        //int frameW = 96, frameH = 96;
        //bool boolat = false;
        //int time = DateTime.Now.Second;


        ImageBrush background = new ImageBrush();

        public MainWindow()
        {
            InitializeComponent();

            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 1);
            Timer.Start();

            JumpTimer = new System.Windows.Threading.DispatcherTimer();
            JumpTimer.Tick += new EventHandler(JumpTimer_Tick);
            JumpTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);

            FallTimer = new System.Windows.Threading.DispatcherTimer();
            FallTimer.Tick += new EventHandler(FallTimer_Tick);
            FallTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);

            MoveTimer = new System.Windows.Threading.DispatcherTimer();
            MoveTimer.Tick += new EventHandler(MoveTimer_Tick);
            MoveTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            MoveTimer.Start();

            ConfirmTimer = new System.Windows.Threading.DispatcherTimer();
            ConfirmTimer.Tick += new EventHandler(ConfirmTimer_Tick);
            ConfirmTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            ConfirmTimer.Start();

            screen.KeyDown += Window_KeyDown;

            FRAME.Height = 16;
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
            screen.Children.Add(HP);

            myRect.Height = 96;
            myRect.Width = 96;
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            //ib.AlignmentY = AlignmentY.Top;
            ib.Stretch = Stretch.None;
            ib.Viewbox = new Rect(0, 0, 96, 96);
            ib.ViewboxUnits = BrushMappingMode.Absolute;
            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/gg.gif", UriKind.Absolute));
            myRect.Fill = ib;
            myRect.Margin = new Thickness(0, 0, 0, 0);
            screen.Children.Add(myRect);

            background.AlignmentX = AlignmentX.Left;
            ib.Stretch = Stretch.None;
            ib.Viewbox = new Rect(0, 0, 96, 96);
            ib.ViewboxUnits = BrushMappingMode.Absolute;
            background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/внутри дома.bmp", UriKind.Absolute));

            screen.Background = background;
        }

        private void JumpTimer_Tick(object sender, EventArgs e)
        {
            y -= 8;
            up += 1;
            if (up == 10)
            {
                JumpTimer.Stop();
                up = 0;
                FallTimer.Start();

            }
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            TranslateTransform tt = new TranslateTransform(x, y);
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(tt);
            myRect.RenderTransform = tg;
        }

        private void ConfirmTimer_Tick(object sender, EventArgs e)
        {
            Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

            if (pic == 0) // из дома в деревню
            {
                if (rect.Contains(f0t1) == true)
                    confirm.Content = "[e]Выйти из дома";
                else confirm.Content = "";
            }    
            
            if (pic == 1) // из деревни
            {
                if (rect.Contains(f1t0) == true)
                    confirm.Content = "[e]Войти в дом";
                if (rect.Contains(f1t2) == true)
                    confirm.Content = "[e]На поляну";
                if (rect.Contains(f1t3) == true)
                    confirm.Content = "[e]В лес";
                if (rect.Contains(f1t4) == true)
                    confirm.Content = "[e]На болото";
                if ((rect.Contains(f1t0) == false) && rect.Contains(f0t1) == false && rect.Contains(f1t3) == false && rect.Contains(f1t4) == false)
                    confirm.Content = "";
            }            
            
            if (pic == 2) // из поляны
            {
                if (rect.Contains(f2t1) == true)
                    confirm.Content = "[e]В деревню";
                if (rect.Contains(f2t5) == true)
                    confirm.Content = "[e]В замок";
                if (rect.Contains(f2t5) == false && rect.Contains(f2t1) == false)
                    confirm.Content = "";
            }

            if (pic == 3) // из леса
            {
                if (rect.Contains(f3t1) == true)
                    confirm.Content = "[e]В деревню";
                if (rect.Contains(f3t5) == true)
                    confirm.Content = "[e]В замок";
                if (rect.Contains(f3t1) == false && rect.Contains(f3t5) == false)
                    confirm.Content = "";
            }

            if (pic == 4) // из болота
            {
                if (rect.Contains(f4t1) == true)
                    confirm.Content = "[e]В деревню";
                if (rect.Contains(f4t5) == true)
                    confirm.Content = "[e]В замок";
                if (rect.Contains(f4t1) == false && rect.Contains(f4t5) == false)
                    confirm.Content = "";
            }

            if (pic == 5) // из замка
            {
                if (rect.Contains(f5t2) == true)
                    confirm.Content = "[e]На поляну";
                if (rect.Contains(f5t3) == true)
                    confirm.Content = "[e]В лес";
                if (rect.Contains(f5t4) == true)
                    confirm.Content = "[e]На болото";
                if (rect.Contains(f5t67) == true)
                    confirm.Content = "[e]В пещеру\n[t]К руинам";
                if (rect.Contains(f5t9) == true)
                    confirm.Content = "[e]На рыцарский турнир";
                if (rect.Contains(f5t2) == false && rect.Contains(f5t3) == false && rect.Contains(f5t4) == false && rect.Contains(f5t67) == false && rect.Contains(f5t9) == false)
                    confirm.Content = "";
            }

            if (pic == 6)
            {
                if (rect.Contains(f6t5) == true)
                    confirm.Content = "[e]В замок";
                if (rect.Contains(f6t8) == true)
                    confirm.Content = "[e]В сердце пещеры";
                if (rect.Contains(f6t8) == false && rect.Contains(f6t5) == false)
                    confirm.Content = "";
            }

            if (pic == 7)
            {
                if (rect.Contains(f7t5) == true)
                    confirm.Content = "[e]В замок";
                else confirm.Content = "";
            }

            if (pic == 8)
            {
                if (rect.Contains(f8t6) == true)
                    confirm.Content = "[e]В пещеру";
                else confirm.Content = "";

            }

            if (pic == 9)
            {
                if (rect.Contains(f9t11) == true)
                    confirm.Content = "[e]К маяку";
                else confirm.Content = "";
            }

            if (pic == 11)
            {
                if (rect.Contains(f11t12) == true)
                    confirm.Content = "[e]На корабль";
                else confirm.Content = "";
            }

            if (pic == 12)
            {
                if (rect.Contains(f12t14) == true)
                    confirm.Content = "[e]К башне";
                else confirm.Content = "";
            }

            if (pic == 14)
            {
                if (rect.Contains(f14t15) == true)
                    confirm.Content = "[e]Финальный бой";
                else confirm.Content = "";
            }
        }

        private void FallTimer_Tick(object sender, EventArgs e)
        {
            y += 8;
            down += 1;
            if (down == 10)
            {
                FallTimer.Stop();
                down = 0;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
        //    Point e1 = new Point(398, 200);
        //    Point e2 = new Point(494, 200);
        //    Point e3 = new Point(398, 296);
        //    Point e4 = new Point(494, 296);

        //    Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
        //    if ((rect.Contains(e1) == true) || (rect.Contains(e2) == true) || (rect.Contains(e3) == true) || (rect.Contains(e4) == true)) // из первой во вторую
        //    {
        //        hpw -= 8;

        //        if (hpw == 0)
        //            if (MessageBox.Show("LOL You Died :D. Want to restart?", "/n", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //            {
        //                x = 0;
        //                y = 0;
        //                hpw = 96;
        //            }
        //            else
        //            {
        //                Application.Current.Shutdown();
        //            }
        //        HP.Width = hpw;
        //    }

            if (hpw < 96)
                hpw += 2;
            HP.Width = hpw;

        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.F9)
            {
                hpw += 1000000000;
                HP.Width = hpw;
            }

            if ((e.Key != Key.Right) && (e.Key != Key.Left))
            {
                //Timer.Start();
                //myRect.Height = 96;
                //myRect.Width = 96;
                //ImageBrush ib = new ImageBrush();
                //ib.AlignmentX = AlignmentX.Left;
                //ib.Viewbox = new Rect(0, 0, 96, 96);
                //ib.ViewboxUnits = BrushMappingMode.Absolute;
                //Rect Rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
                //ib.Stretch = Stretch.None;
                //ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/zomb.gif", UriKind.Absolute));
                //myRect.Fill = ib;
                //myRect.Margin = new Thickness(0, 0, 0, 0);
            }

            if (e.Key == Key.Right)
            {
                //myRect.Height = 96;
                //myRect.Width = 96;
                //ImageBrush ib = new ImageBrush();
                //ib.AlignmentX = AlignmentX.Left;
                //ib.Viewbox = new Rect(0, 0, 96, 96);
                //ib.ViewboxUnits = BrushMappingMode.Absolute;
                //Rect Rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
                //ib.Stretch = Stretch.None;
                //ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/zombie test forward.gif", UriKind.Absolute));
                //myRect.Fill = ib;
                //myRect.Margin = new Thickness(0, 0, 0, 0);
                //boolat = true;
                if (x < 696)
                    x += 8;
            }

            if (e.Key == Key.Left)
            {
                //myRect.Height = 96;
                //myRect.Width = 96;
                //ImageBrush ib = new ImageBrush();
                //ib.AlignmentX = AlignmentX.Left;
                //ib.Viewbox = new Rect(0, 0, 96, 96);
                //ib.ViewboxUnits = BrushMappingMode.Absolute;
                //Rect Rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
                //ib.Stretch = Stretch.None;
                //ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/zombie test.gif", UriKind.Absolute));
                //myRect.Fill = ib;
                //myRect.Margin = new Thickness(0, 0, 0, 0);
                //boolat = true;
                if (x > 0)
                    x -= 8;

            }

            if (e.Key == Key.Up)
            {
                JumpTimer.Start();

            }

            if (e.Key == Key.Down)
            {
                //y += 8;
            }

            Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);


            if (rect.Contains(f5t67) == true && pic == 5) // из замка в пещеру/руины
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 248;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/подземелье.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 6;
                }
                if (e.Key == Key.T)
                {
                    x = 696;
                    y = 308;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/руины.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 7;
                }
            }

            if ((rect.Contains(f2t5) == true) && (pic == 2)) // из поляны в замок
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 312;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/город3.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 5;
                }
            }

            if ((rect.Contains(f1t2) == true) && (pic == 1)) // из деревни на поляну
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 245;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/поляна.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 2;
                }
            }

            if (rect.Contains(f5t9) == true && pic == 5) // из замка на рыцарский турнир
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 250;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/арена2.png.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 9;
                }
            }

            if ((rect.Contains(f0t1) == true) && (pic == 0)) // из дома в деревню
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 305;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/деревня.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 1;
                }
            }

            if ((rect.Contains(f1t0) == true) && (pic == 1)) // из деревни в дом
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 312;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/внутри дома.bmp", UriKind.Absolute));
                    screen.Background = background;
                    pic = 0;                    
                }
            }
            
            if ((rect.Contains(f1t3) == true) && (pic == 1)) // из деревни в лес
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 296;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/лес.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 3;
                }
            }

            if ((rect.Contains(f1t4) == true) && (pic == 1)) // из деревни на болото
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 290;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/болото.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 4;
                }
            }

            if ((rect.Contains(f2t1) == true) && (pic == 2)) // из поляны в деревню
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 305;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/деревня.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 1;
                }
            }

            if (rect.Contains(f3t1)==true && pic==3) // из леса в деревню
            {
                if (e.Key == Key.E)
                {
                    x = 264;
                    y = 305;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/деревня.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 1;
                }
            }

            if (rect.Contains(f3t5) == true && pic == 3) // из леса в замок
            {
                if (e.Key == Key.E)
                {
                    x = 150;
                    y = 312;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/город3.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 5;
                }
            }

            if (rect.Contains(f4t1) == true && pic == 4) // из болота в деревню
            {
                if (e.Key == Key.E)
                {
                    x = 528;
                    y = 305;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/деревня.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 1;
                }
            }

            if (rect.Contains(f5t4) == true && pic == 5) // из замка на болото
            {
                if (e.Key == Key.E)
                {
                    x = 400;
                    y = 290;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/болото.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 4;
                }
            }

            if (rect.Contains(f4t5) == true && pic == 4) // из болота в замок
            {
                if (e.Key == Key.E)
                {
                    x = 300;
                    y = 312;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/город3.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 5;
                }
            }

            if (rect.Contains(f5t2) == true && pic == 5) // из замка на поляну
            {
                if (e.Key == Key.E)
                {
                    x = 600;
                    y = 245;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/поляна.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 2;
                }
            }

            if (rect.Contains(f5t3) == true && pic == 5) // из замка в лес
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 296;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/лес.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 3;
                }
            }

            if (rect.Contains(f6t5) == true && pic == 6) // из пещеры в замок
            {
                if (e.Key == Key.E)
                {
                    x = 650;
                    y = 312;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/город3.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 5;
                }
            }

            if (rect.Contains(f6t8) == true && pic == 6) // из пещеры в сердце пещеры
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 290;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/сердце пещеры2.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 8;
                }
            }

            if (rect.Contains(f7t5) == true && pic == 7) // из руин к замку
            {
                if (e.Key == Key.E)
                {
                    x = 650;
                    y = 312;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/город3.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 5;
                }
            }

            if (rect.Contains(f8t6) == true && pic == 8) // из сердца пещеры к подземелью
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 248;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/подземелье.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 6;
                }
            }

            if (rect.Contains(f9t11) == true && pic == 9) // к маяку
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 312;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/маяк.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 11;
                }
            }

            if (rect.Contains(f11t12) == true && pic == 11) // на корабль
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 300;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/вид с корабля.gif", UriKind.Absolute));
                    screen.Background = background;
                    pic = 12;
                }
            }

            if (rect.Contains(f12t14) == true && pic == 12) // к башне
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 312;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/мб башня босса.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 14;
                }
            }

            if (rect.Contains(f14t15) == true && pic == 14) // к боссу
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 300;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/сердце пещеры.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 15;
                }
            }
        }
    }
}