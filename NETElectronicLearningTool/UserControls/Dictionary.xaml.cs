using NETElectronicLearningTool.EF;
using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.Interface;
using NETElectronicLearningTool.UserControls.DictionaryControls;
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
    /// Interaction logic for Dictionary.xaml
    /// </summary>
    public partial class Dictionary : UserControl
    {
        UserControl subWindow;

        IGetDictionary getDictionary;

        IEnumerable<MethodDiscription> methodDiscriptions;

        public Dictionary()
        {
            InitializeComponent();

            getDictionary = new RepositoryDictionary(new LearningToolContext());

            subWindow = new UserControl();
            
            InitializeData();
        }

        private async void InitializeData()
        {
            methodDiscriptions = await getDictionary.GetDictionaryOfFunctions();
        }

        private void DictionaryTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(subWindow is TableDictionary))
            {
                GridDictionary.Children.Remove(subWindow);
                subWindow = new TableDictionary(methodDiscriptions);
                subWindow.SetValue(Grid.RowProperty, 1);
                GridDictionary.Children.Add(subWindow);
            }
        }

        private void Dictionary_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(subWindow is LookingDictionary))
            {
                GridDictionary.Children.Remove(subWindow);
                subWindow = new LookingDictionary(methodDiscriptions);
                subWindow.SetValue(Grid.RowProperty, 1);
                GridDictionary.Children.Add(subWindow);
            }
        }
    }
}
