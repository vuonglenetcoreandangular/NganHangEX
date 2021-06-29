using System.Collections.Generic;

namespace VAYTIENNHANH.Model.DataModels
{
    public class BaseResult<T> where T : class
    {
        public List<T> Data { get; set; }
        public int TotalPage { get; set; }
    }
}