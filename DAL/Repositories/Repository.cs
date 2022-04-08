using System.Linq.Expressions;
using Entities.Entity;
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

        public Task AddAsync(IEntity entity)
        {
             
            entity.Id = Guid.NewGuid();
            RedisValue value = Serialize(entity);
            return _context.SetAddAsync(this._key, value);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            List<RedisValue> values = new List<RedisValue>();
            foreach (var entity in entities)
            {
                values.Add(Serialize(entities));
            }
            return _context.SetAddAsync(_key, values.ToArray());
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
        private  TEntity Deserialize<TEntity>(RedisValue serialized)
        {
            if (serialized.IsNull)
                return default(TEntity)!;
            return JsonConvert.DeserializeObject<TEntity>(serialized.ToString());
        }
        
        private string Serialize(object obj)
        {
            if (obj is null)
                return default;
            return JsonConvert.SerializeObject(obj);
        }
        Task<IList<TEntity>> IRepository<TEntity>.GetAllAsync()
        {
            var result = _context.SetScan(_key).ToArray();
            return Deserialize<TEntity>(result);
        }

        TEntity IRepository<TEntity>.GetByIdAsync(Guid id)
        {
            
            var result = _context.SetScan(_key, $"*\"Id\":\"{id}\"*")
                .FirstOrDefault();
            return Deserialize<TEntity>(result);
        }

        void IRepository<TEntity>.Remove(TEntity entity)
        {
            var val = Serialize(entity);
            _context.SetRemove(_key, val);
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