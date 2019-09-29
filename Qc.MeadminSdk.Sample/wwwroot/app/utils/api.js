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
            return new Promise((resolve, reject) => {
                return resolve({
                    status: 1,
                    data: []
                })
            })
        }
    }
})

//user
MeAdminSdk.registerApi('user', function (request) {
    return renderApi({
        getUserOptions(params) {
            return request({
                url: '/user/user/options',
                method: 'get',
                params: params
            })
        }
    }, 'user', ['User'], request);
})


function renderApi(result, module, keys, request) {
    keys.reduce((r, s) => {
        result['get' + s + 'List'] = function (params) {
            return request({
                url: '/' + module + '/' + s + '/list',
                method: 'get',
                params: params
            })
        }
        result['get' + s + 'Item'] = function (params) {
            return request({
                url: '/' + module + '/' + s + '/item',
                method: 'get',
                params: params
            })
        }
        result['create' + s + ''] = function (data) {
            return request({
                url: '/' + module + '/' + s + '/create',
                method: 'post',
                data: data
            })
        }
        result['edit' + s + ''] = function (data) {
            return request({
                url: '/' + module + '/' + s + '/edit',
                method: 'post',
                data: data
            })
        }
        result['del' + s + ''] = function (data) {
            return request({
                url: '/' + module + '/' + s + '/delete',
                method: 'post',
                data: data
            })
        }
        return r;
    }, result)
    return result;
}