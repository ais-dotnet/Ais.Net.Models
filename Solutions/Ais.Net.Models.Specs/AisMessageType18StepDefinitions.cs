namespace Ais.Net.Models.Specs;

using System;

using Abstractions;

using Reqnroll;

using Shouldly;

[Binding]
public class AisMessageType18StepDefinitions : StepDefinitionBase
{
    private AisMessageType18Data? data;

    [Given("a new AisMessageType18 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        PositionData position = new()
        {
            Latitude = Convert.ToDouble(table.Rows[0]["Position_Latitude"]),
            Longitude = Convert.ToDouble(table.Rows[0]["Position_Longitude"])
        };

        this.data = table.CreateInstance<AisMessageType18Data>();
        this.data.Position = position;
    }

    [When("the AisMessageType is created")]
    public void WhenTheAisMessageTypeIsCreated()
    {
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        this.Message = new AisMessageType18(
            CanAcceptMessage22ChannelAssignment: this.data.CanAcceptMessage22ChannelAssignment,
            CanSwitchBands: this.data.CanSwitchBands,
            CourseOverGround: this.data.CourseOverGroundDegrees,
            CsUnit: Enum.Parse<ClassBUnit>(this.data.CsUnit ?? throw new InvalidOperationException()),
            HasDisplay: this.data.HasDisplay,
            IsAssigned: this.data.IsAssigned,
            IsDscAttached: this.data.IsDscAttached,
            Mmsi: this.data.Mmsi,
            Position: new Position(this.data.Position?.Latitude ?? 0, this.data.Position?.Longitude ?? 0),
            PositionAccuracy: this.data.PositionAccuracy,
            RadioStatusType: Enum.Parse<ClassBRadioStatusType>(this.data.RadioStatusType ?? throw new InvalidOperationException()),
            RaimFlag: this.data.RaimFlag,
            RegionalReserved139: this.data.RegionalReserved139,
            RegionalReserved38: this.data.RegionalReserved38,
            RepeatIndicator: this.data.RepeatIndicator,
            SpeedOverGround: this.data.SpeedOverGround,
            TimeStampSecond: this.data.TimeStampSecond,
            TrueHeadingDegrees: this.data.TrueHeadingDegrees
        );
    }

    [Then("the properties should be set correctly")]
    public void ThenThePropertiesShouldBeSetCorrectly()
    {
        var sut = (AisMessageType18?)this.Message;
        sut.ShouldNotBeNull();
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }
        sut.CanAcceptMessage22ChannelAssignment.ShouldBe(this.data.CanAcceptMessage22ChannelAssignment);
        sut.CanSwitchBands.ShouldBe(this.data.CanSwitchBands);
        sut.CourseOverGround.ShouldBe(this.data.CourseOverGroundDegrees);
        sut.CsUnit.ShouldBe(Enum.Parse<ClassBUnit>(this.data.CsUnit ?? throw new InvalidOperationException()));
        sut.HasDisplay.ShouldBe(this.data.HasDisplay);
        sut.IsAssigned.ShouldBe(this.data.IsAssigned);
        sut.IsDscAttached.ShouldBe(this.data.IsDscAttached);
        sut.Mmsi.ShouldBe(this.data.Mmsi);
        sut.Position.ShouldBe(new Position(this.data.Position?.Latitude ?? 0, this.data.Position?.Longitude ?? 0));
        sut.PositionAccuracy.ShouldBe(this.data.PositionAccuracy);
        sut.RadioStatusType.ShouldBe(Enum.Parse<ClassBRadioStatusType>(this.data.RadioStatusType ?? throw new InvalidOperationException()));
        sut.RaimFlag.ShouldBe(this.data.RaimFlag);
        sut.RegionalReserved139.ShouldBe(this.data.RegionalReserved139);
        sut.RegionalReserved38.ShouldBe(this.data.RegionalReserved38);
        sut.RepeatIndicator.ShouldBe(this.data.RepeatIndicator);
        sut.SpeedOverGround.ShouldBe(this.data.SpeedOverGround);
        sut.TimeStampSecond.ShouldBe(this.data.TimeStampSecond);
        sut.TrueHeadingDegrees.ShouldBe(this.data.TrueHeadingDegrees);
    }

    private class AisMessageType18Data
    {
        public bool CanAcceptMessage22ChannelAssignment { get; set; }
        public bool CanSwitchBands { get; set; }
        public float? CourseOverGroundDegrees { get; set; }
        public string? CsUnit { get; set; }
        public bool HasDisplay { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsDscAttached { get; set; }
        public uint Mmsi { get; set; }
        public PositionData? Position { get; set; }
        public bool PositionAccuracy { get; set; }
        public string? RadioStatusType { get; set; }
        public bool RaimFlag { get; set; }
        public int RegionalReserved139 { get; set; }
        public int RegionalReserved38 { get; set; }
        public uint RepeatIndicator { get; set; }
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