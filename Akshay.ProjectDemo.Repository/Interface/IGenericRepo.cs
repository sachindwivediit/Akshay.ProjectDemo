using Akshay.ProjectDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshay.ProjectDemo.Repository.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Save(T country);
        Task Update(T country);

        Task Remove(T country);
    }
}
