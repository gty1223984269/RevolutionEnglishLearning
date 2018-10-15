using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EnglishLearningDomain.Entities;
using EnglishLearningDomain.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EnglishLearning.Controllers
{
    [Produces("application/json")]
    [Route("api/WordRoot")]
    [EnableCors("any")]
    public class WordRootController : Controller
    {
        private readonly EnglishLearningDbContext _englishLearningDbContext;
        public readonly int pageSize = 8;

        public WordRootController(EnglishLearningDbContext englishLearningDbContext)
        {
            _englishLearningDbContext = englishLearningDbContext;
        }


        [HttpGet]
        [Route("AllWordRoots")]
        public IActionResult getWordRootsAsync(int pageNumber)
        {
             int skipIndex = pageSize * (pageNumber - 1);
            RootPageModel rootPageModel = new RootPageModel();
            var result = _englishLearningDbContext.WordRoots;
            rootPageModel.pageCount = result.Count();
            rootPageModel.wordRoots = result?.Skip(skipIndex).Take(pageSize).ToList();
            return Ok(rootPageModel);
        }


        [HttpGet]
        [Route("AllRelatedWordByRootId")]
        public List<RelatedWords> getRelatedWord(int wordRootId)
        {
            return _englishLearningDbContext.RelatedWords?.Where(a => a.RootId == wordRootId).ToList();
        }

    }
}
    

