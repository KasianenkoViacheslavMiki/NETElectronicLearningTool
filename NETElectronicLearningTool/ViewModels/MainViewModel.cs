using NETElectronicLearningTool.Command.CommandMainWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private ViewModelBase _selectedUserControl= new ChartViewModel();

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
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
            }
        }
        public ICommand UpdateViewCommand { get; set; }

    }
}
