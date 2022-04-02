using DAL.Repositories;
using Entities.Entity;
using StackExchange.Redis;

namespace DAL;

public class UnitOfWork:IUnitOfWork
{
    private readonly ConnectionMultiplexer _redis;
    public UnitOfWork(string connexionString)
    {
        _redis= ConnectionMultiplexer.Connect(connexionString);;
        SmbConfiguration = new Repository<SmbConfiguration>(_redis);
    }
    public void Dispose()
    {
        _redis.Dispose();
    }

    public IRepository<SmbConfiguration> SmbConfiguration { get; }
    public void Save()
    {
        throw new NotImplementedException();
    }
}