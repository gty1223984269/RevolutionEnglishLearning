using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearningDomain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EnglishLearning.Controllers
{
    [Produces("application/json")]
    [Route("api/WordRoot")]

    public class WordRootController : Controller
    {
        private readonly EnglishLearningDbContext _englishLearningDbContext;
        public readonly int pageSize = 10;

        public WordRootController(EnglishLearningDbContext englishLearningDbContext)
        {
            _englishLearningDbContext = englishLearningDbContext;
        }


        [HttpGet]
        [Route("AllWordRoots")]
        public List<WordRoots> getWordRoots(int pageNumber)
        {
             int skipIndex = pageSize * (pageNumber - 1);

            return _englishLearningDbContext.WordRoots?.Skip(skipIndex).Take(pageSize).ToList();
        }


        [HttpGet]
        [Route("AllRelatedWordByRootId")]
        public List<RelatedWords> getRelatedWord(int wordRootId)
        {
            return _englishLearningDbContext.RelatedWords?.Where(a => a.RootId == wordRootId).ToList();
        }

    }
}
    

