window.sysInfo = window.sysInfo || {}
window.sysRoutes = window.sysRoutes || []
window.sysAppConfig = window.sysAppConfig || {
    el: '#app',
    currentAppKey: '__currentApp',
    sysInfo: window.sysInfo,
    router: {
        routes: [{
            path: '/',
            component: { template: '<v-layout />' },
            children: window.sysRoutes.filter(s => !s.meta.nolayout)
        }].concat(window.sysRoutes.filter(s => s.meta.nolayout)).concat([{
            path: '*',
            redirect: '/404',
            meta: {
                skipauth: true,
                nolayout: true
            }
        }]),
    },
    store: {
        state: {},
        getters: {
            form_label_width: s => window.innerWidth > 600 ? '200px' : 'auto',
            sysInfo: s => window.sysInfo
        },
        mutations: {},
        actions: {
            uploadAction({ commit }, d) {
                console.log(d)
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
