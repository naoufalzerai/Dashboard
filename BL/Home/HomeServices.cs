using BL.Interfaces;
using DAL;
using DAL.Repositories;
using Entities.Entity;

namespace BL.Home;

public class HomeServices:IHomeServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<HomeConfiguration> _homeConfiguration;

    public HomeServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _homeConfiguration = _unitOfWork.HomeConfiguration;
    }
    public Task<IList<HomeConfiguration>> GetHomeConfig()
    {
        return _homeConfiguration.GetAllAsync();
    }

    public Task SaveHomeConfig(HomeConfiguration homeConfiguration)
    {
        return _homeConfiguration.AddAsync(homeConfiguration);
    }

}