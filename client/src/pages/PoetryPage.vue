<template>
    <div class="container-fluid">
        <section class="row mt-5">
            <div class="col-12">
                <p class="fs-1 text-center feed-text">The Feed.</p>
            </div>
        </section>
        <section class="row justify-content-evenly mb-3">
            <div v-for="poem in poems" :key="poem.id" class=" col-md-3 col-12 mb-5 poem-image">
                <!-- <router-link :to="{ name: 'Poem', params: { poemId: poem.id } }"> -->
                <img @click="setActivePoem(poem)" data-bs-toggle="modal" data-bs-target="#poemModal" type="button"
                    class="img-fluid" :src="poem.img" alt="image of poem">
                <p class="poem-title fs-5 text-center text-dark">{{ poem.title }}</p>
                <!-- </router-link> -->
            </div>
        </section>
    </div>
    <ActivePoemModal />
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { poetryService } from '../services/PoetryService.js';
import ActivePoemModal from '../components/ActivePoemModal.vue';
export default {
    setup() {
        onMounted(() => {
            getPoems()
        })
        async function getPoems() {
            try {
                await poetryService.getPoems()
            } catch (error) {
                logger.error(error)
                Pop.error(error)

            }
        }
        return {
            poems: computed(() => AppState.poems),
            setActivePoem(poem) {

                poetryService.setActivePoem(poem)
            },
        }
    },
    components: { ActivePoemModal }
};
</script>


<style lang="scss" scoped>
.feed-text {
    font-family: cursive;
}

img {
    border: 1px solid gray;
    height: 400px;
    border-radius: 3px;
}

.poem-image {
    position: relative;
}

.poem-title {
    position: absolute;
    margin-left: auto;
    margin-right: auto;
    top: 15px;
    left: 0;
    right: 0;
    text-shadow: 2px 2px 4px #000000;
    font-family: cursive;
}
</style>