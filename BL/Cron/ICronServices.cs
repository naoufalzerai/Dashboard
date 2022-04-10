using BL.Interfaces;
using Entities.Entity;
using Entities.Model.Cron;

namespace BL.Cron;

public interface ICronServices:IBLWithUnitOfWork
{
    Task<IList<CronModel>> GetCronConfiguration();
    Task SaveCronConfiguration(CronConfiguration cronConfiguration);
}