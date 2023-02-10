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

namespace NETElectronicLearningTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Material_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Міняє вікно на викладання матеріалу
        }

        private void Test_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Міняє вікно на тестування
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Training_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Міняє вікно на тренування
        }

        private void Setting_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Міняє вікно на настройки
        }
    }
}
