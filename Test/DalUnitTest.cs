using AutoFixture;
using DAL;
using Entities.Entity;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Test;

public class DalUnitTest
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITestOutputHelper _testOutputHelper;

    public DalUnitTest( ITestOutputHelper testOutputHelper)
    {
        _unitOfWork = new UnitOfWork("192.168.2.115:6379");
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void Repository_AddAsync_ShouldInsert()
    {
        //arrange
        SmbConfiguration parameters = new Fixture().Create<SmbConfiguration>();
        //act
        await _unitOfWork.SmbConfiguration.AddAsync(parameters);
        //assert
    }
    
    [Fact]
    public async void Repository_GetAllAsync_ShouldReturnList()
    {
        //arrange
        //act
        var result = _unitOfWork.SmbConfiguration.GetAllAsync();
        //assert
        result.Should().NotBeNull();
    }
}