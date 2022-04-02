using DAL;
using DAL.Repositories;
using Entities.Entity;
using EzSmb;

namespace BL.SMB;


public class SmbServices : ISmbServices
{
    public async Task<Node[]> GetFilesAsync(SmbConfiguration parameters)
    {
        var folder = await Node.GetNode(parameters.Address, parameters.Username, parameters.Password);
        // List items
        var nodes = await folder.GetList();
        return nodes;
    }


}