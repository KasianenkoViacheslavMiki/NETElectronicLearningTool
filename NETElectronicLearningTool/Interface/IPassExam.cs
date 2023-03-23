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
        public Task<UserAnswer> PassQuestion(Guid IdTest, UserAnswer userAnswer);
        public Task<UserAnswerTest> InitPass(Guid testGuid, Guid user);
    }
}
