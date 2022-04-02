using DAL.Repositories;
using Entities.Entity;
namespace DAL;
using System;


public interface IUnitOfWork : IDisposable
{
    IRepository<SmbConfiguration> SmbConfiguration { get; }
    void Save();
}
