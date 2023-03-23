using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class UserAnswerTest
    {
        public Guid Id { get; set; }
        
        public virtual Guid? IdTest { get; set; }
        public virtual Test? Test { get; set; }

        public virtual Guid? IdUser { get; set; }
        public virtual User? User { get; set; } 

        public virtual IEnumerable<UserAnswer>? UserAnswers { get; set; }
    }
}
