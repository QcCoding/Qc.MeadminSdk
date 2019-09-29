<template>
    <div>
        <el-row>
            <el-col :span="18">
                <el-form :inline="true" @submit.native.prevent>
                    <el-form-item label="关键字">
                        <el-input type="text" v-model="search.keyword" clearable></el-input>
                    </el-form-item>
                    <el-button icon="el-icon-search" @click="e=>this.$refs.mytable.search()"></el-button>
                </el-form>
            </el-col>
            <el-col :span="6" class="text-right">
                <v-btn-create @click="$ui.pages.link({name:'user_user_create'})"
                              auth="user_user_create">添加</v-btn-create>
            </el-col>
        </el-row>
        <v-table-pager :loadAction="$api.user.getUserList"
                       :loadSearch="search"
                       ref="mytable"
                       show-checkbox
                       :hide-pager="false"
                       @handle-checkbox="e=>checkList=e">
            <el-table-column prop="username" label="用户名">
            </el-table-column>
            <el-table-column prop="nickName" label="昵称">
            </el-table-column>
            <el-table-column prop="isBlack" label="是否黑名单">
                <v-tag-enable slot-scope="scope"
                              v-model="scope.row.isBlack" />
            </el-table-column>
            <el-table-column prop="createdAt" label="创建时间" width="125">
            </el-table-column>
            <el-table-column label="操作"
                             width="180">
                <template slot-scope="prop">
                    <v-btn-edit @click="$ui.pages.link({name:'user_user_edit',params:{id:prop.row.id}})"
                                auth="user_user_edit">编辑</v-btn-edit>
                    <v-btn-del @click="delUser([prop.row.id])" auth="user_user_delete">删除</v-btn-del>
                </template>
            </el-table-column>
            <div slot="toolbar">
            </div>
        </v-table-pager>
    </div>
</template>
<script>
    export default {
        name: 'user_user_list',
        meta: {
            title: '用户列表',
            cache: true
        },
        data() {
            return {
                search: {
                    keyword: ''
                },
                list: [],
                checkList: []
            }
        },
        methods: {
            delUser(ids) {
                this.$ui.pages.confirm('确认删除？').then(res => {
                    this.$refs.mytable.showLoading()
                    this.$api.user.delUser({ ids: ids })
                        .then(res => {
                            if (res.status !== 1) return
                            this.$ui.pages.success(res.msg)
                        })
                        .finally(_ => {
                            this.$refs.mytable.loadData()
                        })
                })
            }
        }
    }
</script>
