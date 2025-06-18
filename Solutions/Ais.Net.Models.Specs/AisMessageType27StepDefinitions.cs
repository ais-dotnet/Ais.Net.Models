namespace Ais.Net.Models.Specs;

using System;

using Abstractions;

using Reqnroll;

using Shouldly;

[Binding]
public class AisMessageType27StepDefinitions : StepDefinitionBase
{
    private AisMessageType27Data? data;

    [Given("a new AisMessageType27 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        PositionData position = new()
        {
            Latitude = Convert.ToDouble(table.Rows[0]["Position_Latitude"]),
            Longitude = Convert.ToDouble(table.Rows[0]["Position_Longitude"])
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

        this.Message = new AisMessageType27(
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
        AisMessageType27? sut = this.Message as AisMessageType27;
        
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        sut.ShouldNotBeNull();
        sut.CourseOverGround.ShouldBe(this.data.CourseOverGround);
        sut.GnssPositionStatus.ShouldBe(this.data.GnssPositionStatus);
        sut.Mmsi.ShouldBe(this.data.Mmsi);
        sut.NavigationStatus.ShouldBe(Enum.Parse<NavigationStatus>(this.data.NavigationStatus ?? throw new InvalidOperationException()));
        sut.Position.ShouldBe(new Position(this.data.Position?.Latitude ?? 0, this.data.Position?.Longitude ?? 0));
        sut.PositionAccuracy.ShouldBe(this.data.PositionAccuracy);
        sut.RaimFlag.ShouldBe(this.data.RaimFlag);
        sut.RepeatIndicator.ShouldBe(this.data.RepeatIndicator);
        sut.SpeedOverGround.ShouldBe(this.data.SpeedOverGround);
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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}