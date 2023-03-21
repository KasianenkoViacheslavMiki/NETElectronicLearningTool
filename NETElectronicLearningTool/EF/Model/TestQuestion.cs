using NETElectronicLearningTool.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class TestQuestion
    {
        public Guid Id { get; set; }
        public string? Question { get; set; }

        public TypeQuestion? Type { get; set; }

        public Test? Test { get; set; }
        IEnumerable<QuestionAnswer>? QuestionAnswers { get; set; }
    }
}
