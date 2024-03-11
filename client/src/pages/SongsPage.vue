<template>
    <div class="container-fluid">
        <section class="row mt-5">
            <div class="col-12">
                <p class="fs-1 text-center feed-text">The Feed.</p>
            </div>
        </section>
        <section class="row justify-content-evenly mt-5">
            <div v-for="song in songs" :key="song.id" class="col-12 col-md-3 mb-3 song-image">
                <img @click="setActiveSong(song)" data-bs-toggle="modal" data-bs-target="#songModal" type="button"
                    class="img-fluid" :src="song.img" alt="image of song">
                <p class="song-title text-center fs-3">{{ song.title }}</p>
            </div>
        </section>
    </div>
    <ActiveSongModal />
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { songsService } from '../services/SongsService.js';
import ActiveSongModal from '../components/ActiveSongModal.vue';
export default {
    setup() {
        onMounted(() => {
            getSongs()
        })
        async function getSongs() {
            try {
                await songsService.getSongs()
            } catch (error) {
                logger.error(error)
                Pop.error(error)

            }
        }
        return {
            songs: computed(() => AppState.songs),
            setActiveSong(song) {

                songsService.setActiveSong(song)
            },
        }
    },
    components: { ActiveSongModal }
};
</script>


<style lang="scss" scoped>
.feed-text {
    font-family: cursive;
}

img {
    width: 100%;
    height: 400px;
    object-fit: cover;
    position: center;
    border-radius: 3px;
    border: 1px solid lightgray;
}

.song-image {
    position: relative;

}

.song-title {
    position: absolute;
    margin-left: auto;
    margin-right: auto;
    top: 15px;
    left: 0;
    right: 0;
    text-shadow: 3px 2px 4px white;
    font-family: cursive;
}
</style>