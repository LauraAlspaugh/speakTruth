import { AppState } from "../AppState.js"
import { Song } from "../models/Song.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class SongsService{
   async createSong(songData){
    const res = await api.post('api/songs', songData)
    logger.log('creating a song', res.data)
    const newSong = new Song(res.data)
    AppState.songs.push(newSong)
    return newSong
   }
   async getSongs(){
      const res = await api.get('api/songs')
      logger.log('getting songs!', res.data)
      AppState.songs = res.data.map(pojo => new Song(pojo))
   }
   async setActiveSong(song) {
      const res = await api.get(`api/songs/${song.id}`)
      logger.log('getting song by id', res.data)
  
      AppState.activeSong = song
  }
}
export const songsService = new SongsService()