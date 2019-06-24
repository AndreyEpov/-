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
    /// Логика взаимодействия для fight.xaml
    /// </summary>



    public partial class fight : Window
    {
        Gaming wrestle = new Gaming();

        Rectangle enemy1 = new Rectangle();
        Rectangle myRect = new Rectangle();


        public fight()
        {
            InitializeComponent();
            myRect.Height = 96;
            myRect.Width = 96;
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            //ib.AlignmentY = AlignmentY.Top;
            ib.Stretch = Stretch.None;
            ib.Viewbox = new Rect(0, 0, 96, 96);
            ib.ViewboxUnits = BrushMappingMode.Absolute;
            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/00.gif", UriKind.Absolute));
            myRect.Fill = ib;
            myRect.Margin = new Thickness(0, 0, 0, 0);
            me.Children.Add(myRect);

            enemy1.Height = 96;
            enemy1.Width = 96;
            ImageBrush rival = new ImageBrush();
            rival.AlignmentX = AlignmentX.Left;
            //ib.AlignmentY = AlignmentY.Top;
            rival.Stretch = Stretch.None;
            rival.Viewbox = new Rect(0, 0, 96, 96);
            rival.ViewboxUnits = BrushMappingMode.Absolute;
            rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/slime1.gif", UriKind.Absolute));
            enemy1.Fill = rival;
            enemy1.Margin = new Thickness(0, 0, 0, 0);
            enemy.Children.Add(enemy1);

        }

        private void Punch_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Punch_Click_1(object sender, RoutedEventArgs e)
        {
            wrestle.hit(0, 3);
            log.Items.Add("У противника осталось " + wrestle.hpenemy + ", У вас осталось" + wrestle.hp);
            if (wrestle.hpenemy <= 0)
            {
                log.Items.Add("Вы победили");
                this.Visibility = Visibility.Hidden;
            }
            if (wrestle.hp <= 0)
            {
                MessageBox.Show("СМЭРТЬ");
                wrestle.canfight = false;
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
