export class Poem{
    constructor(data){
        this.id = data.id
        this.title = data.title
        this.body = data.body
        this.img = data.img
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.createdAt = new Date(data.createdAt).toLocaleDateString('en-us', {  year:"numeric", month:"long", day:"numeric"}) 
        this.updatedAt = new Date(data.updatedAt).toLocaleDateString()
    }
}