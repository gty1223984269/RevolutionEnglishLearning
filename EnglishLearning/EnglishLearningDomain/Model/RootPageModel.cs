using EnglishLearningDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishLearningDomain.Model
{
  public  class RootPageModel
    {
        public List<WordRoots> wordRoots { set; get; }
        public int pageCount { set; get; }
    }
}
