
//基础路由
window.sysRouterBasePath = __Data_RoutePrefix;
//是否history模式
window.sysRouterIsHistoryMode = __Data_IsHistoryMode;
//系统信息
window.sysInfo = __Data_SystemInfo;
//接口前缀
if (window.sysInfo.apiBasePrefix) {
    axios.defaults.baseURL = window.sysInfo.apiBasePrefix;
}
//系统路由
window.sysRoutes = [__Data_SystemRoutes].map(function (e) {
    if (!e.component)
        return e;
    if (typeof (e.component.path) !== 'undefined') {
        e.path = e.component.path
    }
    if (e.component.name) {
        e.name = e.component.name
    }
    if (e.component.meta) {
        e.meta = Object.assign({}, e.meta, e.component.meta)
    }
    return e;
});
//组件注册
var compObj = {};
[__Data_SystemComps].map(function (e) {
    compObj = e;
    Vue.component(compObj.name, compObj);
})