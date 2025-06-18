using Reqnroll;

namespace Ais.Net.Models.Specs
{
    [Binding]
    public class CommonStepDefinitions
    {
        [Given(@"I have an AIS message")]
        public void GivenIHaveAnAisMessage()
        {
            // This is a common background step that does nothing
            // The actual message creation happens in the specific "Given" steps
        }
    }
}