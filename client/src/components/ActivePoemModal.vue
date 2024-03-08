<template>


    <!-- Modal -->
    <div v-if="poem" class="modal fade" id="poemModal" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog  modal-lg">
            <div class="modal-content">
                <!-- <div class="modal-header p-0">
                   
                </div> -->
                <div class="modal-body p-0">
                    <!-- <div class="d-flex justify-content-end w-100"> -->

                    <button type="button" class="btn-close modal-close " data-bs-dismiss="modal"
                        aria-label="Close"></button>
                    <img class="img-fluid" :src="poem.img" alt="poem image">
                    <!-- </div> -->

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
            poem: computed(() => AppState.activePoem)
        }
    }
};
</script>


<style lang="scss" scoped>
img {
    position: relative;
    border-radius: 7px;
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