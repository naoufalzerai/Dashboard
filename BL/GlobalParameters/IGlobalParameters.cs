using Entities.Entity;

namespace BL.GlobalParameters;

public interface IGlobalParameters
{
    Task AddNewSmbConfig(SmbConfiguration parameters);
}