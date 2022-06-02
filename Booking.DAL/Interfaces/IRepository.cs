using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Domain.Documents;
using Booking.Domain.Interfaces;

namespace Booking.DAL.Interfaces
{
    public interface IRepository<T> where T : IDocument
    {
        Task AddAsync(T entity);

        Task RemoveAsync(Guid entityId);

        Task<T> GetByIdAsync(Guid itemId);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
