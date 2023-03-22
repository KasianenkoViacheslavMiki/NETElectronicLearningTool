using NETElectronicLearningTool.EF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.ViewModels
{
    public class PassExamViewModel:ViewModelBase
    {
        public ObservableCollection<ItemTree> Properties { get; set; }

        private Test test;

		public PassExamViewModel(Test test)
		{
			Test = test;
		}
			
		public Test Test
		{
			get { return test; }
			set { test = value; }
		}
	}
}
