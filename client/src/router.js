import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage')
  },
  {
    path: '/about',
    name: 'About',
    component: loadPage('AboutPage')
  },
  {
    path: '/blog',
    name: 'The Blog',
    component: loadPage('BlogPage')
  },
  {
    path: '/poetry',
    name: 'Poetry',
    component: loadPage('PoetryPage')
  },
  {
    path: '/songs',
    name: 'Songs',
    component: loadPage('SongsPage')
  },
  {
    path: '/post/:postId',
    name: 'Post',
    component: loadPage('PostDetailsPage')
  },
  {
    path: '/poem/:poemId',
    name: 'Poem',
    component: loadPage('PoemDetailsPage')
  },
  {
    path: '/song/:songId',
    name: 'Song',
    component: loadPage('SongDetailsPage')
  },
  {
    path: '/account',
    name: 'Account',
    component: loadPage('AccountPage'),
    beforeEnter: authGuard
  }
]

export const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})
