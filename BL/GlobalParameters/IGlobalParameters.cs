using Entities.Entity;
using Entities.Model.Cron;

namespace BL.GlobalParameters;

public interface IGlobalParameters
{
    Task AddNewSmbConfig(SmbConfiguration parameters);
    Task<IList<SmbConfiguration>> GetSmbConfig();
    Task<IList<CronModel>> GetCronConfiguration();
}