# Windows11 自动深色模式工具

![](https://shields.io/badge/license-MIT-green)

中文简体(zh-CN) | [中文繁體(zh-TW)](https://gitee.com/melon_studio/darkmode/blob/master/README_zh-TW.md) | [English(EN)](https://gitee.com/melon_studio/darkmode/blob/master/README_EN.md) | [日本語(JP)](https://gitee.com/melon_studio/darkmode/blob/master/README_JP.md)

## 前言

在如今的智能手机上也存在日出日落模式下的系统主题的深色模式，晚上使用深色模式更有利于保护眼睛，阻止过亮的光线进入眼睛，虽然Windows 11有了深色模式的切换功能，但并没有日出日落模式来自动开启深色模式，每次手动开启又非常麻烦，从而Melon Studio（XiaoFans）开发了一款这样的小工具，每天08:00 - 19:00，软件将会自动开启浅色模式，而19:00 - 08:00软件则会自动开启深色模式，支持开机自启，并且实时更改。



## 软件优势

实时更改——相较于市面上的使用任务计划来实现此功能，我认为该方法是不可取的，如果你开机处于这个时间段内时，任务计划不会去执行此次任务，所以实时就是本软件的一大特点。

体量小占用少——软件使用C# .NET Framework 4.7.2开发，软件仅有不到100KB大小，内存占用只有10MB左右，做到真正的轻量。

开机自启——软件可以设置开机自启，保证每次开机都会正常运行，服务用户，且不想使用时可以随时关闭。

多语言支持——软件支持四种语言，简体中文、繁体中文、日语和英语。



## 运行环境

操作系统：Windows 11

操作系统位数：x64

必要框架：.NET Framework 4.7.2

如果系统没有框架，请[点此安装](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-web-installer)



## 版权与许可

本开源项目遵循国际 MIT 开源协议，具体内容请详细阅读开源许可证。

本项目使用第三方库文件： Costura.Fody 包，包作者：geertvanhorrik,simoncropp，开源许可证：MIT