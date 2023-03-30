using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.Command.CommandExam
{
    public class PassAnswerCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        PassExamViewModel passExamViewModel;

        public PassAnswerCommand(PassExamViewModel _passExamViewModel)
        {
            this.passExamViewModel = _passExamViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            await passExamViewModel.PassQuestion();
            passExamViewModel.ChangeQuestion(++passExamViewModel.NumberQuestion);
        }
    }
}
