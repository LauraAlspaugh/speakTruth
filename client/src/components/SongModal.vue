<template>
    <div class="modal fade" id="createSongModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title text-dark" id="exampleModalLabel">Share a Song</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body text-dark">
                    <form @submit.prevent="createSong()">
                        <div class="mb-3">
                            <label for="title" class="form-label">Title</label>
                            <input v-model="editable.title" type="text" required class="form-control" id="title"
                                placeholder="Song Title...">

                        </div>
                        <div class="mb-3">
                            <label for="imageUrl" class="form-label">Image</label>
                            <input v-model="editable.img" type="url" required class="form-control" id="imgUrl"
                                placeholder="Image Url...">
                        </div>
                        <div class="mb-3">
                            <label for="body" class="form-label">Body</label>
                            <textarea v-model="editable.body" rows="5" type="text-area" required class="form-control"
                                id="body" placeholder="Comments..."></textarea>
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
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { useRouter } from 'vue-router';
import { logger } from '../utils/Logger.js';
import { Modal } from 'bootstrap';
import { songsService } from '../services/SongsService.js';
export default {
    setup() {
        const editable = ref({})
        const router = useRouter()
        return {
            songs: computed(() => AppState.songs),
            editable,
            async createPoem() {
                try {
                    const songData = editable.value
                    const poem = await songsService.createPoem(songData)
                    Pop.success('Song Created!')
                    editable.value = {}
                    Modal.getOrCreateInstance("#createSongModal").hide()
                    router.push({ name: "Song", params: { songId: song.id } })
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