## Qc.MeadminSdk

`Qc.MeadminSdk` 是一个使用 `asp.net core ` + `vue` 构建的开箱即用的的前后端半分离的后台管理系统解决方案，适用于快速开发后台管理系统

后台模板基于 [me-admin-sdk](https://github.com/yimogit/me-admin-sdk) 快速构建

### 使用 MeadminSdk


#### 一.安装程序包

[![Nuget](https://img.shields.io/nuget/v/Qc.MeadminSdk)](https://www.nuget.org/packages/Qc.MeadminSdk/)

- dotnet cli  
  `dotnet add package Qc.MeadminSdk`
- 包管理器  
  `Install-Package Install-Package Qc.MeadminSdk`

#### 二.使用

如需添加登录权限验证，可结合 [`Qc.SampleauthSdk`](https://github.com/QcCoding/Qc.SampleauthSdk) 使用

具体如何在 asp.net core 项目中使用可参考 [Qc.MeadminSdk.NugetDemo](./Qc.MeadminSdk.NugetDemo)

```cs
using MeadminSdk;
public void Configure(IApplicationBuilder app)
{
	app.UseMeadminSdk(opt =>
	{
		Configuration.GetSection("MeadminOptions").Bind(opt);
		// 菜单权限
		opt.AuthHandler = httpContext =>
		{
		    var loginUsername = "admin";// httpContext.Request.Cookies["LOGIN_USERNAME"];

		    return new MeadminSystemInfoModel()
		    {
			AuthName = loginUsername,
			//根据需要添加菜单
			Menus = ModulesHelper.GetBackendAllMenus(),//获取根据特性标记生成的菜单
			Modules = "*" //* 表示所有权限，//authList.FirstOrDefault(s => s.Username == loginUsername).Userkey
		    };
		};
	});
}
```
**根据特性标记生成菜单与权限**

- MeadminModule(一级菜单生成)

```cs
[MeadminModule(Order = 200, ModuleName = "用户管理")]
public class UserController : ControllerBase
{
}
```

- MeadminPermission(二级菜单与模块标识,标识对应前台vue中定义的 name 值)

```cs
[MeadminPermission("user_user_list", "用户列表", true)]
public IActionResult UserList(string keyword)
{
	return Ok();
}
```
- MeadminRelyPermission：依赖于某些权限

```cs
[MeadminRelyPermission("user_user_create", "user_user_edit")]
public IActionResult UserItem(int id)
{
	return Ok();
}
```

### MeadminOptions 配置项

appsetting.json 中 MeadminOptions 配置参考

```
{
  "MeadminOptions": {
    "EnableBabel": true,
    //路由前缀
    "RoutePrefix": "admin",
    //模块化懒加载
    "EnableModuleLazyload": false,
    // 压缩html
    "EnableUglifyHtml": true,
    // 压缩js
    "EnableUglifyJs": true,
    // 是否history模式
    "IsHistoryMode": true,
    //视图路径，读取所有的vue文件
    "ViewPath": "./wwwroot/app/views",
    //追加的js文件路径，注册api及通用常量
    "AppendJsPaths": [
      "./wwwroot/app/api/",
      "./wwwroot/app/utils/",
      "./wwwroot/app/main.js"
    ],
    //头部模板，用于加载自定义css
    "HeaderTemplate": [
      "<link rel='stylesheet' href='/css/style.css'/>"
    ],
    //底部模板，用于加载自定义js
    "FooterTemplate": [
      "<script>console.log('底部模板')</script>"
    ],
    //首页路由
    "IndexPath": "/admin/welcome",
    //指定登录页
    "LoginPath": "/admin/login",
    //退出页
    "LogoutPath": "/admin/logout",
    //导航皮肤
    "SysNavTheme": {
      "BackgroundColor": "#545c64",
      "TextColor": "#fff",
      "ActiveTextColor": "#ffd04b"
    },
    //接口前缀
    "ApiBasePrefix": "/api",
    //系统标题
    "SysTitle": "Meadmin后台管理系统",
    //主题色
    "SysTheme": "#409EFF",
    "PageSetting": {
      "AmapKey": "2333333"
    }
  }
}
```

## 示例说明

`Qc.MeadminSdk.Sample` 为示例项目，可进行测试

- 登录页

![image](https://user-images.githubusercontent.com/15975059/66807686-3105bc80-ef5c-11e9-8979-57f0c8388804.png)

- 后台

![image](https://user-images.githubusercontent.com/15975059/66807646-10d5fd80-ef5c-11e9-9ebc-bda215f82e11.png)
