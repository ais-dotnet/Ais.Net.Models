namespace Ais.Net.Models.Specs;

using Abstractions;
using System;

using Reqnroll;
using Shouldly;

[Binding]
public class AisMessageType5StepDefinitions
{
    private AisMessageType5? sut;
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

        this.sut = new AisMessageType5(
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
        this.sut.ShouldNotBeNull();
        this.sut.AisVersion.ShouldBe(1u);
        this.sut.CallSign.ShouldBe("CALL");
        this.sut.Destination.ShouldBe("DEST");
        this.sut.DimensionToBow.ShouldBe(1u);
        this.sut.DimensionToPort.ShouldBe(2u);
        this.sut.DimensionToStarboard.ShouldBe(3u);
        this.sut.DimensionToStern.ShouldBe(4u);
        this.sut.Draught10thMetres.ShouldBe(5u);
        this.sut.EtaDay.ShouldBe(6u);
        this.sut.EtaHour.ShouldBe(7u);
        this.sut.EtaMinute.ShouldBe(8u);
        this.sut.EtaMonth.ShouldBe(9u);
        this.sut.IsDteNotReady.ShouldBeTrue();
        this.sut.ImoNumber.ShouldBe(123u);
        this.sut.Mmsi.ShouldBe(12345u);
        this.sut.PositionFixType.ShouldBe(EpfdFixType.Gps);
        this.sut.RepeatIndicator.ShouldBe(3u);
        ((int)this.sut.ShipType).ShouldBe(60);
        this.sut.Spare423.ShouldBe(1u);
        this.sut.VesselName.ShouldBe("VESSEL");
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