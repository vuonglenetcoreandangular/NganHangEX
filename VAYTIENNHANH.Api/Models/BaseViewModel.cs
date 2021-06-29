using System;

namespace VAYTIENNHANH.Api.Models
{
    public class BaseViewModel
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}