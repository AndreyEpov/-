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

        int x = 0, y = 0;

        public MainWindow()
        {
            InitializeComponent();

            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Рисунок1.jpg", UriKind.Absolute));
            screen.Background = ib;

            myRect.Stroke = Brushes.Black;
            myRect.Fill = Brushes.SkyBlue;            myRect.HorizontalAlignment = HorizontalAlignment.Left;
            myRect.VerticalAlignment = VerticalAlignment.Center;            myRect.Height = 50;
            myRect.Width = 50;
            screen.Children.Add(myRect);

            screen.KeyDown += Window_KeyDown;

            //Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
            //Point pos = screen.Se;
            //if ()
            //{

            //}
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
                y -=10;
            }

            if (e.Key == Key.Down)
            {
                y +=10;
            }

            TranslateTransform tt = new TranslateTransform(x, y);
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(tt);
            myRect.RenderTransform = tg;
        }
    }
}
