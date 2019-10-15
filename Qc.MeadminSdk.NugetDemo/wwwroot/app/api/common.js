//api
MeAdminSdk.registerApi('common', function (request) {
    return {
        getDayInfo() {
            return request({
                url: '/common/dayinfo',
                method: 'get',
            })
        },
        getEnvInfo() {
            return request({
                url: '/common/envinfo',
                method: 'get',
            })
        },
        getWelcome() {
            return request({
                url: '/common/welcome',
                method: 'get',
            })
        },
        upload(data) {
            return request({
                url: '/common/upload',
                method: 'post',
                data: data,
            })
        },
        listOptions() {
            return new Promise(function (resolve, reject) {
                return resolve({
                    status: 1,
                    data: []
                })
            })
        }
    }
})
