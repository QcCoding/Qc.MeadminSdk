# MeadminSdk

## Qc.MeadminSdk

`Qc.MeadminSdk` 是一个基于 `.NET Standard 2.0` 构建，对我的后台框架平台的常用接口进行了封装。


### 使用 MeadminSdk


#### 一.安装程序包

[![Nuget](https://img.shields.io/nuget/v/Qc.MeadminSdk)](https://www.nuget.org/packages/Qc.MeadminSdk/)

- dotnet cli  
  `dotnet add package Qc.MeadminSdk`
- 包管理器  
  `Install-Package Install-Package Qc.MeadminSdk`

#### 二.添加配置

> 如需实现自定义存储 AccessToken，动态获取应用配置，可自行实现接口 `IMeadminSdkHook`  
> 默认提供 `DefaultMeadminSdkHook`，存储 AccessToken 等信息到指定目录(默认./AppData)

```cs
using MeadminSdk;
public void ConfigureServices(IServiceCollection services)
{
  //...
  services.AddMeadminSdk<MeadminSdk.DefaultMeadminSdkHook>(opt =>
  {
      opt.ApiKey = "Api Key";
      opt.SecretKey = "Secret Key";
  });
  //...
}
```

#### 三.代码中使用

在需要地方注入`MeadminService`后即可使用

### MeadminConfig 配置项

Meadmin文档地址: 

## 示例说明

`Qc.MeadminSdk.Sample` 为示例项目，可进行测试
