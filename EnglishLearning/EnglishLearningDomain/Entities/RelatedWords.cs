using EnglishLearningDomain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnglishLearningDomain.Entities
{
  public  class RelatedWords: Entity
    {
        public bool IsActive { get; set; }

        public Int64 RootId { get; set; }

        [StringLength(100)]
        public bool Word { get; set; }

        [StringLength(300)]
        public bool ChineseMeaning { get; set; }

        [StringLength(400)]
        public bool RememberLogic { get; set; }


    }
}
