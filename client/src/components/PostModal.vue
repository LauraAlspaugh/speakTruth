<template>
    <div class="modal fade" id="createPostModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title text-dark" id="exampleModalLabel">Create a Post</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body text-dark">
                    <form @submit.prevent="createPost()">
                        <div class="mb-3">
                            <label for="title" class="form-label">Title</label>
                            <input v-model="editable.title" type="text" required max="100" class="form-control"
                                id="title" placeholder="Post Title...">

                        </div>
                        <div class="mb-3">
                            <label for="imageUrl" class="form-label">Image</label>
                            <input v-model="editable.img" type="url" required class="form-control" maxlength="1000"
                                id="imgUrl" placeholder="Image Url...">
                        </div>
                        <div class="mb-3">
                            <label for="body" class="form-label">Body</label>
                            <textarea v-model="editable.body" rows="5" type="text-area" maxlength="2000" required
                                class="form-control" id="body" placeholder="Post Body..."></textarea>
                        </div>
                        <button type="submit" class="btn btn-outline-dark">Submit</button>
                    </form>

                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { useRouter } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { postsService } from '../services/PostsService.js';
import Pop from '../utils/Pop.js';
import { Modal } from 'bootstrap';
import { logger } from '../utils/Logger.js';
export default {
    setup() {
        const editable = ref({})
        const router = useRouter()
        return {
            editable,
            posts: computed(() => AppState.posts),
            async createPost() {
                try {
                    const postData = editable.value
                    const post = await postsService.createPost(postData)
                    Pop.success('Post Created!')
                    editable.value = {}
                    Modal.getOrCreateInstance("#createPostModal").hide()
                    router.push({ name: "Post", params: { postId: post.id } })
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped>
.modal-footer {
    background-color: #AAB7B8;
}

.modal-header {
    background-color: #AAB7B8;
}

.modal-title {
    font-family: 'Pinyon Script', cursive;
    ;
}
</style>