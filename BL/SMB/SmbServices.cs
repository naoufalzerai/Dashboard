using BL.Interfaces;
using DAL;
using DAL.Repositories;
using Entities.Entity;
using Entities.Model.NAS;
using EzSmb;

namespace BL.SMB;


public class SmbServices : ISmbServices
{
    public async Task<IEnumerable<FileModel>>  GetFilesAsync(SmbConfiguration parameters)
    {
        var folder = await Node.GetNode(parameters.Address, parameters.Username, parameters.Password,true);
        
        // List items
        var result = await folder.GetList();
        return result.Select(x => new FileModel()
        {
            Name = x.Name,
            Path = x.FullPath,
            Size = x.Size ?? 0,
            IsFolder = (x.Type == NodeType.Folder),
            IsServer = (x.Type == NodeType.Server),
            CreateDate = x.Created ?? new DateTime(),
            UpdateDate = x.Updated ?? new DateTime(),
        }).ToArray();
    }


}