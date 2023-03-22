using NETElectronicLearningTool.UserControls;
using NETElectronicLearningTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.Command.CommandMainWindow
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel mainViewModel;
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public UpdateViewCommand(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
            canExecute += CanExecute;
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
            if (canExecute == null)
            {
                return;
            }

            if (parameter == null)
            {
                return;
            }

            if (parameter.ToString() == "Graf")
            {
                mainViewModel.SelectedUserControl = new ChartViewModel();
                return;
            }

            if (parameter.ToString() == "Settings")
            {
                mainViewModel.SelectedUserControl = new SettingViewModel();
                return;
            }

            if (parameter.ToString() == "Dictionary")
            {
                mainViewModel.SelectedUserControl = new DictionaryViewModel();
                return;
            }

            if (parameter.ToString() == "Avtor")
            {
                mainViewModel.SelectedUserControl = new AboutViewModel();
                return;
            }

            if (parameter.ToString() == "Teach")
            {
                mainViewModel.SelectedUserControl = new ArticleViewModel();
                return;
            }
            if (parameter.ToString() == "Exam")
            {
                mainViewModel.SelectedUserControl = new ExamViewModel();
                return;
            }
        }
    }
}
