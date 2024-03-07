<template>
    <div class="modal fade" id="createPoemModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title text-dark" id="exampleModalLabel">Share a Poem</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body text-dark">
                    <form @submit.prevent="createPoem()">
                        <div class="mb-3">
                            <label for="title" class="form-label">Title</label>
                            <input v-model="editable.title" type="text" required class="form-control" id="title"
                                placeholder="Poem Title...">

                        </div>
                        <div class="mb-3">
                            <label for="imageUrl" class="form-label">Image</label>
                            <input v-model="editable.img" type="url" required class="form-control" id="imgUrl"
                                placeholder="Image Url...">
                        </div>
                        <div class="mb-3">
                            <label for="body" class="form-label">Body</label>
                            <textarea v-model="editable.body" rows="5" type="text-area" required class="form-control"
                                id="body" placeholder="Poem Body..."></textarea>
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
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { poetryService } from '../services/PoetryService.js';
import { Modal } from 'bootstrap';
export default {
    setup() {
        const editable = ref({})
        const router = useRouter()
        return {
            editable,
            poems: computed(() => AppState.poems),
            async createPoem() {
                try {
                    const poemData = editable.value
                    const poem = await poetryService.createPoem(poemData)
                    Pop.success('Poem Created!')
                    editable.value = {}
                    Modal.getOrCreateInstance("#createPoemModal").hide()
                    router.push({ name: "Poem", params: { poemId: poem.id } })
                } catch (error) {
                    logger.error(error)
                    Pop

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