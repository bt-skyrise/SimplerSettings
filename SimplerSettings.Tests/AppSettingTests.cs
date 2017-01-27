using System;
using FluentAssertions;
using NUnit.Framework;

namespace SimplerSettings.Tests
{
    public class AppSettingTests
    {   
        [TestCase("some-value", true)]
        [TestCase("", true)]
        [TestCase(null, false)]
        public void can_check_if_setting_is_set(string settingValue, bool expectedResult)
        {
            var setting = new AppSetting("Foo", settingValue);

            setting.IsSet.Should().Be(expectedResult);
        }

        [TestCase("some-value")]
        [TestCase(null)]
        public void can_always_get_setting_key(string settingValue)
        {
            var setting = new AppSetting("some-key", settingValue);

            setting.Key.Should().Be("some-key");
        }

        [Test]
        public void setting_key_cannot_be_null()
        {
            Action creatingSetting = () => new AppSetting(null, "some-value");

            creatingSetting.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void cannot_get_value_of_a_setting_when_its_not_set()
        {
            var setting = new AppSetting("Foo", null);

            setting.Key.Should().Be("Foo");

            Action gettingValue = () =>
            {
                var value = setting.Value;
            };

            gettingValue.ShouldThrow<InvalidOperationException>()
                .WithMessage("Foo setting is not set.");
        }

        [Test]
        public void can_get_setting_value_when_its_set()
        {
            var setting = new AppSetting("Foo", "Bar");

            setting.Key.Should().Be("Foo");
            setting.Value.Should().Be("Bar");
        }

        [Test]
        public void fails_when_value_is_not_valid_boolean()
        {
            var setting = new AppSetting("Foo", "not-bool");

            Action gettingBool = () => setting.AsBool();

            gettingBool.ShouldThrow<InvalidOperationException>()
                .WithMessage("Foo setting should be valid boolean, but was 'not-bool'.");
        }

        [TestCase("true", true)]
        [TestCase("false", false)]
        public void can_get_boolean_setting(string settingValue, bool expectedResult)
        {
            var setting = new AppSetting("Foo", settingValue);

            setting.AsBool().Should().Be(expectedResult);
        }

        [Test]
        public void fails_when_value_is_not_valid_integer()
        {
            var setting = new AppSetting("Foo", "not-int");

            Action gettingInt = () => setting.AsInt();

            gettingInt.ShouldThrow<InvalidOperationException>()
                .WithMessage("Foo setting should be valid integer, but was: 'not-int'.");
        }

        [TestCase("123", 123)]
        [TestCase("321", 321)]
        public void can_get_integer_setting(string settingValue, int expectedResult)
        {
            var setting = new AppSetting("Foo", settingValue);

            setting.AsInt().Should().Be(expectedResult);
        }
    }
}