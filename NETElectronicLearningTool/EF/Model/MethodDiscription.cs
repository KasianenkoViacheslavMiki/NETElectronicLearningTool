using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class MethodDiscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? NameClass { get; set; }
        public string? NameFunction { get; set; }
        public string? DiscriptionFunction { get; set; }
    }
}
