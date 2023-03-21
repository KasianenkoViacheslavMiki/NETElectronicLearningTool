using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.ViewModels.DictionarySubViewModal
{
    public class LookingDictionaryViewModel : ViewModelBase
    {
        public LookingDictionaryViewModel()
        {

        }
        //ControllerDictionary controllerDictionary;
        //public LookingDictionary(IEnumerable<MethodDiscription> methodDiscriptions)
        //{
        //    InitializeComponent();
        //    controllerDictionary = new ControllerDictionary(methodDiscriptions);
        //    InitializeData(controllerDictionary.ListMethod);
        //}

        //private async void InitializeData(IEnumerable<MethodDiscription> list)
        //{
        //    TreeMethod.Items.Clear();
        //    foreach (var article in list)
        //    {
        //        TreeViewItem newChild = new TreeViewItem();
        //        newChild.Header = article.NameFunction;
        //        newChild.Tag = article.Id;
        //        TreeMethod.Items.Add(newChild);
        //    }
        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    InitializeData(controllerDictionary.Filter(Find.Text));
        //}

        //private void TreeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if ((TreeViewItem)TreeMethod.SelectedItem == null) return;
        //    var methodDiscriptions = (TreeViewItem)TreeMethod.SelectedItem;
        //    controllerDictionary.ChangeFunction((Guid)methodDiscriptions.Tag);
        //    if (methodDiscriptions != null)
        //    {
        //        NameMethod.Text = controllerDictionary.NameFunction;
        //        DescriptionMethod.Text = controllerDictionary.Discription;
        //    }
        //}
    }
}
