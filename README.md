*Work in progress*

# SimplerSettings

[![Build status](https://ci.appveyor.com/api/projects/status/c0r2yisa2ri8l3rg?svg=true)](https://ci.appveyor.com/project/Parkanizer/simplersettings)

Simple library for reading app.config/web.config appSettings section.

## Why not just use ConfigurationManager?

1. Diagnostics: `"Foo setting is not set."` exception message instead of getting `null`.
1. Some basic parsing out of the box. Also with diagnostics: `"Foo setting should be valid boolean, but was 'not-bool'."`.

## OK, how do I use it?

Install it:

``` PowerShell
Install-Package SimplerSettings
```

Import it:

``` C#
using SimplerSettings;
```

Get some settings:

``` C#
// get your setting

AppSetting setting = AppSettings.Get("SomeSetting");

// check if you found anything

var isSettingSet = setting.IsSet;

// convert it

var stringValue = setting.Value;
var intValue = setting.AsInt();
var boolValue = setting.AsBool();

// or just implicitly cast it

string someString = setting;
int someInt = setting;
bool someBool = setting;
```
