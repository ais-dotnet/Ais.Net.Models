namespace Ais.Net.Models.Specs;

using System;

using Reqnroll;

using Shouldly;

[Binding]
public class AisMessageType24Part0StepDefinitions : StepDefinitionBase
{
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

        this.Message = new AisMessageType24Part0(
            Mmsi: this.data.Mmsi,
            PartNumber: this.data.PartNumber,
            RepeatIndicator: this.data.RepeatIndicator,
            Spare160: this.data.Spare160
        );
    }

    [Then("the AisMessageType24Part0 properties should be set correctly")]
    public void ThenThePropertiesShouldBeSetCorrectly()
    {
        AisMessageType24Part0? sut = this.Message as AisMessageType24Part0;
        
        if (this.data is null)
        {
            throw new InvalidOperationException("Data is not set");
        }

        sut.ShouldNotBeNull();
        sut.Mmsi.ShouldBe(this.data.Mmsi);
        sut.PartNumber.ShouldBe(this.data.PartNumber);
        sut.RepeatIndicator.ShouldBe(this.data.RepeatIndicator);
        sut.Spare160.ShouldBe(this.data.Spare160);
    }

    private class AisMessageType24Part0Data
    {
        public uint Mmsi { get; set; }
        public uint PartNumber { get; set; }
        public uint RepeatIndicator { get; set; }
        public uint Spare160 { get; set; }
    }
}