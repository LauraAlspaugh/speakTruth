<template>
    <div v-if="song" class="modal fade" id="songModal" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog  modal-lg">
            <div class="modal-content">
                <div class="modal-body p-0">
                    <button type="button" class="btn-close modal-close " data-bs-dismiss="modal"
                        aria-label="Close"></button>
                    <img class="img-fluid" :src="song.img" alt="song image">
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup() {
        return {
            song: computed(() => AppState.activeSong)
        }
    }
};
</script>


<style lang="scss" scoped>
img {
    position: relative;
    border-radius: 7px;
    height: 600px;
    width: 100%;
    object-fit: cover;
    position: center;
}

.modal-dialog {
    border-radius: 7px;
}

.modal-close {
    position: absolute;
    top: 30px;
    color: black;
}
</style>