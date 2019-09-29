<template>
    <div>
        <v-user-user-edit @submit="submitHandler" />
    </div>
</template>
<script>
    export default {
        name: 'user_user_create',
        meta: {
            title: '创建用户',
            cache: true
        },
        methods: {
            submitHandler() {
                this.$store.dispatch('removeNavTab', this.$route.name) && this.$router.back();
            }
        }
    }
</script>
