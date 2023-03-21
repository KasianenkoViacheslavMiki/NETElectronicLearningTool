using NETElectronicLearningTool.Command.CommandSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NETElectronicLearningTool.ViewModels
{
    public class SettingViewModel:ViewModelBase
    {
        public ICommand ChangeBackground { get; set; }
        public ICommand ChangeColorFont { get; set; }
        public ICommand ChangeSizeFont { get; set; }

       

        public SettingViewModel()
        {
            InitializeDataComponent();

            FontSize = Int32.Parse(Properties.Settings.Default.DefaultSize);
            ColorFont = Properties.Settings.Default.DefaultColorFont;
            ColorBackground = Properties.Settings.Default.DefaultBackgroundTextBox;
        }

        private List<string> listSize = new List<string>();

        public List<string> ListSize
        {
            get 
            { 
                return listSize; 
            }
            set 
            { 
                listSize = value;
                OnPropertyChanged(nameof(ListSize));
            }
        }

        private Dictionary<string, SolidColorBrush> listColor = new Dictionary<string, SolidColorBrush>();

        public Dictionary<string, SolidColorBrush> ListColor
        {
            get 
            { 
                return listColor; 
            }
            set 
            { 
                listColor = value;
                OnPropertyChanged(nameof(ListColor));
            }
        }

        private int fontSize;

        public int FontSize
        {
            get 
            { 
                return fontSize; 
            }
            set 
            { 
                fontSize = value;
                Properties.Settings.Default.SizeFont = value.ToString();
                OnPropertyChanged(nameof(FontSize));
            }
        }
        private string colorFont;

        public string ColorFont
        {
            get 
            { 
                return colorFont; 
            }
            set
            { 
                colorFont = value;
                Properties.Settings.Default.ColorFont = value.ToString();
                OnPropertyChanged(nameof(ColorFont));
            }
        }

        private string colorBackground;

        public string ColorBackground
        {
            get 
            { 
                return colorBackground; 
            }
            set 
            { 
                colorBackground = value;
                Properties.Settings.Default.BackgroundTextBox = value.ToString();
                OnPropertyChanged(nameof(ColorBackground));
            }
        }


        private void InitializeDataComponent()
        {
            ListSize.Add("8");
            ListSize.Add("12");
            ListSize.Add("14");
            ListSize.Add("16");

            ListColor.Add("AliceBlue", Brushes.AliceBlue);
            ListColor.Add("Black", Brushes.Black);
            ListColor.Add("Blue", Brushes.Blue);
            ListColor.Add("Brown", Brushes.Brown);
            ListColor.Add("White", Brushes.White);
        }
    }
}
