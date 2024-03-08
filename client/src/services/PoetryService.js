import { AppState } from "../AppState.js"
import { Poem } from "../models/Poem.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class PoetryService{
async getPoems(){
    const res = await api.get('api/poetry')
    logger.log('getting poetry!', res.data)
    AppState.poems = res.data.map(pojo => new Poem(pojo))
}
async createPoem(poemData){
    const res = await api.post('api/poetry', poemData)
    logger.log('creating poem!', res.data)
    const newPoem = new Poem(res.data)
    AppState.poems.push(newPoem)
    return newPoem
}
async setActivePoem(poem) {
    const res = await api.get(`api/poetry/${poem.id}`)
    logger.log('getting keep by id', res.data)

    AppState.activePoem = poem
}
} 
export const poetryService = new PoetryService()