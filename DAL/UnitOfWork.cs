using DAL.Repositories;
using Entities.Entity;
using StackExchange.Redis;

namespace DAL;

public class UnitOfWork:IUnitOfWork
{
    private readonly ConnectionMultiplexer _redis;
    public UnitOfWork(string connexionString)
    {
        _redis= ConnectionMultiplexer.Connect(connexionString);
        SmbConfiguration = new Repository<SmbConfiguration>(_redis);
        CronConfiguration = new Repository<CronConfiguration>(_redis);
        HomeConfiguration = new Repository<HomeConfiguration>(_redis);
    }
    public void Dispose()
    {
        _redis.Dispose();
    }

    public IRepository<SmbConfiguration> SmbConfiguration { get; }
    public IRepository<CronConfiguration> CronConfiguration { get; }
    public IRepository<HomeConfiguration> HomeConfiguration { get; }

    public void Save()
    {
        throw new NotImplementedException();
    }
}