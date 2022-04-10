using BL.Interfaces;
using Entities.Entity;
using Entities.Model.Cron;

namespace BL.GlobalParameters;

public interface IGlobalParameters:IBLWithUnitOfWork
{
    Task AddNewSmbConfig(SmbConfiguration parameters);
    Task<IList<SmbConfiguration>> GetSmbConfig();
}