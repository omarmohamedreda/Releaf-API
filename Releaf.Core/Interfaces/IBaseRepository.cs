﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Releaf.Core.Interfaces
{
	public interface IBaseRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<bool> DeleteByIdAsync(int id);
		Task<bool> ExistsAsync(int id);
	}
}
