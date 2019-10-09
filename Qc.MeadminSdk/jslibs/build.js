localStorage.IS_HASH_MODE = true
window.sysInfo = _Data_SystemInfo
axios.defaults.baseURL = window.sysInfo.apiBasePrefix || '/api';
window.sysRoutes = eval('[' + _Data_SystemRoutes + ']').map(function (e) {
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
var compObj = {};
eval('[' + _Data_SystemComps + ']').map(function (e) {
    compObj = e;
    Vue.component(compObj.name, compObj);
})

let _abcdef = () => { }