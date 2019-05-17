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
        [Fact]
        public void When_input_have_Chars_unicode_below_32_ASCII_control_characters()
        {
            bool result = false;
            string console = "\"\\u0030\"";
            Assert.Equal(result, Program.IsValidJSONString(console));
        }
        [Fact]
        public void When_input_have_BACKSLASH_control_characters()
        {
            bool result = false;
            string console = "\\Test\"";
            Assert.Equal(result, Program.IsValidJSONString(console));
        }
        [Fact]
        public void When_input_have_middle_quatation_marks_control_characters()
        {
            bool result = false;
            string console = "\"Te\"st\""; 
            Assert.Equal(result, Program.IsValidJSONString(console));
        }
        [Fact]
        public void When_input_have_Unicode__special_chars__another_line_control_characters()
        {
            bool result = true;
            string console = "\"Test\\\\u0097\\nAnother line\"";;
            Assert.Equal(result, Program.IsValidJSONString(console));
        }

    }
}
