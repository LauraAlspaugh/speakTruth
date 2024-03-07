<template>
  <div class="container-fluid">
    <section class="row mt-5">
      <div class="col-12">

      </div>
    </section>
    <section class="row justify-content-center mt-5">
      <div class="col-7 mt-5 main-details">
        <div class="">

          <p class="fs-5 text-center sub-truth mt-5">Thoughts from my perspective. From me to you.</p>
          <p class="truth-title text-center mb-5">Speak Truth Today </p>
        </div>
      </div>
    </section>
    <!-- <section class="row justify-content-evenly">
      <div class="col-6 ">
        <p class="fs-4"><i class="mdi mdi-format-quote-open"></i>Don't sit down and wait for the opportunities to come.
          Get up and
          make them.<i class="mdi mdi-format-quote-close"></i> </p>
      </div>
    </section> -->
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { postsService } from '../services/PostsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
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
        logger.error(error);
        Pop.error(error);
      }
    }
    return {
      posts: computed(() => AppState.posts)
    };
  },
  components: { PostCard }
}
</script>

<style scoped lang="scss">
.truth-title {
  font-size: 60px;
  font-family: 'Pinyon Script', cursive;
}

.sub-truth {
  font-family: 'Courier New', Courier, monospace;
}

img {
  width: 300px;
  height: 300px;
  object-fit: cover;
  position: center;
  border-radius: 7px;
  justify-content: center;
  border: 1px solid black;
}

.main-details {
  background-color: light gray;
  border-radius: 10px;
  backdrop-filter: blur(12px);
  border: 1px solid gray;
  padding: 5px;
}
</style>
