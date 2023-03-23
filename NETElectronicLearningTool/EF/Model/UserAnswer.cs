using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class UserAnswer
    {
        public Guid Id { get; set; }
        
        public string? TextAnswer { get; set; }

        public virtual Guid? IdUserAnswerTest { get; set; }
        public virtual UserAnswerTest? UserAnswerTest { get; set; }
        public virtual Guid? IdQuestionAnswer { get; set; }
        public virtual QuestionAnswer? QuestionAnswer { get; set; }
    }
}
