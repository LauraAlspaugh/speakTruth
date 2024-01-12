<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12 mt-3">
        <p class="fs-5 text-center sub-truth">Thoughts from my perspective. From me to you.</p>
        <p class="truth-title text-center">Speak Truth Today </p>
      </div>
    </section>
    <section class="row justify-content-evenly">
      <div v-for="post in posts" :key="post.id" class="col-7">
        <PostCard :postProp="post" />
      </div>
    </section>
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
  font-family: Arial (sans-serif);
}
</style>
