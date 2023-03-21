using NETElectronicLearningTool.UserControls;
using NETElectronicLearningTool.ViewModels;
using NETElectronicLearningTool.ViewModels.DictionarySubViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.Command.CommandDictionaryWindow
{
    public class DictionaryUpdateViewCommand : ICommand
    {
        private DictionaryViewModel dictionaryViewModel;
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public DictionaryUpdateViewCommand(DictionaryViewModel _dictionaryViewModel)
        {
            dictionaryViewModel = _dictionaryViewModel;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter.ToString() == "LookingDictionary")
            {
                dictionaryViewModel.SelectedUserControl = new LookingDictionaryViewModel();
            }
            if (parameter.ToString() == "TableDictionary")
            {
                dictionaryViewModel.SelectedUserControl = new TableDictionaryViewModel();
            }
        }
    }
}
