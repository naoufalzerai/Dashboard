using System.Collections.Generic;
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
    public async void RepositorySmbConfiguration_Remove_ShouldRemove()
    {
        //arrange
        SmbConfiguration parameters = new Fixture().Create<SmbConfiguration>();
        //act
        await _unitOfWork.SmbConfiguration.AddAsync(parameters);
        SmbConfiguration afterInsert = _unitOfWork.SmbConfiguration.GetByIdAsync(parameters.Id);
        _unitOfWork.SmbConfiguration.Remove(parameters);
        SmbConfiguration afterRemove = _unitOfWork.SmbConfiguration.GetByIdAsync(parameters.Id);
        //assert
        afterInsert.Should().NotBeNull();
        afterRemove.Should().BeNull();
    }
    
    [Fact]
    public async void RepositorySmbConfiguration_AddAsync_ShouldInsert()
    {
        //arrange
        SmbConfiguration parameters = new Fixture().Create<SmbConfiguration>();
        //act
        await _unitOfWork.SmbConfiguration.AddAsync(parameters);
        //assert
    }
    [Fact]
    public async void RepositoryCronConfiguration_AddAsync_ShouldInsert()
    {
        //arrange
        CronConfiguration parameters = new Fixture().Create<CronConfiguration>();
        //act
        await _unitOfWork.CronConfiguration.AddAsync(parameters);
        //assert
    }
    [Fact]
    public async void RepositorySmbConfiguration_GetAllAsync_ShouldReturnList()
    {
        //arrange
        //act
        var result = await _unitOfWork.SmbConfiguration.GetAllAsync();
        //assert
        result.Should().NotBeNull();
    }
    
    [Fact]
    public async void RepositoryCronConfiguration_GetAllAsync_ShouldReturnList()
    {
        //arrange
        //act
        var result = _unitOfWork.CronConfiguration.GetAllAsync();
        //assert
        result.Should().NotBeNull();
    }
}