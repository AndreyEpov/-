﻿using System;
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

        Rectangle myRect = new Rectangle();

        int x = 0, y = 0, pic = 0;

        ImageBrush ib = new ImageBrush();

        public MainWindow()
        {
            InitializeComponent();

            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Рисунок1.jpg", UriKind.Absolute));
            screen.Background = ib;

            myRect.Stroke = Brushes.Black;
            myRect.Fill = Brushes.SkyBlue;            myRect.HorizontalAlignment = HorizontalAlignment.Left;
            myRect.VerticalAlignment = VerticalAlignment.Center;            myRect.Height = 50;
            myRect.Width = 50;
            screen.Children.Add(myRect);

            screen.KeyDown += Window_KeyDown;

            
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
                x +=10;
            }

            if (e.Key == Key.Left)
            {
                x -=10;
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

            if ((rect.Contains(point1) == true) && (pic==0))
            {
                x = 25;
                y = 175;
                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/greensward.jpg", UriKind.Absolute));
                screen.Background = ib;
                pic = 1;
            }

            if ((rect.Contains(point2) == true) && (pic == 1))
            {
                x = 770;
                y = 175;
                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Рисунок1.jpg", UriKind.Absolute));
                screen.Background = ib;
                pic = 0;
            }

            if ((rect.Contains(point3)==true) && (pic==1))
            {
                x = 395;
                y = 340;
                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/250px-Darkwing.JPG", UriKind.Absolute));
                screen.Background = ib;
                pic = 2;
            }

            if ((rect.Contains(point4) == true) && (pic == 2))
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
