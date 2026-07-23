namespace Ais.Net.Models.Specs;

using Ais.Net.Models;
using Ais.Net.Models.Abstractions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class AisMessageType27Tests
{
    [TestMethod]
    public void LongRangeAisBroadcastMessageExposesSuppliedValues()
    {
        AisMessageType27 message = new(
            CourseOverGround: 123.45f,
            GnssPositionStatus: true,
            Mmsi: 12345,
            NavigationStatus: NavigationStatus.UnderwayUsingEngine,
            Position: new Position(1.0, 2.0),
            PositionAccuracy: true,
            RaimFlag: true,
            RepeatIndicator: 3,
            SpeedOverGround: 12.34f);

        message.MessageType.ShouldBe(27);
        message.CourseOverGround.ShouldBe(123.45f);
        message.GnssPositionStatus.ShouldBe(true);
        message.Mmsi.ShouldBe(12345u);
        message.NavigationStatus.ShouldBe(NavigationStatus.UnderwayUsingEngine);
        message.Position.ShouldBe(new Position(1.0, 2.0));
        message.PositionAccuracy.ShouldBe(true);
        message.RaimFlag.ShouldBe(true);
        message.RepeatIndicator.ShouldBe(3u);
        message.SpeedOverGround.ShouldBe(12.34f);
    }
}
