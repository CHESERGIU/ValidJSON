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
            bool result = true;
            string console = "Text";
            
            Assert.Equal(result, Program.IsValidJSONString(console));
        }
    }
}
