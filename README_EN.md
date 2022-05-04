# Windows 11 tool for automatically switching the system dark theme

![](https://shields.io/badge/license-MIT-green)

[中文简体(zh-CN)](https://gitee.com/melon_studio/darkmode/blob/master/README.md) | [中文繁體(zh-TW)](https://gitee.com/melon_studio/darkmode/blob/master/README_zh-TW.md) | English(EN) | [日本語(JP)](https://gitee.com/melon_studio/darkmode/blob/master/README_JP.md)

Note: Some translations use machine translation.

## Preface

Using the dark theme of the system at night is more conducive to protecting eyes. Windows 11 supports dark theme, but does not support automatic switching. This tool realizes automatic switching. The working principle is that the light theme will be turned on from 08:00 in the morning to 19:00 in the afternoon, and the dark theme will be turned on from 19:00 in the afternoon to 08:00 in the morning. The tool supports self-starting at boot, and supports Chinese, Japanese and English.



## Software advantages

real-time changes——Using the Task Scheduler to achieve this functionality is not desirable. If you are in the dark theme time period after booting, the task plan will not execute this task, so you will not switch the dark theme, so real-time change is a major feature of this software.

Lightweight——The software is developed using the C# language .NET Framework 4.7.2 framework. The software only takes up less than 100KB of ROM and only about 10MB of RAM, making it truly lightweight software.

Self-start——The software can be set to start automatically when it is turned on, to ensure that it will run normally every time it is turned on, serve users, and can be turned off at any time when you don't want to use it.

Multilingual Support —— The software supports four languages, Simplified Chinese, Traditional Chinese, Japanese and English.



## Operating environment

System OS: Windows 11

System Bits: x64

Run frame: .NET Framework 4.7.2

If your computer is not running the framework, [click here](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-web-installer) to install.



## Copyright and License

This open source project follows the international MIT open source agreement, please read the open source license for details.

This project uses third-party library files: Costura.Fody package, package author: geertvanhorrik, simoncropp, open source license: MIT