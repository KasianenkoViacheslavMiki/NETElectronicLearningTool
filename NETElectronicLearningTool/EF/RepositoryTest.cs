using NETElectronicLearningTool.EF.Model;
using NETElectronicLearningTool.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF
{
    public class RepositoryTest : IGetTest, IPassExam
    {
        public Task<Test> GetTest(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Test>> GetTests()
        {
            throw new NotImplementedException();
        }

        public Task<bool> PassTest(Test test)
        {
            throw new NotImplementedException();
        }
    }
}
