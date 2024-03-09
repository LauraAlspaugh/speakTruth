<template>
    <div class="container-fluid">
        <section class="row mt-5">
            <div class="col-12">
                <p class="fs-1 text-center feed-text">The Feed.</p>
            </div>
        </section>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup() {
        return {
            songs: computed(() => AppState.songs)
        }
    }
};
</script>


<style lang="scss" scoped>
.feed-text {
    font-family: cursive;
}
</style>