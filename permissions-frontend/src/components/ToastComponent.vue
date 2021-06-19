<template>
    <div 
        class="toast-custom" 
        v-bind:class="{ 'show': isShow }"
        @click="hide"
        >
        <p>{{ message }}</p>
    </div>
</template>
<script>
    import { AppContainer } from '../infrastructure/appContainer'
    export default {
        data() {
            AppContainer.setToastComponent(this)

            return {
                message: "this a sample",
                isShow: false
            }
        },
        
        methods: {
            show(message) {
                this.message = message
                this.isShow = true

                this.hide()
            },

            hide() {
                setTimeout(() => {
                    this.isShow = false
                }, 3000);
            }
        }
    }
</script>

<style lang="scss">
    .toast-custom {
        position:fixed;
        width: 200px;
        height: 100px;
        right: 0;
        bottom: 0;
        z-index: 5;
        border-radius: 10px;
        padding: 10px;
        margin: 20px;
        opacity: 0;
        cursor: pointer;
        color: #FFF;
        background-color: #555;
        transition: .8s;

        &.show {
            transition: .8s;
            opacity: 1;
        }

        & p {
            text-align: center;
        }
    }

</style>