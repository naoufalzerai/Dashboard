using Entities.Entity;
using Entities.Model.NAS;
using EzSmb;

namespace BL.SMB;

public interface ISmbServices
{
    Task<IEnumerable<FileModel>> GetFilesAsync(SmbConfiguration parameters);
}
