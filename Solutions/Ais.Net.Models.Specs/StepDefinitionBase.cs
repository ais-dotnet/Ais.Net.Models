using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models.Specs
{
    public class StepDefinitionBase
    {
        protected IAisMessage? Message { get; set; }
    }
}