using Entities.Entity;
using EzSmb;

namespace BL.SMB;

public interface ISmbServices
{
    Task<Node[]> GetFilesAsync(SmbConfiguration parameters);
}
