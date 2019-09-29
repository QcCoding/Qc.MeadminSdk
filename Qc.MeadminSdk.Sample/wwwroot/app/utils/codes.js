//codes
MeAdminSdk.registerCodes(null, function () {
    return {
        default_date_format: 'yyyy-MM-dd',
        form_label_width: window.innerWidth > 600 ? '200px' : 'auto',
    }
})

MeAdminSdk.registerCodes(null, function ($ui) {
    return {
        registerEditor(callback) {
            if (window.isLoadEditor) {
                callback && callback()
                return;
            }
            $ui.pages.dynamicLoadJs("/libs/yimo-vue-editor.js", function () {
                window.Vue.use(YimoVueEditor, {
                    name: "v-form-editor", //Custom name
                    config: {}, //wagnEditor config
                    uploadHandler: (type, resTxt) => {
                        //Upload processing hook
                        if (type === "success") {
                            var res = JSON.parse(resTxt); //Do not process the default look at the return value bit image path
                            if (res.status !== 1) {
                                return null;
                            }
                            return res.data;
                        } else if (type === "error") {
                            //todo toast
                        } else if (type === "timeout") {
                            //todo toast
                        }
                        return "upload failed__";
                    }
                });
                window.isLoadEditor = true;
                callback && callback();
            });
        }
    }
})