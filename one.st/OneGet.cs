using System;
//using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace One.SystemTests
{
    public class OneGet
    {
        [Fact]
        public async Task ReturnsAll()
        {
            var baseurl = Environment.GetEnvironmentVariable("baseurl");
            if (String.IsNullOrWhiteSpace(baseurl)) 
            {
                baseurl = "http://localhost";
            }
            Console.WriteLine("baseurl = " + baseurl);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("/api/values");
            Assert.True(response.IsSuccessStatusCode, "Failed to call service.");

            string[] values = await response.Content.ReadAsAsync<string[]>();
            Assert.NotNull(values);
            Assert.NotEmpty(values);
            Assert.Equal(new string[] {"value1", "value2"}, values);
        }
    }
}
