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
        public string Word { get; set; }

        [StringLength(300)]
        public string ChineseMeaning { get; set; }

        [StringLength(400)]
        public string RememberLogic { get; set; }


    }
}
