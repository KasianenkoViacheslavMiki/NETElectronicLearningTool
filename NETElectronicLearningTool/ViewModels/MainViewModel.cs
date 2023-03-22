using NETElectronicLearningTool.Command.CommandMainWindow;
using NETElectronicLearningTool.ViewModels.Mediator;
using Prism.Events;
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
        private ViewModelBase _selectedUserControl;

        private int sizeBar;
        private bool visibleBar;

        public bool VisibleBar
        {
            get 
            { 
                return visibleBar; 
            }
            set 
            { 
                visibleBar = value;
                OnPropertyChanged(nameof(VisibleBar));
            }
        }
        

        public int SizeBar
        {
            get 
            { 
                return sizeBar; 
            }
            set 
            { 
                sizeBar = value;
                OnPropertyChanged(nameof(SizeBar));
            }
        }


        public MainViewModel()
        {
            EventSystem.Subscribe<ToggleMessage>(ToggleBar);
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
                OnPropertyChanged(nameof(SelectedUserControl));
            }
        }
        public ICommand UpdateViewCommand { get; set; }

        public void ToggleBar(ToggleMessage msg)
        {
            if (msg.message == "Hide")
            {
                return;
            }
            if (msg.message == "Show")
            {
                return;
            }
        }
    }
}
