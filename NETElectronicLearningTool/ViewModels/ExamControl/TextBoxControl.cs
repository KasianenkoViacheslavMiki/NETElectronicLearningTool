using NETElectronicLearningTool.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.ViewModels.ExamControl
{
    public class TextBoxControl : BaseControl
    {
        public override (string, bool) GetData()
        {
            return (base.GetData().Item1 == "") ? (Name.ToString(),true):("", false);
        }

        private string? textAnswer="";
        public string? Name
        {
            set
            {
                textAnswer = value;
            }
            get
            {
                return textAnswer;
                OnPropertyChanged(nameof(Name));
            }

        }
        public TextBoxControl()
        {
        }
    }
}
