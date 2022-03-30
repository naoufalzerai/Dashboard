
using EzSmb;

namespace BL.SMB;

public static class Smb
{
    public static async Task<Node[]> GetFilesAsync(string address, string username, string password)
    {

        var folder = await Node.GetNode(address, username, password);

        // List items
        var nodes = await folder.GetList();

        return nodes;
    }
}