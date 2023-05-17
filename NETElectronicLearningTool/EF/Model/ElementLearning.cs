using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class ElementLearning
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<TestQuestion>? TestQuestions { get; set; }
        public IEnumerable<LevelKnowledge>? LevelKnowledges { get; set; }
    }
}
