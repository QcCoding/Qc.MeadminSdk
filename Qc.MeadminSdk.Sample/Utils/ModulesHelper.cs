using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Qc.MeadminSdk.Sample
{
    public class ModulesHelper
    {
        /// <summary>
        /// 获取后台所有模块
        /// </summary>
        /// <returns></returns>
        public static List<CustomBackendModuleModel> GetBackendAllModules<T>() where T : ControllerBase
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            var types = assembly.GetTypes()
                                .AsEnumerable()
                                .Where(type => typeof(T).IsAssignableFrom(type))
                                .OrderBy(type => type.GetCustomAttribute<MeadminModuleAttribute>()?.Order)
                                .ToList();
            var dics = new List<CustomBackendModuleModel>();
            foreach (var type in types)
            {
                var members = type.GetMethods();
                var moduleList = new List<BackendModuleModel>();
                foreach (var member in members)
                {
                    if (!typeof(IActionResult).IsAssignableFrom(member.ReturnType))
                        continue;
                    var moduleAttr = member.GetCustomAttribute<PermissionAttribute>();
                    if (moduleAttr == null)
                        continue;
                    moduleList.Add(new BackendModuleModel(
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
                    dics.Add(new CustomBackendModuleModel()
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
        public static List<BackendMenuModel> GetBackendAllMenus()
        {
            var modules = GetBackendAllModules<ControllerBase>();
            List<BackendMenuModel> list = new List<BackendMenuModel>();
            string defaultMenuIcon = "el-icon-menu";

            foreach (var item in modules)
            {
                if (string.IsNullOrEmpty(item.ModuleName) || item.ModuleName == "默认")
                {
                    list.AddRange(item.ModuleList
                        .Where(s => s.IsPage)
                        .Select(s => new BackendMenuModel(s)
                        {
                            MenuIcon = s.ModuleIcon ?? defaultMenuIcon,
                        }));
                }
                else
                {
                    var menu = new BackendMenuModel()
                    {
                        MenuName = item.ModuleName,
                        MenuIcon = item.ModuleIcon ?? defaultMenuIcon,
                        Children = item.ModuleList.Where(s => s.IsPage).ToList().Select(e => new BackendMenuModel(e)).ToList()
                    };
                    list.Add(menu);
                }
            }
            return list;
        }
    }
}
