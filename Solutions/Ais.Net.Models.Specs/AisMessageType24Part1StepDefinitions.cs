namespace Ais.Net.Models.Specs;

using Abstractions;
using System;
using Reqnroll;
using Shouldly;

[Binding]
public class AisMessageType24Part1StepDefinitions
{
    private AisMessageType24Part1? sut;
    private AisMessageType24Part1Data? data;

    [Given("a new AisMessageType24Part1 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        this.data = table.CreateInstance<AisMessageType24Part1Data>();
    }

    [When("the AisMessageType24Part1 is created")]
    public void WhenTheAisMessageTypeIsCreated()
    {
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        this.sut = new AisMessageType24Part1(
            CallSign: this.data.CallSign ?? throw new InvalidOperationException(),
            DimensionToBow: this.data.DimensionToBow,
            DimensionToPort: this.data.DimensionToPort,
            DimensionToStarboard: this.data.DimensionToStarboard,
            DimensionToStern: this.data.DimensionToStern,
            Mmsi: this.data.Mmsi,
            MothershipMmsi: this.data.MothershipMmsi,
            PartNumber: this.data.PartNumber,
            RepeatIndicator: this.data.RepeatIndicator,
            SerialNumber: this.data.SerialNumber,
            Spare162: this.data.Spare162,
            ShipType: (ShipType)this.data.ShipType,
            UnitModelCode: this.data.UnitModelCode,
            VendorIdRev3: this.data.VendorIdRev3 ?? throw new InvalidOperationException(),
            VendorIdRev4: this.data.VendorIdRev4 ?? throw new InvalidOperationException()
        );
    }

    [Then("the AisMessageType24Part1 properties should be set correctly")]
    public void ThenThePropertiesShouldBeSetCorrectly()
    {
        this.sut.ShouldNotBeNull();
        this.sut.CallSign.ShouldBe("CALL");
        this.sut.DimensionToBow.ShouldBe(1u);
        this.sut.DimensionToPort.ShouldBe(2u);
        this.sut.DimensionToStarboard.ShouldBe(3u);
        this.sut.DimensionToStern.ShouldBe(4u);
        this.sut.Mmsi.ShouldBe(12345u);
        this.sut.MothershipMmsi.ShouldBe(54321u);
        this.sut.PartNumber.ShouldBe(1u);
        this.sut.RepeatIndicator.ShouldBe(3u);
        this.sut.SerialNumber.ShouldBe(123u);
        this.sut.Spare162.ShouldBe(1u);
        ((int)this.sut.ShipType).ShouldBe(60);
        this.sut.UnitModelCode.ShouldBe(1u);
        this.sut.VendorIdRev3.ShouldBe("VEN");
        this.sut.VendorIdRev4.ShouldBe("DOR");
    }

    private class AisMessageType24Part1Data
    {
        public string? CallSign { get; set; }
        public uint DimensionToBow { get; set; }
        public uint DimensionToPort { get; set; }
        public uint DimensionToStarboard { get; set; }
        public uint DimensionToStern { get; set; }
        public uint Mmsi { get; set; }
        public uint MothershipMmsi { get; set; }
        public uint PartNumber { get; set; }
        public uint RepeatIndicator { get; set; }
        public uint SerialNumber { get; set; }
        public uint Spare162 { get; set; }
        public int ShipType { get; set; }
        public uint UnitModelCode { get; set; }
        public string? VendorIdRev3 { get; set; }
        public string? VendorIdRev4 { get; set; }
    }
}