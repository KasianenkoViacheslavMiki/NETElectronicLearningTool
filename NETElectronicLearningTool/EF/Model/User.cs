﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF.Model
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }

        public string? Name { get; set; }   
        public string? Surname { get; set; }
        public float? WishsLevelKnowledge { get; set; }
        public IEnumerable<LevelKnowledge>? LevelKnowledges { get; set; }
        public IEnumerable<UserAnswerTest>? UserAnswerTests { get; set; }

    }
}
