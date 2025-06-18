namespace Ais.Net.Models.Specs;

using System;

using Abstractions;

using Reqnroll;

using Shouldly;

[Binding]
public class AisMessageType19StepDefinitions : StepDefinitionBase
{
    private AisMessageType19Data? data;

    [Given("a new AisMessageType19 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        PositionData position = new()
        {
            Latitude = Convert.ToDouble(table.Rows[0]["Position_Latitude"]),
            Longitude = Convert.ToDouble(table.Rows[0]["Position_Longitude"])
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

        this.Message = new AisMessageType19(
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
        var sut = (AisMessageType19?)this.Message;
        sut.ShouldNotBeNull();
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }
        sut.CourseOverGround.ShouldBe(this.data.CourseOverGround);
        sut.DimensionToBow.ShouldBe(this.data.DimensionToBow);
        sut.DimensionToPort.ShouldBe(this.data.DimensionToPort);
        sut.DimensionToStarboard.ShouldBe(this.data.DimensionToStarboard);
        sut.DimensionToStern.ShouldBe(this.data.DimensionToStern);
        sut.IsAssigned.ShouldBe(this.data.IsAssigned);
        sut.IsDteNotReady.ShouldBe(this.data.IsDteNotReady);
        sut.Mmsi.ShouldBe(this.data.Mmsi);
        sut.Position.ShouldBe(new Position(this.data.Position?.Latitude ?? 0, this.data.Position?.Longitude ?? 0));
        sut.PositionAccuracy.ShouldBe(this.data.PositionAccuracy);
        sut.PositionFixType.ShouldBe(Enum.Parse<EpfdFixType>(this.data.PositionFixType ?? throw new InvalidOperationException()));
        sut.RaimFlag.ShouldBe(this.data.RaimFlag);
        sut.RegionalReserved139.ShouldBe(this.data.RegionalReserved139);
        sut.RegionalReserved38.ShouldBe(this.data.RegionalReserved38);
        sut.RepeatIndicator.ShouldBe(this.data.RepeatIndicator);
        sut.ShipName.ShouldBe(this.data.ShipName);
        ((int)sut.ShipType).ShouldBe(this.data.ShipType);
        sut.Spare308.ShouldBe(this.data.Spare308);
        sut.SpeedOverGround.ShouldBe(this.data.SpeedOverGround);
        sut.TimeStampSecond.ShouldBe(this.data.TimeStampSecond);
        sut.TrueHeadingDegrees.ShouldBe(this.data.TrueHeadingDegrees);
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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}