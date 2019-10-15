
function renderApi(result, module, keys, request) {
    keys.reduce(function (r, s) {
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
