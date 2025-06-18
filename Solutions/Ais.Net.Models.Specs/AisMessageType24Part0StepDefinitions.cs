namespace Ais.Net.Models.Specs;

using System;
using Reqnroll;
using Shouldly;

[Binding]
public class AisMessageType24Part0StepDefinitions
{
    private AisMessageType24Part0? sut;
    private AisMessageType24Part0Data? data;

    [Given("a new AisMessageType24Part0 record with the following properties:")]
    public void GivenANewAisMessageTypeRecordWithTheFollowingProperties(DataTable table)
    {
        this.data = table.CreateInstance<AisMessageType24Part0Data>();
    }

    [When("the AisMessageType24Part0 is created")]
    public void WhenTheAisMessageTypeIsCreated()
    {
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        this.sut = new AisMessageType24Part0(
            Mmsi: this.data.Mmsi,
            PartNumber: this.data.PartNumber,
            RepeatIndicator: this.data.RepeatIndicator,
            Spare160: this.data.Spare160
        );
    }

    [Then("the AisMessageType24Part0 properties should be set correctly")]
    public void ThenThePropertiesShouldBeSetCorrectly()
    {
        this.sut.ShouldNotBeNull();
        this.sut.Mmsi.ShouldBe(12345u);
        this.sut.PartNumber.ShouldBe(0u);
        this.sut.RepeatIndicator.ShouldBe(3u);
        this.sut.Spare160.ShouldBe(1u);
    }

    private class AisMessageType24Part0Data
    {
        public uint Mmsi { get; set; }
        public uint PartNumber { get; set; }
        public uint RepeatIndicator { get; set; }
        public uint Spare160 { get; set; }
    }
}