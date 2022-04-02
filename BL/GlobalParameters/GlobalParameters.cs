using DAL;
using DAL.Repositories;
using Entities.Entity;

namespace BL.GlobalParameters;

public class GlobalParameters:IGlobalParameters
{
    private readonly IRepository<SmbConfiguration> _parametersRepository;

    public GlobalParameters(IUnitOfWork unitOfWork)
    {
        _parametersRepository = unitOfWork.SmbConfiguration;
    }

    public Task AddNewSmbConfig(SmbConfiguration parameters)
    {
        return _parametersRepository.AddAsync(parameters);
    }
}