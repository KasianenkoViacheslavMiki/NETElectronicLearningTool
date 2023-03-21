using NETElectronicLearningTool.EF;
using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.ViewModels.DictionarySubViewModal
{
    public class TableDictionaryViewModel : ViewModelBase
    {
        IGetDictionary getDictionary = new RepositoryDictionary(new LearningToolContext());

        public async void TableDictionary()
        {
            var items = await getDictionary.GetDictionaryOfFunctions();
            var temp = items.Select(x => new
            {
                x.NameClass,
                x.NameFunction,
                x.DiscriptionFunction,
            }).ToList();
            List<ItemTable> itemsTable = new List<ItemTable>(); 
            foreach (var item in temp)
            {
                itemsTable.Add(new ItemTable(item.NameClass,item.NameFunction,item.DiscriptionFunction));
            }
            TableMethod = itemsTable;
        }

        private IEnumerable<ItemTable> tableMethod;

        public IEnumerable<ItemTable> TableMethod
        {
            get 
            { 
                return tableMethod; 
            }
            set 
            { 
                tableMethod = value;
                OnPropertyChanged(nameof(TableMethod));
            }
        }


        public TableDictionaryViewModel()
        {
            TableDictionary();
        }

    }
    public struct ItemTable
    {
        public ItemTable(string nameClass, string nameFunction, string discription)
        {
            NameClass = nameClass;
            NameFunction = nameFunction;
            Discription = discription;
        }

        public string NameClass { get; set; }
        public string NameFunction { get; set; }
        public string Discription { get; set; }
    }

}
