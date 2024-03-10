export interface UserVM{
    Id: number,
    Name: string,
    Email: string,
}

export interface PostVM {
    UserId: number,
    PlattaformId: number,
    TopicId: number,
    UserName: string,
    PostText: string
}

export interface TopicVM {
    Id: number,
    Name: string,
    Description: string
}

export interface PlataformVM {
    Id: number,
    Name: string,
    Description: string
}