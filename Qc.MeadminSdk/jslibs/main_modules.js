window.sysInfo = window.sysInfo || {}
function mapRouteChildren(moduleName) {
    return window['ModulesRoutes_' + moduleName].map(function (e) {
        e.path = e.path.replace('/' + moduleName + '/', '')
        if (!e.component)
            return e;
        if (e.component.name) {
            e.name = e.component.name
        }
        if (e.component.meta) {
            e.meta = Object.assign({}, e.meta, e.component.meta)
        }
        return e;
    })
}
window.sysRoutes = window.sysRoutes || []
window.sysAppConfig = window.sysAppConfig || {
    el: '#app',
    currentAppKey: '__currentApp',
    sysInfo: window.sysInfo,
    router: {
        beforeEach(to, from, next) {
            if (to.query.lazyload) {
                if (from.name == null && from.path === '/') {
                    next("/redirect?data=" + encodeURIComponent(JSON.stringify(Object.assign({}, to, { query: { lazyload: false } }))))
                    return;
                }
                next()
                return;
            }
            var moduleName = null;
            var toPath = to;
            if (to.name === null && to.path.split('/').length >= 3) {
                moduleName = to.path.split('/')[1]
            }
            if (to.name && to.name.split('_').length >= 3) {
                moduleName = to.name.split('_')[0]
            }
            else if (to.name === '404' && to.redirectedFrom && to.redirectedFrom.split('/').length >= 3) {
                moduleName = to.redirectedFrom.split('/')[1]
            }
            if (moduleName) {
                Vue.nextTick(() => {
                    if (window['ModulesRoutes_' + moduleName]) {
                        __currentApp.$router.addRoutes([{
                            path: '/' + moduleName,
                            component: { template: '<v-layout />' },
                            children: mapRouteChildren(moduleName)
                        }].concat([{
                            path: '*',
                            redirect: '/404',
                            meta: {
                                skipauth: true,
                                nolayout: true
                            }
                        }]))
                        next(Object.assign({}, toPath, { replace: true, query: { lazyload: true } }))
                    }
                    else {
                        __currentApp.$ui.pages.dynamicLoadJs('./modulejs/' + moduleName + '.js', () => {
                            window['ModulesComps_' + moduleName].map(s => {
                                Vue.component(s.name, s);
                            })
                            __currentApp.$router.addRoutes([{
                                path: '/' + moduleName,
                                component: { template: '<v-layout />' },
                                children: mapRouteChildren(moduleName)
                            }].concat([{
                                path: '*',
                                redirect: '/404',
                                meta: {
                                    skipauth: true,
                                    nolayout: true
                                }
                                }]))
                            next(Object.assign({}, toPath, { replace: true, query: { lazyload: true } }))
                        })
                    }
                });
                return;
            }
            next();
        },
        routes: [{
            path: '/',
            component: { template: '<v-layout />' },
            children: window.sysRoutes.filter(s => !s.meta.nolayout)
        }].concat(window.sysRoutes.filter(s => s.meta.nolayout))
        ,
    },
    store: {
        state: {},
        getters: {
            form_label_width: s => window.innerWidth > 600 ? '200px' : 'auto'
        },
        mutations: {},
        actions: {
            uploadAction({ commit }, d) {
                //console.log(d)
                if (d.category) {
                    d.fromData.append('category', d.category)
                }
                return __currentApp.$ui.fetch.post(null, null, {
                    url: 'common/upload',
                    method: "POST",
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    },
                    transformRequest: function (data) { return data },
                    data: d.fromData
                })
            }
        }
    }
}
var vueApp = MeAdminSdk.register(window.sysAppConfig)