using BL.GlobalParameters;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using BL.SMB;
using DAL;
using DAL.Repositories;
using Entities.Entity;
using EzSmb;
using Moq;

namespace Test;

public class SmbUnitTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ISmbServices _smbServices;
    private readonly IGlobalParameters _globalParameters;
    private readonly SmbConfiguration _smbConfiguration;
    public SmbUnitTest(ITestOutputHelper testOutputHelper)
    {
        var uow = new Mock<IUnitOfWork>();
        
        _smbConfiguration = new SmbConfiguration
        {
            Address = @"\\nas",
            Username = "user",
            Password = "pass"
        };
        
        _testOutputHelper = testOutputHelper;
        uow.Setup(x => x.SmbConfiguration).Returns(new Mock<IRepository<SmbConfiguration>>().Object);
        _smbServices = new SmbServices();
        _globalParameters = new GlobalParameters(uow.Object);
    }
    [Fact]
    public async void GetFilesAsync_ShouldGetNodes()
    {
        Node[] files = await _smbServices.GetFilesAsync(_smbConfiguration);
        files.Should().NotBeEmpty();
    }

    [Fact]
    public async void AddNewSmbConfig_ShouldAddToDB()
    {
        await _globalParameters.AddNewSmbConfig(_smbConfiguration);
    }
}