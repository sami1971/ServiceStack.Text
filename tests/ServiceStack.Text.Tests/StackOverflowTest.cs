using System;
using NUnit.Framework;

namespace ServiceStack.Text.Tests
{
    public class FooDto {
        public string Foo { get; set; }
    }

    [TestFixture]
    public class StackOverflowTest
    {
        [Test]
        public void InvalidJson()
        {
            var str = "{ \"foo\" = \"bar\" }";

            var d = JsonSerializer.DeserializeFromString<FooDto> (str);

            Assert.AreEqual (d.Foo, "bar");
        }

        [Test]
        public void Invalid()
        {
            var str = "{ \"foo\" xxx \"bar\" }";

            JsConfig.ThrowOnDeserializationError = true;
            Console.WriteLine (JsConfig.EscapeUnicode = true);

            var d = JsonSerializer.DeserializeFromString<FooDto> (str);

            Assert.AreEqual ("bar", d.Foo);
        }
    }
}

