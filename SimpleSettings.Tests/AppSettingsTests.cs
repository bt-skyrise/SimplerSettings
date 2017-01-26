using FluentAssertions;
using NUnit.Framework;

namespace SimpleSettings
{
    public class AppSettingsTests
    {
        [Test]
        public void can_read_setting_from_app_config()
        {
            var setting = AppSettings.Get("SomeString");

            setting.Key.Should().Be("SomeString");
            setting.IsSet.Should().BeTrue();
            setting.Value.Should().Be("some string");
        }

        [Test]
        public void can_read_missing_setting_from_app_config()
        {
            var setting = AppSettings.Get("MissingSetting");

            setting.Key.Should().Be("MissingSetting");
            setting.IsSet.Should().BeFalse();
        }
    }
}