using Akshay.ProjectDemo.Entities;
using Akshay.ProjectDemo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshay.ProjectDemo.Repository.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;


        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Remove(T country)
        {
            _context.Set<T>().Remove(country);
            await _context.SaveChangesAsync();
        }

        public async Task Save(T country)
        {
            _context.Set<T>().Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T country)
        {
            _context.Set<T>().Update(country);
            await _context.SaveChangesAsync();
        }
    }
}
