<template>
    <el-row>
        <el-col :span="24">
            <el-form ref="form"
                     :model="form"
                     :label-width="$codes.form_label_width"
                     v-loading="submit_loading">
                <el-form-item label="用户名" :rules="$ui.rules('用户名').required().length(1,32).build()" prop="username" class="custom-input-small">
                    <el-input type="text" placeholder="用户名" v-model="form.username" />
                </el-form-item>
                <el-form-item label="昵称" :rules="$ui.rules('昵称').length(0,30).build()" prop="nickName" class="custom-input-small">
                    <el-input type="text" placeholder="昵称" v-model="form.nickName" />
                </el-form-item>
                <el-form-item label="头像" :rules="$ui.rules('头像').build()" prop="avatar">
                    <v-upload-s placeholder="头像" v-model="form.avatar" />
                </el-form-item>
                <el-form-item label="是否黑名单" :rules="$ui.rules('是否黑名单').build()" prop="isBlack">
                    <el-switch placeholder="是否黑名单" v-model="form.isBlack" />
                </el-form-item>
                <el-form-item>
                    <el-button type="primary"
                               @click="onSubmit">保存</el-button>
                    <el-button @click="submitCallback(false)">取消</el-button>
                </el-form-item>
            </el-form>
        </el-col>
    </el-row>
</template>
<script>
    export default {
        name: "v-user-user-edit",
        props: ["id"],
        data() {
            return {
                form: {},
                submit_loading: false
            };
        },
        created() {
            this.loadData();
        },
        methods: {
            loadData() {
                if (!this.id) return;
                this.submit_loading = true;
                this.$api.user.getUserItem({ id: this.id })
                    .then(res => {
                        if (res.status === 0) return;
                        this.submit_loading = false;
                        this.form = res.data;
                    })
                    .catch(() => {
                        this.submit_loading = false;
                    });
            },
            onSubmit() {
                this.$refs.form.validate(valid => {
                    if (!valid) {
                        return false
                    }
                    this.submit_loading = true;
                    this.$api.user[this.id ? "editUser" : "createUser"](this.form)
                        .then(res => {
                            if (res.status === 0) return;
                            this.$ui.pages.success(res.msg);
                            this.submitCallback(res);
                        })
                        .finally(() => {
                            this.submit_loading = false;
                        });
                })
            },
            submitCallback(r) {
                this.$emit("submit", r);
            }
        }
    };
</script>
