namespace Ais.Net.Models.Specs;

using Ais.Net.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class AisMessageType24Part0Tests
{
    [TestMethod]
    public void StaticDataReportPartAExposesSuppliedValues()
    {
        AisMessageType24Part0 message = new(
            Mmsi: 12345,
            PartNumber: 0,
            RepeatIndicator: 3,
            Spare160: 1);

        message.MessageType.ShouldBe(24);       // both parts of a type 24 report share message type 24
        message.Mmsi.ShouldBe(12345u);
        message.PartNumber.ShouldBe(0u);
        message.RepeatIndicator.ShouldBe(3u);
        message.Spare160.ShouldBe(1u);
    }
}
