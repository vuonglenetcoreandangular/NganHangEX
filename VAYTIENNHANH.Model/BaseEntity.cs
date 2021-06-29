using System;

namespace VAYTIENNHANH.Model
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}