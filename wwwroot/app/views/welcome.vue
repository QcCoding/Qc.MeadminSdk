<template>
    <div>
        欢迎您，{{$store.getters.authName}}
    </div>
</template>
<script>
    export default {
        path:'/welcome',
        name: 'welcome',
        meta: {
            title: '欢迎页',
            skipauth: true
        }
    }
</script>
