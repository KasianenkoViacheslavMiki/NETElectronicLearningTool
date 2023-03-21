using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using NETElectronicLearningTool.Command.CommandChart;

namespace NETElectronicLearningTool.ViewModels
{
    public class ChartViewModel : ViewModelBase
    {
        public PlotModel Model { get; private set; }
        public ChangeCommand ChangeNumber { get; private set; }

        private int y = 1;
        public int YParams
        {
            get => y;
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged("YParams"); // reports this property
                }
            }
        }

        private void UpdateChart(object obj, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "YParams")
            {
                Model.Series[0] = new FunctionSeries((x) => Math.Sin(x / y), 0, 10, 0.1) { MarkerType = MarkerType.Circle };
                Model.InvalidatePlot(true);
            }
        }

        public ChartViewModel()
        {
            PropertyChanged += UpdateChart;

            ChangeNumber = new ChangeCommand((key) => y = (int)key);
            var tmp = new PlotModel { Title = "y = sin(x/k)" };

            var series1 = new FunctionSeries((x) => Math.Sin(x / y), 0, 10, 0.1) { MarkerType = MarkerType.Circle };
            tmp.Series.Add(series1);

            Model = tmp;
        }
       
    }
}
