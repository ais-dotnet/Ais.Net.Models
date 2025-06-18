namespace Ais.Net.Models.Specs;

using Abstractions;
using System;

using Reqnroll;
using Shouldly;

[Binding]
public class AisMessageType27StepDefinitions
{
    private AisMessageType27? sut;
    private AisMessageType27Data? data;

    [Given("a new AisMessageType27 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        PositionData position = new()
        {
            Latitude = Convert.ToInt32(table.Rows[0]["Position_Latitude"]),
            Longitude = Convert.ToInt32(table.Rows[0]["Position_Longitude"])
        };

        this.data = table.CreateInstance<AisMessageType27Data>();
        this.data.Position = position;
    }

    [When("the AisMessageType27 is created")]
    public void WhenTheAisMessageTypeIsCreated()
    {
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        this.sut = new AisMessageType27(
            CourseOverGround: this.data.CourseOverGround,
            GnssPositionStatus: this.data.GnssPositionStatus,
            Mmsi: this.data.Mmsi,
            NavigationStatus: Enum.Parse<NavigationStatus>(this.data.NavigationStatus ?? throw new InvalidOperationException()),
            Position: new Position(this.data.Position?.Latitude ?? 0, this.data.Position?.Longitude ?? 0),
            PositionAccuracy: this.data.PositionAccuracy,
            RaimFlag: this.data.RaimFlag,
            RepeatIndicator: this.data.RepeatIndicator,
            SpeedOverGround: this.data.SpeedOverGround
        );
    }

    [Then("the AisMessageType27 properties should be set correctly")]
    public void ThenThePropertiesShouldBeSetCorrectly()
    {
        this.sut.ShouldNotBeNull();
        this.sut.CourseOverGround.ShouldBe(123.45f);
        this.sut.GnssPositionStatus.ShouldBeTrue();
        this.sut.Mmsi.ShouldBe(12345u);
        this.sut.NavigationStatus.ShouldBe(NavigationStatus.UnderwayUsingEngine);
        this.sut.Position.ShouldBe(new Position(1.0, 2.0));
        this.sut.PositionAccuracy.ShouldBeTrue();
        this.sut.RaimFlag.ShouldBeTrue();
        this.sut.RepeatIndicator.ShouldBe(3u);
        this.sut.SpeedOverGround.ShouldBe(12.34f);
    }

    private class AisMessageType27Data
    {
        public float? CourseOverGround { get; set; }
        public bool GnssPositionStatus { get; set; }
        public uint Mmsi { get; set; }
        public string? NavigationStatus { get; set; }
        public PositionData? Position { get; set; }
        public bool PositionAccuracy { get; set; }
        public bool RaimFlag { get; set; }
        public uint RepeatIndicator { get; set; }
        public float? SpeedOverGround { get; set; }
    }

    private class PositionData
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
    }
}