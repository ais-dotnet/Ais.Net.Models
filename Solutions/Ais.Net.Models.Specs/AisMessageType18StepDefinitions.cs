namespace Ais.Net.Models.Specs;

using Abstractions;
using System;

using Reqnroll;
using Shouldly;

[Binding]
public class AisMessageType18StepDefinitions
{
    private AisMessageType18 sut;
    private AisMessageType18Data data;

    [Given("a new AisMessageType18 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        PositionData position = new()
        {
            Latitude = Convert.ToInt32(table.Rows[0]["Position_Latitude"]),
            Longitude = Convert.ToInt32(table.Rows[0]["Position_Longitude"])
        };

        this.data = table.CreateInstance<AisMessageType18Data>();
        this.data.Position = position;
    }

    [When("the AisMessageType is created")]
    public void WhenTheAisMessageTypeIsCreated()
    {
        this.sut = new AisMessageType18(
            CanAcceptMessage22ChannelAssignment: this.data.CanAcceptMessage22ChannelAssignment,
            CanSwitchBands: this.data.CanSwitchBands,
            CourseOverGroundDegrees: this.data.CourseOverGroundDegrees,
            CsUnit: Enum.Parse<ClassBUnit>(this.data.CsUnit),
            HasDisplay: this.data.HasDisplay,
            IsAssigned: this.data.IsAssigned,
            IsDscAttached: this.data.IsDscAttached,
            Mmsi: this.data.Mmsi,
            Position: new Position(this.data.Position.Latitude, this.data.Position.Longitude),
            PositionAccuracy: this.data.PositionAccuracy,
            RadioStatusType: Enum.Parse<ClassBRadioStatusType>(this.data.RadioStatusType),
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
        this.sut.ShouldNotBeNull();
        this.sut.CanAcceptMessage22ChannelAssignment.ShouldBeTrue();
        this.sut.CanSwitchBands.ShouldBeTrue();
        this.sut.CourseOverGroundDegrees.ShouldBe(123.45f);
        this.sut.CsUnit.ShouldBe(ClassBUnit.Cstdma);
        this.sut.HasDisplay.ShouldBeTrue();
        this.sut.IsAssigned.ShouldBeTrue();
        this.sut.IsDscAttached.ShouldBeTrue();
        this.sut.Mmsi.ShouldBe(12345u);
        this.sut.Position.ShouldBe(new Position(1.0, 2.0));
        this.sut.PositionAccuracy.ShouldBeTrue();
        this.sut.RadioStatusType.ShouldBe(ClassBRadioStatusType.Itdma);
        this.sut.RaimFlag.ShouldBeTrue();
        this.sut.RegionalReserved139.ShouldBe(1);
        this.sut.RegionalReserved38.ShouldBe(2);
        this.sut.RepeatIndicator.ShouldBe(3u);
        this.sut.SpeedOverGround.ShouldBe(12.34f);
        this.sut.TimeStampSecond.ShouldBe(56u);
        this.sut.TrueHeadingDegrees.ShouldBe(78u);
    }

    private class AisMessageType18Data
    {
        public bool CanAcceptMessage22ChannelAssignment { get; set; }
        public bool CanSwitchBands { get; set; }
        public float? CourseOverGroundDegrees { get; set; }
        public string CsUnit { get; set; }
        public bool HasDisplay { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsDscAttached { get; set; }
        public uint Mmsi { get; set; }
        public PositionData Position { get; set; }
        public bool PositionAccuracy { get; set; }
        public string RadioStatusType { get; set; }
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
        public int Latitude { get; set; }
        public int Longitude { get; set; }
    }
}