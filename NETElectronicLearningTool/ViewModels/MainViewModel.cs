using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private ViewModelBase _selectedUserControl= new ChartViewModel();

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
    }
}
