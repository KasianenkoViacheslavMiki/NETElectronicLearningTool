using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.ViewModels.ExamControl
{
    public class BaseControl
    {
        public virtual (string,bool) GetData()
        {
            return ("",false);
        }
    }
}
