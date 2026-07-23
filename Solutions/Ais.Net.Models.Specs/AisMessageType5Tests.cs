namespace Ais.Net.Models.Specs;

using Ais.Net.Models;
using Ais.Net.Models.Abstractions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class AisMessageType5Tests
{
    [TestMethod]
    public void StaticAndVoyageRelatedDataExposesSuppliedValues()
    {
        AisMessageType5 message = new(
            AisVersion: 1,
            CallSign: "CALL",
            Destination: "DEST",
            DimensionToBow: 1,
            DimensionToPort: 2,
            DimensionToStarboard: 3,
            DimensionToStern: 4,
            Draught10thMetres: 5,
            EtaDay: 6,
            EtaHour: 7,
            EtaMinute: 8,
            EtaMonth: 9,
            IsDteNotReady: true,
            ImoNumber: 123,
            Mmsi: 12345,
            PositionFixType: EpfdFixType.Gps,
            RepeatIndicator: 3,
            ShipType: (ShipType)60,
            Spare423: 1,
            VesselName: "VESSEL");

        message.MessageType.ShouldBe(5);
        message.AisVersion.ShouldBe(1u);
        message.CallSign.ShouldBe("CALL");
        message.Destination.ShouldBe("DEST");
        message.DimensionToBow.ShouldBe(1u);
        message.DimensionToPort.ShouldBe(2u);
        message.DimensionToStarboard.ShouldBe(3u);
        message.DimensionToStern.ShouldBe(4u);
        message.Draught10thMetres.ShouldBe(5u);
        message.EtaDay.ShouldBe(6u);
        message.EtaHour.ShouldBe(7u);
        message.EtaMinute.ShouldBe(8u);
        message.EtaMonth.ShouldBe(9u);
        message.IsDteNotReady.ShouldBe(true);
        message.ImoNumber.ShouldBe(123u);
        message.Mmsi.ShouldBe(12345u);
        message.PositionFixType.ShouldBe(EpfdFixType.Gps);
        message.RepeatIndicator.ShouldBe(3u);
        message.ShipType.ShouldBe((ShipType)60);
        message.Spare423.ShouldBe(1u);
        message.VesselName.ShouldBe("VESSEL");
    }
}
