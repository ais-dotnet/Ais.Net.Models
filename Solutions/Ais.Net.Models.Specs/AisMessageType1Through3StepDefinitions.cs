namespace Ais.Net.Models.Specs;

using System;

using Abstractions;

using Reqnroll;

using Shouldly;

[Binding]
public class AisMessageType1Through3StepDefinitions : StepDefinitionBase
{
    private AisMessageType1Through3Data? data;

    [Given("a new AisMessageType1Through3 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        PositionData position = new()
        {
            Latitude = Convert.ToDouble(table.Rows[0]["Position_Latitude"]),
            Longitude = Convert.ToDouble(table.Rows[0]["Position_Longitude"])
        };

        this.data = table.CreateInstance<AisMessageType1Through3Data>();
        this.data.Position = position;
    }

    [When("the AisMessageType1Through3 is created")]
    public void WhenTheAisMessageTypeIsCreated()
    {
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        this.Message = new AisMessageType1Through3(
            CourseOverGround: this.data.CourseOverGround,
            ManoeuvreIndicator: Enum.Parse<ManoeuvreIndicator>(this.data.ManoeuvreIndicator ?? throw new InvalidOperationException()),
            MessageType: this.data.MessageType,
            Mmsi: this.data.Mmsi,
            NavigationStatus: Enum.Parse<NavigationStatus>(this.data.NavigationStatus ?? throw new InvalidOperationException()),
            Position: new Position(this.data.Position?.Latitude ?? 0, this.data.Position?.Longitude ?? 0),
            PositionAccuracy: this.data.PositionAccuracy,
            RadioSlotTimeout: this.data.RadioSlotTimeout,
            RadioSubMessage: this.data.RadioSubMessage,
            RadioSyncState: Enum.Parse<RadioSyncState>(this.data.RadioSyncState ?? throw new InvalidOperationException()),
            RateOfTurn: this.data.RateOfTurn,
            RaimFlag: this.data.RaimFlag,
            RepeatIndicator: this.data.RepeatIndicator,
            SpareBits145: this.data.SpareBits145,
            SpeedOverGround: this.data.SpeedOverGround,
            TimeStampSecond: this.data.TimeStampSecond,
            TrueHeadingDegrees: this.data.TrueHeadingDegrees
        );
    }

    [Then("the AisMessageType1Through3 properties should be set correctly")]
    public void ThenThePropertiesShouldBeSetCorrectly()
    {
        var sut = (AisMessageType1Through3?)this.Message;
        sut.ShouldNotBeNull();
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }
        sut.CourseOverGround.ShouldBe(this.data.CourseOverGround);
        sut.ManoeuvreIndicator.ShouldBe(Enum.Parse<ManoeuvreIndicator>(this.data.ManoeuvreIndicator ?? throw new InvalidOperationException()));
        sut.MessageType.ShouldBe(this.data.MessageType);
        sut.Mmsi.ShouldBe(this.data.Mmsi);
        sut.NavigationStatus.ShouldBe(Enum.Parse<NavigationStatus>(this.data.NavigationStatus ?? throw new InvalidOperationException()));
        sut.Position.ShouldBe(new Position(this.data.Position?.Latitude ?? 0, this.data.Position?.Longitude ?? 0));
        sut.PositionAccuracy.ShouldBe(this.data.PositionAccuracy);
        sut.RadioSlotTimeout.ShouldBe(this.data.RadioSlotTimeout);
        sut.RadioSubMessage.ShouldBe(this.data.RadioSubMessage);
        sut.RadioSyncState.ShouldBe(Enum.Parse<RadioSyncState>(this.data.RadioSyncState ?? throw new InvalidOperationException()));
        sut.RateOfTurn.ShouldBe(this.data.RateOfTurn);
        sut.RaimFlag.ShouldBe(this.data.RaimFlag);
        sut.RepeatIndicator.ShouldBe(this.data.RepeatIndicator);
        sut.SpareBits145.ShouldBe(this.data.SpareBits145);
        sut.SpeedOverGround.ShouldBe(this.data.SpeedOverGround);
        sut.TimeStampSecond.ShouldBe(this.data.TimeStampSecond);
        sut.TrueHeadingDegrees.ShouldBe(this.data.TrueHeadingDegrees);
    }

    private class AisMessageType1Through3Data
    {
        public float? CourseOverGround { get; set; }
        public string? ManoeuvreIndicator { get; set; }
        public int MessageType { get; set; }
        public uint Mmsi { get; set; }
        public string? NavigationStatus { get; set; }
        public PositionData? Position { get; set; }
        public bool PositionAccuracy { get; set; }
        public uint RadioSlotTimeout { get; set; }
        public uint RadioSubMessage { get; set; }
        public string? RadioSyncState { get; set; }
        public int RateOfTurn { get; set; }
        public bool RaimFlag { get; set; }
        public uint RepeatIndicator { get; set; }
        public uint SpareBits145 { get; set; }
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