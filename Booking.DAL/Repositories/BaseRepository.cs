using Booking.DAL.Interfaces;
using Booking.Domain.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Booking.DAL.MongoConfig;
using Booking.Domain.Interfaces;

namespace Booking.DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : IDocument
    {
        protected readonly IMongoCollection<T> collection;

        protected BaseRepository(MongoDbSettings settings)
        {
            var db = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            collection = db.GetCollection<T>(GetCollectionName(typeof(T)));
        }
        
        public async Task AddAsync(T entity) => await collection.InsertOneAsync(entity);

        public async Task RemoveAsync(Guid entityId)
        {
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, entityId);
            await collection.FindOneAndDeleteAsync(filter);
        }

        public async Task<T> GetByIdAsync(Guid itemId)
        {
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, itemId);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }
        
        private string GetCollectionName(ICustomAttributeProvider documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                .FirstOrDefault())?.CollectionName;
        }
        
        public async Task<IEnumerable<T>> GetAllAsync() => await collection.Find(Builders<T>.Filter.Empty).ToListAsync();
    }
}
