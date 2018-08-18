using Xunit;

namespace GooglePlacesApi.Tests.Helpers
{
    public class IntegrationTestOnlyFactAttribute : FactAttribute
    {
        #if !INTEGRATIONTEST
        public IntegrationTestOnlyFactAttribute() 
        {
            Skip = "Ignored when not running integration tests";   
        }
        #endif
    }
}
