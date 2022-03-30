using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using BL.SMB;
using EzSmb;

namespace Test;

public class SmbUnitTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    public SmbUnitTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    [Fact]
    public async void GetFilesAsync_ShouldGetNodes()
    {
        Node[] files = await Smb.GetFilesAsync(@"\\meganas.local", "near", "wdwjfs2611");
        files.Should().NotBeEmpty();
    }
}