<template>
    <div class="container-fluid post-details m-4">
        <section v-if="post" class="row justify-content-evenly">
            <div class="col-8 p-4">
                <p class="fs-5 p-2 created-date">{{ post.createdAt }}</p>
                <img class="img-fluid" :src="post.img" alt="post image">
                <p class="text-center fs-1 post-title">{{ post.title }}</p>
                <p class="text-center"><i class="mdi mdi-format-quote-open"></i>{{ post.body }}<i
                        class="mdi mdi-format-quote-close"></i></p>
            </div>
        </section>
        <section class="row justify-content-evenly">
            <div class="col-7 text-center mb-3">
                <p class="fs-4 comment-line ">Comments</p>
                <form @submit.prevent="createComment()">
                    <p class="fs-5"></p>
                    <div class="mb-3">
                        <label for="body" class="form-label"></label>
                        <textarea v-model="editable.body" type="text" required rows="3" class="form-control" id="body"
                            placeholder="Leave a comment..."></textarea>
                    </div>
                    <button type="submit" class="btn btn-dark">Post</button>
                </form>
            </div>
            <div v-for="comment in comments" :key="comment.id" class="col-7 comment-page p-2 mb-3">
                <p class="comment-content">...{{ comment.body }}</p>
                <p>- {{ comment.creator.name }} at {{
            comment.createdAt }} </p>
            </div>
        </section>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { postsService } from '../services/PostsService.js';
import { commentsService } from '../services/CommentsService.js';
export default {
    setup() {
        const editable = ref({})
        onMounted(() => {
            getPostById()
            getCommentsByPostId()
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
        async function getCommentsByPostId() {
            try {
                const postId = route.params.postId;
                await commentsService.getCommentsByPostId(postId);
            }
            catch (error) {
                logger.error(error);
            }
        }
        return {
            editable,
            route,
            account: computed(() => AppState.account),
            post: computed(() => AppState.activePost),
            comments: computed(() => AppState.comments),
            async createComment() {
                try {
                    const commentData = editable.value
                    commentData.postId = route.params.postId
                    await commentsService.createComment(commentData)
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            },
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

.comment-line {
    border-bottom: solid black 1px;
    font-family: 'Courier New', Courier, monospace;

}



.comment-content {
    font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif
}

.created-date {
    font-family: cursive;
}
</style>