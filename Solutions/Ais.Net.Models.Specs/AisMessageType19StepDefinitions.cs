namespace Ais.Net.Models.Specs;

using Abstractions;
using System;

using Reqnroll;
using Shouldly;

[Binding]
public class AisMessageType19StepDefinitions
{
    private AisMessageType19? sut;
    private AisMessageType19Data? data;

    [Given("a new AisMessageType19 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        PositionData position = new()
        {
            Latitude = Convert.ToInt32(table.Rows[0]["Position_Latitude"]),
            Longitude = Convert.ToInt32(table.Rows[0]["Position_Longitude"])
        };

        this.data = table.CreateInstance<AisMessageType19Data>();
        this.data.Position = position;
    }

    [When("the AisMessageType19 is created")]
    public void WhenTheAisMessageTypeIsCreated()
    {
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        this.sut = new AisMessageType19(
            CourseOverGround: this.data.CourseOverGround,
            DimensionToBow: this.data.DimensionToBow,
            DimensionToPort: this.data.DimensionToPort,
            DimensionToStarboard: this.data.DimensionToStarboard,
            DimensionToStern: this.data.DimensionToStern,
            IsAssigned: this.data.IsAssigned,
            IsDteNotReady: this.data.IsDteNotReady,
            Mmsi: this.data.Mmsi,
            Position: new Position(this.data.Position?.Latitude ?? 0, this.data.Position?.Longitude ?? 0),
            PositionAccuracy: this.data.PositionAccuracy,
            PositionFixType: Enum.Parse<EpfdFixType>(this.data.PositionFixType ?? throw new InvalidOperationException()),
            RaimFlag: this.data.RaimFlag,
            RegionalReserved139: this.data.RegionalReserved139,
            RegionalReserved38: this.data.RegionalReserved38,
            RepeatIndicator: this.data.RepeatIndicator,
            ShipName: this.data.ShipName ?? throw new InvalidOperationException(),
            ShipType: (ShipType)this.data.ShipType,
            Spare308: this.data.Spare308,
            SpeedOverGround: this.data.SpeedOverGround,
            TimeStampSecond: this.data.TimeStampSecond,
            TrueHeadingDegrees: this.data.TrueHeadingDegrees
        );
    }

    [Then("the AisMessageType19 properties should be set correctly")]
    public void ThenThePropertiesShouldBeSetCorrectly()
    {
        this.sut.ShouldNotBeNull();
        this.sut.CourseOverGround.ShouldBe(123.45f);
        this.sut.DimensionToBow.ShouldBe(1u);
        this.sut.DimensionToPort.ShouldBe(2u);
        this.sut.DimensionToStarboard.ShouldBe(3u);
        this.sut.DimensionToStern.ShouldBe(4u);
        this.sut.IsAssigned.ShouldBeTrue();
        this.sut.IsDteNotReady.ShouldBeTrue();
        this.sut.Mmsi.ShouldBe(12345u);
        this.sut.Position.ShouldBe(new Position(1.0, 2.0));
        this.sut.PositionAccuracy.ShouldBeTrue();
        this.sut.PositionFixType.ShouldBe(EpfdFixType.Gps);
        this.sut.RaimFlag.ShouldBeTrue();
        this.sut.RegionalReserved139.ShouldBe(1);
        this.sut.RegionalReserved38.ShouldBe(2);
        this.sut.RepeatIndicator.ShouldBe(3u);
        this.sut.ShipName.ShouldBe("SHIP");
        ((int)this.sut.ShipType).ShouldBe(60);
        this.sut.Spare308.ShouldBe(1u);
        this.sut.SpeedOverGround.ShouldBe(12.34f);
        this.sut.TimeStampSecond.ShouldBe(56u);
        this.sut.TrueHeadingDegrees.ShouldBe(78u);
    }

    private class AisMessageType19Data
    {
        public float? CourseOverGround { get; set; }
        public uint DimensionToBow { get; set; }
        public uint DimensionToPort { get; set; }
        public uint DimensionToStarboard { get; set; }
        public uint DimensionToStern { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsDteNotReady { get; set; }
        public uint Mmsi { get; set; }
        public PositionData? Position { get; set; }
        public bool PositionAccuracy { get; set; }
        public string? PositionFixType { get; set; }
        public bool RaimFlag { get; set; }
        public int RegionalReserved139 { get; set; }
        public int RegionalReserved38 { get; set; }
        public uint RepeatIndicator { get; set; }
        public string? ShipName { get; set; }
        public int ShipType { get; set; }
        public uint Spare308 { get; set; }
        public float? SpeedOverGround { get; set; }
        public uint TimeStampSecond { get; set; }
        public uint TrueHeadingDegrees { get; set; }
    }

    private class PositionData
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
    }
}