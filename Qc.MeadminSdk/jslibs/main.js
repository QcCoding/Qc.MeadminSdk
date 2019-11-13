(function (sysInfo, sysRoutes) {
    if (window['__currentApp'])
        return;
    //系统配置
    var sysAppConfig = {
        el: '#app',
        currentAppKey: '__currentApp',
        sysInfo: sysInfo,
        router: {
            mode: window.sysRouterIsHistoryMode ? 'history' : 'hash',
            base: window.sysRouterBasePath || '/',
            routes: [{
                path: '',
                component: { template: '<v-layout />' },
                children: sysRoutes.filter(s => !s.meta.nolayout)
            }].concat(sysRoutes.filter(s => s.meta.nolayout)).concat([{
                name: 'empty_all',
                path: '*',
                meta: {
                    skipauth: true,
                    nolayout: true
                },
                component: {
                    template: '<div>404 Not Found</div>',
                    created() {
                        console.log(this.$route);
                        if (this.$router.options.routes.filter(s => s.name === '404').length > 0) {
                            this.$router.push({ name: '404' })
                        }
                    }
                }
            }]),
        },
        store: {
            state: {},
            getters: {
                form_label_width: s => window.innerWidth > 600 ? '200px' : 'auto',
                sysInfo: s => sysInfo
            },
            mutations: {},
            actions: {
                uploadAction({ commit }, d) {
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
    MeAdminSdk.register(sysAppConfig)
})(window.sysInfo, window.sysRoutes)