export class Post{
    constructor(data){
        this.id = data.id
        this.title = data.title
        this.body = data.body
        this.img = data.img
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.createdAt = new Date(data.createdAt).toLocaleDateString()
        this.updatedAt = new Date(data.updatedAt).toLocaleDateString()
    }
    get shortDescription() {
        return this.body.slice(0, 50)
    }
}