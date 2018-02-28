using System;
using Xunit;
using one.Controllers;

namespace one.test
{
    public class OneControllerTest
    {
        [Fact]
        public void Test1()
        {
            var ctrl = new ValuesController();
            Assert.NotNull(ctrl);
        }
    }
}
