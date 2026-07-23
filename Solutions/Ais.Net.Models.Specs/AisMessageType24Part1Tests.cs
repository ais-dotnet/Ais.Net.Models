namespace Ais.Net.Models.Specs;

using Ais.Net.Models;
using Ais.Net.Models.Abstractions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class AisMessageType24Part1Tests
{
    [TestMethod]
    public void StaticDataReportPartBExposesSuppliedValues()
    {
        AisMessageType24Part1 message = new(
            CallSign: "CALL",
            DimensionToBow: 1,
            DimensionToPort: 2,
            DimensionToStarboard: 3,
            DimensionToStern: 4,
            Mmsi: 12345,
            MothershipMmsi: 54321,
            PartNumber: 1,
            RepeatIndicator: 3,
            SerialNumber: 123,
            Spare162: 1,
            ShipType: (ShipType)60,
            UnitModelCode: 1,
            VendorIdRev3: "VEN",
            VendorIdRev4: "DOR");

        message.MessageType.ShouldBe(24);       // both parts of a type 24 report share message type 24
        message.CallSign.ShouldBe("CALL");
        message.DimensionToBow.ShouldBe(1u);
        message.DimensionToPort.ShouldBe(2u);
        message.DimensionToStarboard.ShouldBe(3u);
        message.DimensionToStern.ShouldBe(4u);
        message.Mmsi.ShouldBe(12345u);
        message.MothershipMmsi.ShouldBe(54321u);
        message.PartNumber.ShouldBe(1u);
        message.RepeatIndicator.ShouldBe(3u);
        message.SerialNumber.ShouldBe(123u);
        message.Spare162.ShouldBe(1u);
        message.ShipType.ShouldBe((ShipType)60);
        message.UnitModelCode.ShouldBe(1u);
        message.VendorIdRev3.ShouldBe("VEN");
        message.VendorIdRev4.ShouldBe("DOR");
    }
}
