namespace EnglishLearningDomain.SeedWork
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Entity : IAuditable
    {
        private int? _requestedHashCode;

        public long Id { get; set; }

        public DateTime CreatedDateTimeUtc { get; set; }

        [Required]
        [StringLength(64)]
        public string CreatedBy { get; set; }

        public DateTime UpdatedDateTimeUtc { get; set; }

        [Required]
        [StringLength(64)]
        public string UpdatedBy { get; set; }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var item = (Entity)obj;

            if (item.IsTransient() || IsTransient())
            {
                return false;
            }

            return item.Id == Id;
        }

        public override int GetHashCode()
        {
            if (IsTransient())
            {
                return base.GetHashCode();
            }

            if (!_requestedHashCode.HasValue)
            {
                // XOR for random distribution
                // (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                _requestedHashCode = Id.GetHashCode() ^ 31;
            }

            return _requestedHashCode.Value;
        }

        private bool IsTransient()
        {
            return Id == default(long);
        }
    }
}