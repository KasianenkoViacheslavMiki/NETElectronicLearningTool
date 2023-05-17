using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class LevelKnowledge
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public float? LvlKnowledge { get; set; }

        public Guid? IdUser { get; set; }
        public User? User { get; set; }

        public Guid? IdElementLearning {  get; set; }
        public ElementLearning? ElementLearning { get; set; }
    }
}
