using NETElectronicLearningTool.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.Interface
{
    public interface IGetDictionary
    {
        public Task<IEnumerable<MethodDiscription>> GetDictionaryOfFunctions();
        public Task<IEnumerable<MethodDiscription>> GetDictionaryOfFunctionsByName(string name);
    }
}
