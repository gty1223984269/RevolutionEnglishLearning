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
            rootPageModel.wordRoots = result?.Where(a=>a.IsActive==true).Skip(skipIndex).Take(pageSize).ToList();
            return Ok(rootPageModel);
        }


        [HttpGet]
        [Route("AllRelatedWordByRootId")]
        public List<RelatedWords> getRelatedWord(int wordRootId)
        {
            return _englishLearningDbContext.RelatedWords?.Where(a => a.RootId == wordRootId).ToList();
        }

        [HttpPut]
        [Route("AddRelateWord")]
        public async Task<IActionResult> AddRelateWord(RelatedWords relatedWords)
        {
          var entity=  _englishLearningDbContext.RelatedWords.Where(a => a.Id == relatedWords.Id).FirstOrDefault();
            entity.RememberLogic = relatedWords.RememberLogic;
            entity.Id = relatedWords.Id;
            entity.Word = relatedWords.Word;
            entity.ChineseMeaning = relatedWords.ChineseMeaning;
            _englishLearningDbContext.AddRange(entity);
            await _englishLearningDbContext.SaveChangesAsync();
            return NoContent();

          }

        [HttpPut]
        [Route("AddWordRoot")]
        public async Task<IActionResult> AddWordRoot(WordRoots wordRoots)
        {
            _englishLearningDbContext.AddRange(wordRoots);
            await _englishLearningDbContext.SaveChangesAsync();
            return NoContent();

        }

        [HttpGet]
        [Route("GetRelatedWordEntity")]
        public IActionResult GetWordEntity(int entityId)
        {

            return Ok(_englishLearningDbContext.RelatedWords.Where(a => a.Id == entityId && a.IsActive == true));

        }


    }
}
    

