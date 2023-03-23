using NETElectronicLearningTool.ViewModels.ExamControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.ViewModels.Strategy
{
    public class CreateTextBox : ICreateControl
    {
        public BaseControl CreateControl(Guid id, string answer)
        {
            return new TextBoxControl();
        }
    }
}
