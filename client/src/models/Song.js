export class Song{
constructor(data){
    this.id = data.id
    this.title = data.title
    this.img = data.img
    this.body = data.body
    this.creator = data.creator
    this.creatorId = data.creatorId
    this.createdAt = new Date(data.createdAt).toLocaleDateString()
    this.updatedAt = new Date(data.updatedAt).toLocaleDateString()
    
}
}