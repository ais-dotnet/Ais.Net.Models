namespace Ais.Net.Models.Specs;

using System;

using Reqnroll;

using Shouldly;

[Binding]
public class AisMessageType24Part1StepDefinitions : StepDefinitionBase
{
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

        this.Message = new AisMessageType24Part1(
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
        AisMessageType24Part1? sut = this.Message as AisMessageType24Part1;
        
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        sut.ShouldNotBeNull();
        sut.CallSign.ShouldBe(this.data.CallSign);
        sut.DimensionToBow.ShouldBe(this.data.DimensionToBow);
        sut.DimensionToPort.ShouldBe(this.data.DimensionToPort);
        sut.DimensionToStarboard.ShouldBe(this.data.DimensionToStarboard);
        sut.DimensionToStern.ShouldBe(this.data.DimensionToStern);
        sut.Mmsi.ShouldBe(this.data.Mmsi);
        sut.MothershipMmsi.ShouldBe(this.data.MothershipMmsi);
        sut.PartNumber.ShouldBe(this.data.PartNumber);
        sut.RepeatIndicator.ShouldBe(this.data.RepeatIndicator);
        sut.SerialNumber.ShouldBe(this.data.SerialNumber);
        sut.Spare162.ShouldBe(this.data.Spare162);
        ((int)sut.ShipType).ShouldBe(this.data.ShipType);
        sut.UnitModelCode.ShouldBe(this.data.UnitModelCode);
        sut.VendorIdRev3.ShouldBe(this.data.VendorIdRev3);
        sut.VendorIdRev4.ShouldBe(this.data.VendorIdRev4);
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