<template>
    <div>
        <v-user-user-edit @submit="$store.dispatch('removeNavTab',$route.name)&&$router.back()"
                          :id="$route.params.id" />
    </div>
</template>
<script>
    export default {
        name: 'user_user_edit',
        meta: {
            title: '编辑用户'
        }
    }
</script>
