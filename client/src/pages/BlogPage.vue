<template>
    <div class="container-fluid">
        <section class="row mt-5">
            <div class="col-12">
                <p class="fs-1 text-center feed-text">The Feed.</p>
            </div>
        </section>
        <section class="row justify-content-evenly mt-5">
            <div v-for="post in posts" :key="post.id" class="col-md-7 col-12 mb-5">
                <PostCard :postProp="post" />
            </div>
        </section>
    </div>
</template>


<script>
import { Logger } from 'sass';
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { postsService } from '../services/PostsService.js';
import PostCard from '../components/PostCard.vue';

export default {
    setup() {
        onMounted(() => {
            getPosts();
        });
        async function getPosts() {
            try {
                await postsService.getPosts();
            }
            catch (error) {
                Logger.error(error);
                Pop.error(error);
            }
        }
        return {
            posts: computed(() => AppState.posts)
        };
    },
    components: { PostCard }
};
</script>


<style lang="scss" scoped>
img {
    width: 300px;
    height: 300px;
    object-fit: cover;
    position: center;
    border-radius: 7px;
    justify-content: center;
    border: 1px solid black;
}

.feed-text {
    font-family: cursive;
}
</style>