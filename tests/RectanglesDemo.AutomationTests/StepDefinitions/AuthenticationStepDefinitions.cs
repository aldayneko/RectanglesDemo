using RectanglesDemo.AutomationTests.Models;
using Refit;
using System;
using System.Text;
using TechTalk.SpecFlow;

namespace RectanglesDemo.AutomationTests.StepDefinitions
{
    [Binding]
    public class AuthenticationStepDefinitions
    {
        static readonly HttpClient client = new HttpClient();
        private string authenticationData = string.Empty;
        private IApiResponse? Response;

        [Given(@"\[I provided no authentication data]")]
        public void GivenIProvidedNoAuthenticationData()
        {
            authenticationData = string.Empty;
        }

        [When(@"\[Search endpoint is called]")]
        public async void WhenSearchEndpointIsCalled()
        {
            var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(authenticationData));
            var baseAddress = "http://localhost:8080/";

            var refitSettings = new RefitSettings()
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(authHeader)
            };

            var myApi = RestService.For<IRectanglesDemoApi>(baseAddress, refitSettings);

            Response = await myApi.Search(new[] { new Point() { X = 10, Y = 20 } } );
            
        }

        [Then(@"\[response is (.*)]")]
        public void ThenResponseIs(int p0)
        {
            if (Response == null) 
            {
                Assert.Fail();
            }

            Assert.IsTrue((int)Response!.StatusCode == p0);
        }

        [Given(@"\[I provided wrong authentication data]")]
        public void GivenIProvidedWrongAuthenticationData()
        {
            authenticationData = "admin:admin111";
        }

        [Given(@"\[I provided valid authentication data]")]
        public void GivenIProvidedValidAuthenticationData()
        {
            authenticationData = "admin:123admin111";
        }
    }
}
