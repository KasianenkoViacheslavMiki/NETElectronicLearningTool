using NETElectronicLearningTool.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.Interface
{
    interface ISetLevel
    {
        public Task<LevelKnowledge> SetLevelKnowledge(Guid? IdLevelKnowledge, Guid? IdUser, float level);
    }
}
