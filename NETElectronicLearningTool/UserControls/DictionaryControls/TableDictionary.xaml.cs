using NETElectronicLearningTool.EF.Model;
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

namespace NETElectronicLearningTool.UserControls.DictionaryControls
{
    /// <summary>
    /// Interaction logic for TableDictionary.xaml
    /// </summary>
    public partial class TableDictionary : UserControl
    {
        public TableDictionary(IEnumerable<MethodDiscription> _methodDiscriptions)
        {
            InitializeComponent();
            TableMethod.ItemsSource = _methodDiscriptions.Select(x=> new {
                x.NameClass,
                x.NameFunction,
                x.DiscriptionFunction,
            });
        }
    }
}
