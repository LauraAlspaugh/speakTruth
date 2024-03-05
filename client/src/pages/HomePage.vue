<template>
  <div class="container-fluid">
    <!-- <section class="row justify-content-center">
      <div class="col-8">

        <div id="demo" class="carousel slide" data-bs-ride="carousel">


          <div class="carousel-indicators">
            <button type="button" data-bs-target="#demo" data-bs-slide-to="0" class="active"></button>
            <button type="button" data-bs-target="#demo" data-bs-slide-to="1"></button>
            <button type="button" data-bs-target="#demo" data-bs-slide-to="2"></button>
          </div>


          <div class="carousel-inner">
            <div class="carousel-item active">
              <img
                src="https://images.unsplash.com/photo-1553002401-c0945c2ff0b0?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDd8fHF1b3Rlc3xlbnwwfHwwfHx8MA%3D%3D"
                alt="Los Angeles" class="d-block" style="width:100%">
            </div>
            <div class="carousel-item">
              <img
                src="https://plus.unsplash.com/premium_photo-1671028545797-cc0b7b6e765c?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Njl8fHF1b3Rlc3xlbnwwfHwwfHx8MA%3D%3D"
                alt="Chicago" class="d-block" style="width:100%">
            </div>
            <div class="carousel-item">
              <img
                src="https://images.unsplash.com/photo-1544137438-80d945567bd1?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjEyfHxxdW90ZXN8ZW58MHx8MHx8fDA%3D"
                alt="New York" class="d-block" style="width:100%">
            </div>
          </div>


          <button class="carousel-control-prev" type="button" data-bs-target="#demo" data-bs-slide="prev">
            <span class="carousel-control-prev-icon text-dark"></span>
          </button>
          <button class="carousel-control-next" type="button" data-bs-target="#demo" data-bs-slide="next">
            <span class="carousel-control-next-icon"></span>
          </button>
        </div>
      </div>
    </section> -->

    <section class="row">
      <div class="col-12 mt-3">
        <p class="fs-5 text-center sub-truth">Thoughts from my perspective. From me to you.</p>
        <p class="truth-title text-center">Speak Truth Today </p>
      </div>
    </section>
    <section class="row justify-content-evenly">
      <div v-for="post in posts" :key="post.id" class="col-md-7 col-12 mb-5">
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

.carousel-control-next {
  color: black;
}
</style>
