using ReaderV2.Core;

namespace ReaderV2.Core.Tests;

public class CoreSmokeTests
{
    [Fact]
    public void MemoryScanner_CanBeConstructed()
    {
        var scanner = new MemoryScanner(nint.Zero);
        Assert.NotNull(scanner);
    }
}
