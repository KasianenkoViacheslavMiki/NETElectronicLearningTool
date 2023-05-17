using NETElectronicLearningTool.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class TestQuestion
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Question { get; set; }

        public TypeQuestion? Type { get; set; }
        public Guid? IdTest { get; set; }
        public Test? Test { get; set; }
        public Guid? IdElementLearning { get; set; }    
        public ElementLearning? ElementLearning { get; set; }
        public IEnumerable<QuestionAnswer>? QuestionAnswers { get; set; }
    }
}
