using NETElectronicLearningTool.Command.CommandDictionaryWindow;
using NETElectronicLearningTool.Command.CommandMainWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.ViewModels
{
    public class DictionaryViewModel:ViewModelBase
    {
        private ViewModelBase _selectedUserControl;

        public DictionaryViewModel()
        {
            UpdateViewCommand = new DictionaryUpdateViewCommand(this);
        }

        public ViewModelBase SelectedUserControl
        {
            get
            {
                return _selectedUserControl;
            }
            set
            {
                _selectedUserControl = value;
                OnPropertyChanged("SelectedUserControlDictionaryForm");
            }
        }
        public ICommand UpdateViewCommand { get; set; }
    }
}
