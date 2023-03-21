using NETElectronicLearningTool.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.Interface
{
    public interface IPassExam
    {
        public Task<bool> PassTest(Test test);
        //public Task<bool> PassQuestion( test);

    }
}
