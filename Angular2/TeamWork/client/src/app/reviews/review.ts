export class Review {
    constructor(
        id?: string,
        text?: string,
        rating?: number,
        date?: Date,
        published?: boolean,
        author?:{
            username?: string
        }
    ){}
}