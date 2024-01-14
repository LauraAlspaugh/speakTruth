import { api } from "./AxiosService.js"
import { AppState } from "../AppState.js"
import { Comment } from "../models/Comment.js"
import { logger } from "../utils/Logger.js"
class CommentsService{
    async getCommentsByPostId(postId){
        const res = await api.get(`api/posts/${postId}/comments`)
       logger.log('getting comments', res.data)
       AppState.comments = res.data.map(pojo => new Comment(pojo))
    }
    async createComment(commentData){
        const res = await api.post('api/comments', commentData)
        logger.log('creating comment!', res.data)
        AppState.comments.push(new Comment(res.data))
    
    }
}
export const commentsService = new CommentsService()