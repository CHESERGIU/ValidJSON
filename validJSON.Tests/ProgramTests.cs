using System;
using ValidJSON;
using Xunit;

namespace validJSON.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void First_Green_Tests()
        {
            bool result = false;
            string console = "Text";            
            Assert.Equal(result, Program.IsValidJSONString(console));
        }
        [Fact]
        public void When_input_is_a_Simple_JSON_String()
        {
            bool result = true;
            string console = "\"Text\"";
            Assert.Equal(result, Program.IsValidJSONString(console));
        }
        
    }
}
