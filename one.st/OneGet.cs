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
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("http://localhost/api/values");
            Assert.True(response.IsSuccessStatusCode, "Failed to call service.");

            string[] values = await response.Content.ReadAsAsync<string[]>();
            Assert.NotNull(values);
            Assert.NotEmpty(values);
            Assert.Equal(new string[] {"value1", "value2"}, values);
        }
    }
}
