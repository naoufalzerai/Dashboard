using DAL.Repositories;
using Entities.Entity;
namespace DAL;
using System;


public interface IUnitOfWork : IDisposable
{
    IRepository<SmbConfiguration> SmbConfiguration { get; }
    IRepository<CronConfiguration> CronConfiguration { get; }
    IRepository<HomeConfiguration> HomeConfiguration { get; }
    void Save();
}
