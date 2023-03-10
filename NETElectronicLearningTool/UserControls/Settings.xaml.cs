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

namespace NETElectronicLearningTool.UserControls
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        Dictionary<string, SolidColorBrush> listColor = new Dictionary<string, SolidColorBrush>();
        public Settings()
        {
            InitializeComponent();

            InitializeDataComponent();
        }

        private void InitializeDataComponent()
        {
            List<string> listSize = new List<string>();
            listSize.Add("8");
            listSize.Add("12");
            listSize.Add("14");
            listSize.Add("16");

            SizeFont.ItemsSource = listSize;

            listColor.Add("AliceBlue", Brushes.AliceBlue);
            listColor.Add("Black",Brushes.Black);
            listColor.Add("Blue",Brushes.Blue);
            listColor.Add("Brown",Brushes.Brown);
            listColor.Add("White",Brushes.White);

            ColorFont.ItemsSource = listColor.Keys;
            ColorBackground.ItemsSource = listColor.Keys;

            SizeFont.SelectedItem = Properties.Settings.Default.SizeFont;
            ColorFont.SelectedItem = Properties.Settings.Default.ColorFont;
            ColorBackground.SelectedItem = Properties.Settings.Default.BackgroundTextBox;
        }

        private void SizeFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.SizeFont = (string)SizeFont.SelectedItem;
        }

        private void ColorFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.ColorFont = (string)ColorFont.SelectedItem;
        }

        private void ColorBackground_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.BackgroundTextBox = (string)ColorBackground.SelectedItem;
        }
    }
}
