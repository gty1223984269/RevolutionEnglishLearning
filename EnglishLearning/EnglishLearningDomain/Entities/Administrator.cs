using System.ComponentModel.DataAnnotations;
using EnglishLearningDomain.SeedWork;
namespace EnglishLearningDomain.Entities
{
    public class Administrator : Entity
    {
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string NormalizedEmail { get; set; }

        public bool IsActive { get; set; }
    }
}
