using NETElectronicLearningTool.ViewModels.DictionarySubViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.Command.CommandDictionaryWindow.SubCommandDictionary
{
    public class FilterCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        LookingDictionaryViewModel lookingDictionary;

        public FilterCommand(LookingDictionaryViewModel lookingDictionary)
        {
            this.lookingDictionary = lookingDictionary;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            lookingDictionary.FilterInformation((string)parameter);
        }
    }
}
