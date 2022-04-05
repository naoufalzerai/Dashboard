using BL.SMB;
using Microsoft.AspNetCore.Mvc;
using Entities.Entity;
using Entities.Model.NAS;
using EzSmb;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]

public class SmbController : ControllerBase
{
    private readonly ISmbServices _smbServices;
    public SmbController(ISmbServices smbServices)
    {
        _smbServices = smbServices;
    }
    [HttpPost(Name = "GetSmb")]
    public IEnumerable<FileModel> Post([FromBody] SmbConfiguration config)
    {
        var result =  _smbServices.GetFilesAsync(config).Result;
        return result.Select(x => new FileModel()
        {
            Name = x.Name,
            Path = x.FullPath,
            Size = x.Size ,
            CreateDate = x.Created ?? new DateTime(),
            UpdateDate = x.Updated ?? new DateTime(),
        }).ToArray();
    }
    

}