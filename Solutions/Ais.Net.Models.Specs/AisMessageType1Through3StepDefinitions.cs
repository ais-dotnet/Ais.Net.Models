namespace Ais.Net.Models.Specs;

using Abstractions;
using System;

using Reqnroll;
using Shouldly;

[Binding]
public class AisMessageType1Through3StepDefinitions
{
    private AisMessageType1Through3? sut;
    private AisMessageType1Through3Data? data;

    [Given("a new AisMessageType1Through3 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        PositionData position = new()
        {
            Latitude = Convert.ToInt32(table.Rows[0]["Position_Latitude"]),
            Longitude = Convert.ToInt32(table.Rows[0]["Position_Longitude"])
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

        this.sut = new AisMessageType1Through3(
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
        this.sut.ShouldNotBeNull();
        this.sut.CourseOverGround.ShouldBe(123.45f);
        this.sut.ManoeuvreIndicator.ShouldBe(ManoeuvreIndicator.NotAvailable);
        this.sut.MessageType.ShouldBe(1);
        this.sut.Mmsi.ShouldBe(12345u);
        this.sut.NavigationStatus.ShouldBe(NavigationStatus.UnderwayUsingEngine);
        this.sut.Position.ShouldBe(new Position(1.0, 2.0));
        this.sut.PositionAccuracy.ShouldBeTrue();
        this.sut.RadioSlotTimeout.ShouldBe(1u);
        this.sut.RadioSubMessage.ShouldBe(2u);
        this.sut.RadioSyncState.ShouldBe(RadioSyncState.UtcDirect);
        this.sut.RateOfTurn.ShouldBe(1);
        this.sut.RaimFlag.ShouldBeTrue();
        this.sut.RepeatIndicator.ShouldBe(3u);
        this.sut.SpareBits145.ShouldBe(4u);
        this.sut.SpeedOverGround.ShouldBe(12.34f);
        this.sut.TimeStampSecond.ShouldBe(56u);
        this.sut.TrueHeadingDegrees.ShouldBe(78u);
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
        public int Latitude { get; set; }
        public int Longitude { get; set; }
    }
}