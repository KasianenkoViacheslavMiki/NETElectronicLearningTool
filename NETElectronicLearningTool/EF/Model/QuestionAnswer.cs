using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class QuestionAnswer
    {
        public Guid Id { get; set; }
        public string? Answer { get; set; }
        public bool? TrueOrFalse { get; set; }
        public TestQuestion? TestQuestion { get; set; }
    }
}
