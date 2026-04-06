using System.Text;
using ReaderV2.Protocol;

namespace ReaderV2.Protocol.Tests;

public class MarkerParserTests
{
    [Fact]
    public void ParseFromBuffer_ParsesValidMarker()
    {
        const string marker =
            "##READER_DATA##|Arthok|70|Mage|SomeGuild|12500|15000|mana|8900|10000|1234.56|789.01|-45.23|Dragnoth|72|55|hostile|##END_READER##";

        byte[] buffer = Encoding.UTF8.GetBytes(marker);
        var snap = MarkerParser.ParseFromBuffer(buffer);

        Assert.NotNull(snap);
        Assert.Equal("Arthok", snap!.Player.Name);
        Assert.Equal(70, snap.Player.Level);
        Assert.Equal("Mage", snap.Player.Calling);
        Assert.Equal("SomeGuild", snap.Player.Guild);
        Assert.Equal(12500, snap.Stats.Hp);
        Assert.Equal(15000, snap.Stats.HpMax);
        Assert.Equal("mana", snap.Stats.ResourceKind);
        Assert.Equal(8900, snap.Stats.Resource);
        Assert.Equal(10000, snap.Stats.ResourceMax);
        Assert.Equal(1234.56f, snap.Position.X);
        Assert.Equal(789.01f, snap.Position.Y);
        Assert.Equal(-45.23f, snap.Position.Z);
        Assert.NotNull(snap.Target);
        Assert.Equal("Dragnoth", snap.Target!.Name);
        Assert.Equal(72, snap.Target.Level);
        Assert.Equal(55, snap.Target.HpPercent);
        Assert.Equal("hostile", snap.Target.Relation);
    }

    [Fact]
    public void ParseFromBuffer_ReturnsNullWhenMarkerMissing()
    {
        byte[] buffer = Encoding.UTF8.GetBytes("no marker here");
        var snap = MarkerParser.ParseFromBuffer(buffer);
        Assert.Null(snap);
    }
}
