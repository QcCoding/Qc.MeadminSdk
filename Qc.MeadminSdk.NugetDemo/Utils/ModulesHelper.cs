using Microsoft.AspNetCore.Mvc;
using Qc.MeadminSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Qc.MeadminSdk.NugetDemo
{
    public class ModulesHelper
    {
        /// <summary>
        /// 获取后台所有模块
        /// </summary>
        /// <returns></returns>
        public static List<MeadminModuleModel> GetBackendAllModules<T>() where T : ControllerBase
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            var types = assembly.GetTypes()
                                .AsEnumerable()
                                .Where(type => typeof(T).IsAssignableFrom(type))
                                .OrderBy(type => type.GetCustomAttribute<MeadminModuleAttribute>()?.Order)
                                .ToList();
            var dics = new List<MeadminModuleModel>();
            foreach (var type in types)
            {
                var members = type.GetMethods();
                var moduleList = new List<MeadminPageModel>();
                foreach (var member in members)
                {
                    if (!typeof(IActionResult).IsAssignableFrom(member.ReturnType))
                        continue;
                    var moduleAttr = member.GetCustomAttribute<MeadminPermissionAttribute>();
                    if (moduleAttr == null)
                        continue;
                    moduleList.Add(new MeadminPageModel(
                        moduleAttr.ModuleName,
                        moduleAttr.ModuleCode,
                        moduleAttr.IsPage,
                        moduleAttr.ModuleIcon));
                }
                if (moduleList.Count == 0)
                    continue;
                var mafaAttr = type.GetCustomAttribute<MeadminModuleAttribute>();
                var moduleName = mafaAttr?.ModuleName ?? "默认";
                var mafaModule = dics.FirstOrDefault(s => s.ModuleName == moduleName);
                if (mafaModule != null)
                {
                    mafaModule.ModuleList.AddRange(moduleList);
                }
                else
                {
                    dics.Add(new MeadminModuleModel()
                    {
                        ModuleName = moduleName,
                        ModuleIcon = mafaAttr?.IconName,
                        ModuleList = moduleList
                    });
                }
            }
            return dics;
        }
        /// <summary>
        /// 获取后台生成菜单
        /// </summary>
        /// <returns></returns>
        public static List<MeadminMenuModel> GetBackendAllMenus()
        {
            var modules = GetBackendAllModules<ControllerBase>();
            List<MeadminMenuModel> list = new List<MeadminMenuModel>();
            string defaultMenuIcon = "el-icon-menu";

            foreach (var item in modules)
            {
                if (string.IsNullOrEmpty(item.ModuleName) || item.ModuleName == "默认")
                {
                    list.AddRange(item.ModuleList
                        .Where(s => s.IsPage)
                        .Select(s => new MeadminMenuModel(s)
                        {
                            MenuIcon = s.ModuleIcon ?? defaultMenuIcon,
                        }));
                }
                else
                {
                    var menu = new MeadminMenuModel()
                    {
                        MenuName = item.ModuleName,
                        MenuIcon = item.ModuleIcon ?? defaultMenuIcon,
                        Children = item.ModuleList.Where(s => s.IsPage).ToList().Select(e => new MeadminMenuModel(e)).ToList()
                    };
                    list.Add(menu);
                }
            }
            return list;
        }
    }
}
