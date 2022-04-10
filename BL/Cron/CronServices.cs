using AutoMapper;
using BL.Interfaces;
using DAL;
using DAL.Repositories;
using Entities.Entity;
using Entities.Model.Cron;

namespace BL.Cron;

public class CronServices:ICronServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<CronConfiguration> _cronConfiguration;

    private Mapper Mapper { get; }
    
    public CronServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _cronConfiguration = unitOfWork.CronConfiguration;
        //Automapper
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<CronConfiguration, CronModel>()
                .ForMember(dest=>dest.Status,act=>act.MapFrom(src=>src.Status))
        );
        Mapper= new Mapper(config);
    }
    public async Task<IList<CronModel>> GetCronConfiguration()
    {
        var result = await _cronConfiguration.GetAllAsync();
        return Mapper.Map<IList<CronModel>>(result);
    }

    public Task SaveCronConfiguration(CronConfiguration cronConfiguration)
    {
        return _cronConfiguration.AddAsync(cronConfiguration);
    }
}