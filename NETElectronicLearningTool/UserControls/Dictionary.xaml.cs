﻿using NETElectronicLearningTool.UserControls.DictionaryControls;
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

        public Dictionary()
        {
            InitializeComponent();
            subWindow = new UserControl();
        }

        private void DictionaryTable_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(subWindow is TableDictionary))
            {
                GridDictionary.Children.Remove(subWindow);
                subWindow = new TableDictionary();
                subWindow.SetValue(Grid.RowProperty, 1);
                GridDictionary.Children.Add(subWindow);
            }
        }

        private void Dictionary_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(subWindow is LookingDictionary))
            {
                GridDictionary.Children.Remove(subWindow);
                subWindow = new LookingDictionary();
                subWindow.SetValue(Grid.RowProperty, 1);
                GridDictionary.Children.Add(subWindow);
            }
        }
    }
}