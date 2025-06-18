namespace Ais.Net.Models.Specs;

using System;

using Reqnroll;

using Shouldly;

[Binding]
public class AisMessageType5StepDefinitions : StepDefinitionBase
{
    private AisMessageType5Data? data;

    [Given("a new AisMessageType5 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        this.data = table.CreateInstance<AisMessageType5Data>();
    }

    [When("the AisMessageType5 is created")]
    public void WhenTheAisMessageTypeIsCreated()
    {
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        this.Message = new AisMessageType5(
            AisVersion: this.data.AisVersion,
            CallSign: this.data.CallSign ?? throw new InvalidOperationException(),
            Destination: this.data.Destination ?? throw new InvalidOperationException(),
            DimensionToBow: this.data.DimensionToBow,
            DimensionToPort: this.data.DimensionToPort,
            DimensionToStarboard: this.data.DimensionToStarboard,
            DimensionToStern: this.data.DimensionToStern,
            Draught10thMetres: this.data.Draught10thMetres,
            EtaDay: this.data.EtaDay,
            EtaHour: this.data.EtaHour,
            EtaMinute: this.data.EtaMinute,
            EtaMonth: this.data.EtaMonth,
            IsDteNotReady: this.data.IsDteNotReady,
            ImoNumber: this.data.ImoNumber,
            Mmsi: this.data.Mmsi,
            PositionFixType: Enum.Parse<EpfdFixType>(this.data.PositionFixType ?? throw new InvalidOperationException()),
            RepeatIndicator: this.data.RepeatIndicator,
            ShipType: (ShipType)this.data.ShipType,
            Spare423: this.data.Spare423,
            VesselName: this.data.VesselName ?? throw new InvalidOperationException()
        );
    }

    [Then("the AisMessageType5 properties should be set correctly")]
    public void ThenThePropertiesShouldBeSetCorrectly()
    {
        AisMessageType5? sut = this.Message as AisMessageType5;
       
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        sut.ShouldNotBeNull();
        sut.AisVersion.ShouldBe(this.data.AisVersion);
        sut.CallSign.ShouldBe(this.data.CallSign);
        sut.Destination.ShouldBe(this.data.Destination);
        sut.DimensionToBow.ShouldBe(this.data.DimensionToBow);
        sut.DimensionToPort.ShouldBe(this.data.DimensionToPort);
        sut.DimensionToStarboard.ShouldBe(this.data.DimensionToStarboard);
        sut.DimensionToStern.ShouldBe(this.data.DimensionToStern);
        sut.Draught10thMetres.ShouldBe(this.data.Draught10thMetres);
        sut.EtaDay.ShouldBe(this.data.EtaDay);
        sut.EtaHour.ShouldBe(this.data.EtaHour);
        sut.EtaMinute.ShouldBe(this.data.EtaMinute);
        sut.EtaMonth.ShouldBe(this.data.EtaMonth);
        sut.IsDteNotReady.ShouldBe(this.data.IsDteNotReady);
        sut.ImoNumber.ShouldBe(this.data.ImoNumber);
        sut.Mmsi.ShouldBe(this.data.Mmsi);
        sut.PositionFixType.ShouldBe(Enum.Parse<EpfdFixType>(this.data.PositionFixType ?? throw new InvalidOperationException()));
        sut.RepeatIndicator.ShouldBe(this.data.RepeatIndicator);
        ((int)sut.ShipType).ShouldBe(this.data.ShipType);
        sut.Spare423.ShouldBe(this.data.Spare423);
        sut.VesselName.ShouldBe(this.data.VesselName);
    }

    private class AisMessageType5Data
    {
        public uint AisVersion { get; set; }
        public string? CallSign { get; set; }
        public string? Destination { get; set; }
        public uint DimensionToBow { get; set; }
        public uint DimensionToPort { get; set; }
        public uint DimensionToStarboard { get; set; }
        public uint DimensionToStern { get; set; }
        public uint Draught10thMetres { get; set; }
        public uint EtaDay { get; set; }
        public uint EtaHour { get; set; }
        public uint EtaMinute { get; set; }
        public uint EtaMonth { get; set; }
        public bool IsDteNotReady { get; set; }
        public uint ImoNumber { get; set; }
        public uint Mmsi { get; set; }
        public string? PositionFixType { get; set; }
        public uint RepeatIndicator { get; set; }
        public int ShipType { get; set; }
        public uint Spare423 { get; set; }
        public string? VesselName { get; set; }
    }
}