<template>

    <div class="dashboard-block">
        <el-row>
            <el-col :span="24">
                <el-card class="box-card">
                    <div slot="header" class="clearfix">
                        <span>数据概览</span>
                    </div>
                    <el-row :gutter="24" v-loading="loadingOrderData">
                        <el-col v-for="(value,key) in orderData" :key="key" :span="6" :xs="12">
                            <div class="grid-content">
                                <el-card shadow="hover">
                                    <span>{{key}}</span>
                                    <el-tag type="success" v-html="value"></el-tag>
                                </el-card>
                            </div>
                        </el-col>
                    </el-row>
                </el-card>
            </el-col>
            <el-col :span="24">
                <div class="grid-content"></div>
                <el-card class="box-card">
                    <div slot="header" class="clearfix">
                        <span>系统信息</span>
                    </div>
                    <el-row :gutter="20">
                        <el-col :span="24">
                            <div class="grid-content">
                                <el-table :data="envData"
                                          :show-header="false"
                                          v-loading="loadingEnvData"
                                          stripe
                                          style="width: 100%">
                                    <!--3.0字典类型默认为大写-->
                                    <el-table-column prop="Key"></el-table-column>
                                    <el-table-column prop="Value"></el-table-column>
                                </el-table>
                            </div>
                        </el-col>
                    </el-row>
                </el-card>
            </el-col>
            <el-col :span="24">
                <el-row :gutter="20">
                    <p class="copyright" style="text-align:center;">
                        本项目由
                        <a href="https://github.com/qccoding/Qc.MeadminSdk" target="_blank">Qc.MeadminSdk</a>
                        提供技术支持
                    </p>
                </el-row>
            </el-col>
        </el-row>
    </div>
</template>
<script>
    export default {
        path: '',
        name: 'home',
        meta: {
            title: '控制台',
            authRedirect: {
                name: 'welcome'
            },
            cache: true
        },
        data() {
            return {
                loadingOrderData: true,
                orderData: {},
                loadingEnvData: true,
                envData: []
            }
        },
        created() {
            this.loadData()
        },
        methods: {
            loadData() {
                this.$api.common.getDayInfo().then(res => {
                    if (res.status === 1) {
                        this.orderData = res.data
                        this.loadingOrderData = false
                    }
                });
                this.$api.common.getEnvInfo().then(res => {
                    if (res.status === 1) {
                        this.envData = res.data
                        this.loadingEnvData = false
                    }
                })
            }
        }
    }
</script>
