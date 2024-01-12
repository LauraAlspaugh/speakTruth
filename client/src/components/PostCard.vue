<template>
    <div class="post-card">
        <div class="col-12">
            <img class="img-fluid" :src="postProp.img" alt="post image">
            <!-- <router-link :to="{ name: 'Project', params: { projectId: projectProp.id } }">
                <img class="img-fluid" :src="projectProp.img" alt="project image">
            </router-link> -->

        </div>
        <div class="col-12">
            <p class="m-2 fs-4 post-name text-center">{{ postProp.title }}</p>
            <!-- <p class="m-2">{{ postProp.body.shortDescription }}</p> -->
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Mollitia quia vero sit dolor dicta optio illo
                aliquam veniam iste ad animi accusamus modi magni, libero veritatis repellendus laudantium quae at! Porro
                cumque, corrupti est vero totam iste illo voluptas, mollitia veniam saepe officia?</p>

        </div>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Post } from '../models/Post.js';
export default {
    props: { postProp: { type: Post, required: true } },
    setup() {
        return {
            posts: computed(() => AppState.posts),
            description: computed(() => AppState.posts.shortDescription)
        }
    }
};
</script>


<style lang="scss" scoped>
.post-card {
    background-color: white;
    border-radius: 7px;
    margin-bottom: 7px;
    box-shadow: 3px 2px 3px gray;
}

img {
    width: 100%;
    border-radius: 7px;
    height: 300px;
    object-fit: cover;
}

.post-name {
    color: #3F7D75;
    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
}
</style>