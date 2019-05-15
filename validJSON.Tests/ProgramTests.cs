using System;
using ValidJSON;
using Xunit;

namespace validJSON.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Red_Tests()
        {
            var result = "Valid";
            char[] jsonString = null;
            Program.IsValidJSONString(jsonString);
            Assert.Equal(result, jsonString);
        }
    }
}
