using Microsoft.EntityFrameworkCore;
using Releaf.Core.Interfaces;
using Releaf.Core.Models;
using Releaf.EF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Releaf.EF.Repository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected readonly ApplicationDbContext _context;

		public BaseRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<T> UpdateAsync(T entity)
		{
			_context.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> DeleteByIdAsync(int id)
		{
			var entity = await _context.Set<T>().FindAsync(id);
			if (entity == null)
				return false;

			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> ExistsAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id) != null;
		}



	}
}
