# Windows11 自動深色模式工具

![](https://shields.io/badge/license-MIT-green)

[中文简体(zh-CN)](https://gitee.com/melon_studio/darkmode/blob/master/README.md) | 中文繁體(zh-TW) | [English(en-US)](https://gitee.com/melon_studio/darkmode/blob/master/README_EN.md) | [日本語(ja-JP)](https://gitee.com/melon_studio/darkmode/blob/master/README_JP.md)

註明：因大陸普通用語和台灣地區用語存在差異，所以部分詞彙翻譯使用機器翻譯

## 前言

在如今的智能機上也存在日出日落模式下的系統主題的深色模式，晚上使用深色模式更有利於保護眼睛，阻止過亮的光線進入眼睛，雖然Windows 11有了深色模式的切換功能，但並沒有日出日落模式來自動開啟深色模式，每次手動開啟又非常麻煩，從而Melon Studio（XiaoFans）開發了一款這樣的小工具，每天08:00 - 19:00，軟體將會自動開啟淺色模式，而19:00 - 08:00軟體則會自動開啟深色模式，支持開機自啟，並且實時更改。



## 軟體優勢

實時更改——相較於市面上的使用任務計劃來實現此功能，我認為該方法是不可取的，如果你開機處於這個時間段內時，任務計劃不會去執行此次任務，所以實時就是本軟體的一大特點。

體量小占用少——軟體使用C# .NET Framework 4.7.2開發，軟體僅有不到100KB大小，內存佔用只有10MB左右，做到真正的輕量。

開機自啟——軟體可以設置開機自啟，保證每次開機都會正常運行，服務用戶，且不想使用時可以隨時關閉。

多語言支持——軟體支持四種語言，簡體中文、繁體中文、日語和英語。



## 運行環境

操作系統：Windows 11

操作系統位數：x64

必要框架：.NET Framework 4.7.2

如果系統沒有框架，請[點此安裝](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-web-installer)



## 版權與許可

本開源項目遵循國際 MIT 開源協議，具體內容請詳細閱讀開源許可證。

本項目使用第三方庫文件： Costura.Fody 包，包作者：geertvanhorrik,simoncropp，開源許可證：MIT