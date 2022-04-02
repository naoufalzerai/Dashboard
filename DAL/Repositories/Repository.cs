using System.Linq.Expressions;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _context;
        private readonly RedisKey _key;
        public Repository(ConnectionMultiplexer redis)
        {
            this._redis = redis;
            this._key = new RedisKey(typeof(TEntity).FullName);;
            this._context = redis.GetDatabase();
        }

        public Task AddAsync(TEntity entity)
        {
            RedisValue value = new RedisValue(Serialize(entity));
            return this._context.ListLeftPushAsync(this._key, value);
        }

        Task IRepository<TEntity>.AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        
        private Task<IList<TEntity>> Deserialize<TEntity>(RedisValue[] serialized)
        {
            IList<TEntity> list = new List<TEntity>();
            foreach (var value in serialized)
                list.Add(JsonConvert.DeserializeObject<TEntity>(value.ToString()));
            return Task.FromResult(list);

        }
        
        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        Task<IList<TEntity>> IRepository<TEntity>.GetAllAsync()
        {
            //var result = _context.ListRange(this._key);
            var result = Deserialize<TEntity>(_context.ListRange(this._key));
            return result;
        }

        ValueTask<TEntity> IRepository<TEntity>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepository<TEntity>.SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}