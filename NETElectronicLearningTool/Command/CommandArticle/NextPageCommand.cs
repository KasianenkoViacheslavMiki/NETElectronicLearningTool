﻿using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NETElectronicLearningTool.Command.CommandArticle
{
    public class NextPageCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        ArticleViewModel articleViewModel;

        public NextPageCommand(ArticleViewModel _articleViewModel)
        {
            this.articleViewModel = _articleViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            articleViewModel.NumberPage++;
            articleViewModel.ChangePage(articleViewModel.NumberPage);
        }
    }
}
