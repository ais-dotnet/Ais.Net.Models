namespace Ais.Net.Models.Specs;

using Ais.Net.Models;
using Ais.Net.Models.Abstractions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class AisMessageType19Tests
{
    [TestMethod]
    public void ClassBSoPositionReportExposesSuppliedValues()
    {
        AisMessageType19 message = new(
            CourseOverGround: 123.45f,
            DimensionToBow: 1,
            DimensionToPort: 2,
            DimensionToStarboard: 3,
            DimensionToStern: 4,
            IsAssigned: true,
            IsDteNotReady: true,
            Mmsi: 12345,
            Position: new Position(1.0, 2.0),
            PositionAccuracy: true,
            PositionFixType: EpfdFixType.Gps,
            RaimFlag: true,
            RegionalReserved139: 1,
            RegionalReserved38: 2,
            RepeatIndicator: 3,
            ShipName: "SHIP",
            ShipType: (ShipType)60,
            Spare308: 1,
            SpeedOverGround: 12.34f,
            TimeStampSecond: 56,
            TrueHeadingDegrees: 78);

        message.MessageType.ShouldBe(19);
        message.CourseOverGround.ShouldBe(123.45f);
        message.DimensionToBow.ShouldBe(1u);
        message.DimensionToPort.ShouldBe(2u);
        message.DimensionToStarboard.ShouldBe(3u);
        message.DimensionToStern.ShouldBe(4u);
        message.IsAssigned.ShouldBe(true);
        message.IsDteNotReady.ShouldBe(true);
        message.Mmsi.ShouldBe(12345u);
        message.Position.ShouldBe(new Position(1.0, 2.0));
        message.PositionAccuracy.ShouldBe(true);
        message.PositionFixType.ShouldBe(EpfdFixType.Gps);
        message.RaimFlag.ShouldBe(true);
        message.RegionalReserved139.ShouldBe(1);
        message.RegionalReserved38.ShouldBe(2);
        message.RepeatIndicator.ShouldBe(3u);
        message.ShipName.ShouldBe("SHIP");
        message.ShipType.ShouldBe((ShipType)60);
        message.Spare308.ShouldBe(1u);
        message.SpeedOverGround.ShouldBe(12.34f);
        message.TimeStampSecond.ShouldBe(56u);
        message.TrueHeadingDegrees.ShouldBe(78u);
    }
}
