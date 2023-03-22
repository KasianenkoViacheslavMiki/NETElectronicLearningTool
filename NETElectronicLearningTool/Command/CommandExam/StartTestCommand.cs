using NETElectronicLearningTool.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.Command.CommandExam
{
    public class StartTestCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        Exam exam;

        public StartTestCommand(Exam exam)
        {
            this.exam = exam;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            
        }
    }
}
