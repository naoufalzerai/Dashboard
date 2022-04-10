using BL.Interfaces;
using Entities.Entity;

namespace BL.Home;

public interface IHomeServices:IBLWithUnitOfWork
{
    Task<IList<HomeConfiguration>> GetHomeConfig();
    Task SaveHomeConfig(HomeConfiguration homeConfiguration);
}