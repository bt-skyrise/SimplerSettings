using System;

namespace SimplerSettings
{
    public class AppSetting
    {
        public AppSetting(string key, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            Key = key;

            _value = value;
        }

        public string Key { get; }

        private readonly string _value;

        public string Value
        {
            get
            {
                if (!IsSet)
                {
                    throw new InvalidOperationException($"{Key} setting is not set.");
                }

                return _value;
            }
        }

        public bool IsSet => _value != null;

        public static implicit operator string(AppSetting setting) => setting.Value;

        public bool AsBool()
        {
            bool value;

            if (!bool.TryParse(Value, out value))
            {
                throw new InvalidOperationException($"{Key} setting should be valid boolean, but was '{Value}'.");
            }

            return value;
        }

        public static implicit operator bool(AppSetting setting) => setting.AsBool();

        public int AsInt()
        {
            int result;

            if (!int.TryParse(Value, out result))
            {
                throw new InvalidOperationException($"{Key} setting should be valid integer, but was: '{Value}'.");
            }

            return result;
        }

        public static implicit operator int(AppSetting setting) => setting.AsInt();
    }
}