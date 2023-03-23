using NETElectronicLearningTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.Command.CommandExam
{
    public class ChangeTestCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        ExamViewModel exam;

        public ChangeTestCommand(ExamViewModel exam)
        {
            this.exam = exam;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter == null)
            {
                return;
            }
            exam.SetTest(((ItemTree)parameter).Id);
        }
    }
}
