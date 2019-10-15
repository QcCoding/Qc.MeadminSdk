<template>
    <el-row :gutter="24">
        <el-col>
            <div style="text-align:center;" class="custom-main-title">
                <router-link to="/"
                             style="text-decoration: none;"
                             v-text="$store.getters.sysTitle"></router-link>
                <bdi style="float:right;">
                    <v-picker-theme />
                    <pre>{{$store.getters.authName}}&nbsp;&nbsp;</pre>
                </bdi>
            </div>
        </el-col>
    </el-row>
</template>
<script>
    export default {
        name: 'v-comp-header',
    }
</script>
