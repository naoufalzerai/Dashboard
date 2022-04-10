using System.Drawing.Printing;
using AutoMapper;
using BL.Interfaces;
using DAL;
using DAL.Repositories;
using Entities.Entity;
using Entities.Model.Cron;

namespace BL.GlobalParameters;

public class GlobalParameters:IGlobalParameters
{
    private readonly IRepository<SmbConfiguration> _smb;
    private readonly IRepository<CronConfiguration> _cron;
    private Mapper Mapper { get; }

    public GlobalParameters(IUnitOfWork unitOfWork)
    {
        _smb = unitOfWork.SmbConfiguration;
        _cron = unitOfWork.CronConfiguration;
        
        //Automapper
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<CronConfiguration, CronModel>()
                .ForMember(dest=>dest.Status,act=>act.MapFrom(src=>src.Status))
        );
        Mapper= new Mapper(config);
    }

    public Task AddNewSmbConfig(SmbConfiguration parameters)
    {
        return _smb.AddAsync(parameters);
    }

    public Task<IList<SmbConfiguration>> GetSmbConfig()
    {
        return _smb.GetAllAsync();
    }
    
}