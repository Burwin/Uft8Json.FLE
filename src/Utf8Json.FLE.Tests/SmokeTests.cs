using Shouldly;
using System.Text;
using Utf8Json.Resolvers;
using Xunit;

namespace Utf8Json.FLE.Tests
{
    public class SmokeTests
    {
        [Fact]
        public void Simple_fully_encrypted_class()
        {
            var instance = new FullyEncryptedFoo() { MyDecimal = 1.234m, MyInt = 75, MyString = "Unencrypted" };

            var resolver = Helpers.GetEncryptedResolver(StandardResolver.AllowPrivate);

            var bytes = JsonSerializer.Serialize(instance, resolver);
            var json = Encoding.UTF8.GetString(bytes);
            json.ShouldNotContain(instance.MyString);
            json.ShouldNotContain("\"MyInt\":75");
            json.ShouldNotContain("\"MyDecimal\":1.234");

            var deserialized = JsonSerializer.Deserialize<FullyEncryptedFoo>(json, resolver);

            deserialized.MyDecimal.ShouldBe(instance.MyDecimal);
            deserialized.MyInt.ShouldBe(instance.MyInt);
            deserialized.MyString.ShouldBe(instance.MyString);
        }

        internal class FullyEncryptedFoo
        {
            [Encrypt]
            public int MyInt { get; set; }

            [Encrypt]
            public string MyString { get; set; }

            [Encrypt]
            public decimal MyDecimal { get; set; }
        }

        [Fact]
        public void Simple_unencrypted_class()
        {
            var instance = new NonEncryptedFoo() { MyDecimal = 1.234m, MyInt = 75, MyString = "Unencrypted" };

            var resolver = Helpers.GetEncryptedResolver(StandardResolver.AllowPrivate);

            var bytes = JsonSerializer.Serialize(instance, resolver);
            var json = Encoding.UTF8.GetString(bytes);
            json.ShouldContain(instance.MyString);
            json.ShouldContain("\"MyInt\":75");
            json.ShouldContain("\"MyDecimal\":1.234");

            var deserialized = JsonSerializer.Deserialize<NonEncryptedFoo>(json, resolver);

            deserialized.MyDecimal.ShouldBe(instance.MyDecimal);
            deserialized.MyInt.ShouldBe(instance.MyInt);
            deserialized.MyString.ShouldBe(instance.MyString);
        }

        class NonEncryptedFoo
        {
            public int MyInt { get; set; }
            public string MyString { get; set; }
            public decimal MyDecimal { get; set; }
        }


        [Fact]
        public void Simple_partially_encrypted_class()
        {
            var instance = new PartiallyEncryptedFoo() { MyInt = 75, MyString = "Unencrypted" };

            var resolver = Helpers.GetEncryptedResolver(StandardResolver.AllowPrivate);

            var bytes = JsonSerializer.Serialize(instance, resolver);
            var json = Encoding.UTF8.GetString(bytes);
            json.ShouldNotContain(instance.MyString);
            json.ShouldContain("\"MyInt\":75");

            var deserialized = JsonSerializer.Deserialize<PartiallyEncryptedFoo>(json, resolver);

            deserialized.MyInt.ShouldBe(instance.MyInt);
            deserialized.MyString.ShouldBe(instance.MyString);
        }

        class PartiallyEncryptedFoo
        {
            public int MyInt { get; set; }

            [Encrypt]
            public string MyString { get; set; }
        }
    }
}
