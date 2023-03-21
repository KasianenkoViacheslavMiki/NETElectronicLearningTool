﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class Test
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual IEnumerable<TestQuestion>? TestQuestions { get; set; }
    }
}