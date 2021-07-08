using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Threading.Tasks;
using VAYTIENNHANH.Model.DataModels;
using static System.Net.Mime.MediaTypeNames;

namespace VAYTIENNHANH.Service
{
    public interface IMasterBaseService<T> where T : class
    {
        public Task<BaseResult<T>> GetAll();

        public Task<T> GetById(long id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        public void Update(T obj);

        public void DeleteById(long id);

        public void Delete(T obj);

        public void Create(T obj);
        public void UpImageFromBase64ToJpg(string folder, string base64String, string imgName);
        public System.Drawing.Bitmap Base64StringToBitmap(string base64String);
    }
}