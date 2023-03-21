using NETElectronicLearningTool.Command.CommandDictionaryWindow.SubCommandDictionary;
using NETElectronicLearningTool.EF;
using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.ViewModels.DictionarySubViewModal
{
    public class LookingDictionaryViewModel : ViewModelBase
    {
        IGetDictionary getDictionary = new RepositoryDictionary(new LearningToolContext());

        public ICommand Filter { get; set; }
        public ICommand Selected { get; set; } 

        private List<ItemTree> itemsTree = new List<ItemTree>();
        public List<ItemTree> ItemsTree
        {
            get
            {
                return itemsTree;
            }
            set
            {
                itemsTree = value;
                OnPropertyChanged(nameof(ItemsTree));
            }
        }

        private string nameMethod;

        public string NameMethod
        {
            get 
            { 
                return nameMethod; 
            }
            set 
            { 
                nameMethod = value;
                OnPropertyChanged(nameof(NameMethod));
            }
        }


        private string textMethod;

        public string TextMethod
        {
            get 
            { 
                return textMethod; 
            }
            set 
            { 
                textMethod = value;
                OnPropertyChanged(nameof(TextMethod));
            }
        }
        private string filterValue;

        public string FilterValue
        {
            get
            {
                return filterValue;
            }
            set
            {
                filterValue = value;
                OnPropertyChanged(nameof(FilterValue));
            }
        }
        public async void FilterInformation(string name)
        {
            var items = await getDictionary.GetDictionaryOfFunctionsByName(name);
            List<ItemTree> method = new List<ItemTree>();
            foreach (var item in items)
            {
                method.Add(new ItemTree(item.Id, item.NameFunction));
            }
            ItemsTree = method;
        }
        public async void SetInformationMethod(Guid guid)
        {
            MethodDiscription methodDiscription = await getDictionary.GetFunctionsByGuid(guid);
            TextMethod = ""+methodDiscription.DiscriptionFunction;
            NameMethod = methodDiscription.NameClass+"."+ methodDiscription.NameFunction;
        }

        private async void GetGuidAndNameMethod()
        {
            var items = (await getDictionary.GetDictionaryOfFunctions()).ToList();
            List<ItemTree> method = new List<ItemTree>();
            foreach (var item in items)
            {
                method.Add(new ItemTree(item.Id, item.NameFunction));
            }
            ItemsTree = method;
        }
        public LookingDictionaryViewModel()
        {
            Filter = new FilterCommand(this);
            Selected = new SelectedCommand(this);
            GetGuidAndNameMethod();
        }
    }
}
