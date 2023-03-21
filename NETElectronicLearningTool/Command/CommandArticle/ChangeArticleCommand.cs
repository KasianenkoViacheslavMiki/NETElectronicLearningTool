using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.Command.CommandArticle
{
    public class ChangeArticleCommand : ICommand
    {
        ArticleViewModel articleViewModel;
        public ChangeArticleCommand(ArticleViewModel article)
        {
            articleViewModel = article;
        }
        public event EventHandler? CanExecuteChanged;

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
            articleViewModel.SetArticle(((ItemTree)parameter).Id);
        }
    }
}
