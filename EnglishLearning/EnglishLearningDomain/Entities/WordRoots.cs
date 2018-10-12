using EnglishLearningDomain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnglishLearningDomain.Entities
{
   public class WordRoots: Entity
    {
        public bool IsActive { get; set; }

        [StringLength(100)]
        public string Word { get; set; }

        [StringLength(300)]
        public string ChineseMeaning { get; set; }

    }
}
