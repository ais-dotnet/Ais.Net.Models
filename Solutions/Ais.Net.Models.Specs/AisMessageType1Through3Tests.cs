namespace Ais.Net.Models.Specs;

using Ais.Net.Models;
using Ais.Net.Models.Abstractions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class AisMessageType1Through3Tests
{
    [TestMethod]
    [DataRow(123.45f, NavigationStatus.UnderwayUsingEngine, 12345u, 1.0, 2.0, 12.34f)]
    [DataRow(234.56f, NavigationStatus.AtAnchor, 54321u, 3.0, 4.0, 0.0f)]
    public void ClassAVesselPositionReportExposesSuppliedValues(
        float courseOverGround,
        NavigationStatus navigationStatus,
        uint mmsi,
        double latitude,
        double longitude,
        float speedOverGround)
    {
        AisMessageType1Through3 message = new(
            CourseOverGround: courseOverGround,
            ManoeuvreIndicator: ManoeuvreIndicator.NotAvailable,
            MessageType: 1,
            Mmsi: mmsi,
            NavigationStatus: navigationStatus,
            Position: new Position(latitude, longitude),
            PositionAccuracy: true,
            RadioSlotTimeout: 1,
            RadioSubMessage: 2,
            RadioSyncState: RadioSyncState.UtcDirect,
            RateOfTurn: 1,
            RaimFlag: true,
            RepeatIndicator: 3,
            SpareBits145: 4,
            SpeedOverGround: speedOverGround,
            TimeStampSecond: 56,
            TrueHeadingDegrees: 78);

        message.CourseOverGround.ShouldBe(courseOverGround);
        message.ManoeuvreIndicator.ShouldBe(ManoeuvreIndicator.NotAvailable);
        message.MessageType.ShouldBe(1);
        message.Mmsi.ShouldBe(mmsi);
        message.NavigationStatus.ShouldBe(navigationStatus);
        message.Position.ShouldBe(new Position(latitude, longitude));
        message.PositionAccuracy.ShouldBe(true);
        message.RadioSlotTimeout.ShouldBe(1u);
        message.RadioSubMessage.ShouldBe(2u);
        message.RadioSyncState.ShouldBe(RadioSyncState.UtcDirect);
        message.RateOfTurn.ShouldBe(1);
        message.RaimFlag.ShouldBe(true);
        message.RepeatIndicator.ShouldBe(3u);
        message.SpareBits145.ShouldBe(4u);
        message.SpeedOverGround.ShouldBe(speedOverGround);
        message.TimeStampSecond.ShouldBe(56u);
        message.TrueHeadingDegrees.ShouldBe(78u);
    }
}
