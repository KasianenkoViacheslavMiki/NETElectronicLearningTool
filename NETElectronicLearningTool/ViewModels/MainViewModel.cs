using NETElectronicLearningTool.Command.CommandMainWindow;
using NETElectronicLearningTool.ViewModels.Mediator;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NETElectronicLearningTool.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private ViewModelBase _selectedUserControl;

        private int sizeBar=30;
        private bool visibleBar = true;

        public Visibility VisibleBar
        {
            get 
            { 
                return (visibleBar? Visibility.Visible: Visibility.Hidden); 
            }
            set 
            {
                visibleBar = (value == Visibility.Visible ? true:false);
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
                VisibleBar = Visibility.Hidden;
                SizeBar = 0;
                return;
            }
            if (msg.message == "Show")
            {
                VisibleBar = Visibility.Visible;
                SizeBar = 30;
                return;
            }
        }
    }
}
