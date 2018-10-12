namespace EnglishLearningDomain.SeedWork
{
    using System;

    public interface IAuditable
    {
        DateTime CreatedDateTimeUtc { get; set; }

        string CreatedBy { get; set; }

        DateTime UpdatedDateTimeUtc { get; set; }

        string UpdatedBy { get; set; }
    }
}
