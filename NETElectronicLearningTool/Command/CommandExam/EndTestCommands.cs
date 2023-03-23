using NETElectronicLearningTool.ViewModels.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.Command.CommandExam
{
    public class EndTestCommands : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            EventSystem.Publish(new ToggleMessage() { message = "Show" });
        }
    }
}
