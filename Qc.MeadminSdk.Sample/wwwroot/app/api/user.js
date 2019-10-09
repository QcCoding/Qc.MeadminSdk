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