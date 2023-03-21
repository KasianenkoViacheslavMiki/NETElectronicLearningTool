using NETElectronicLearningTool.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.Interface
{
    public interface IGetTest
    {
        public Task<IEnumerable<Test>> GetTests();
        public Task<Test> GetTest(Guid guid);
    }
}
