<template>
    <div class="container-fluid post-details m-4">
        <section v-if="post" class="row justify-content-evenly">
            <div class="col-8 p-4">
                <img class="img-fluid" :src="post.img" alt="post image">
                <p class="text-center fs-1 post-title">{{ post.title }}</p>
                <p class="text-center">{{ post.body }}</p>
            </div>

        </section>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { postsService } from '../services/PostsService.js';
export default {
    setup() {
        onMounted(() => {
            getPostById()
        })
        const route = useRoute()
        async function getPostById() {
            try {
                const postId = route.params.postId;
                await postsService.getPostById(postId);
            }
            catch (error) {
                logger.error(error);
                Pop.error(error);
            }
        }
        return {
            route,
            account: computed(() => AppState.account),
            post: computed(() => AppState.activePost)
        }
    }
};
</script>


<style lang="scss" scoped>
img {
    height: 300px;
    width: 100%;
    border-radius: 7px;
    object-fit: cover;
    position: center;
}

.post-details {
    background-color: light gray;
    border-radius: 7px;
    backdrop-filter: blur(12px);
}

.post-title {
    font-family: 'Pinyon Script', cursive;
}
</style>