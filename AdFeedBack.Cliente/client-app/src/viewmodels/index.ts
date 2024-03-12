export interface UserVM{
    Id: number,
    Name: string,
    Email: string,
}

export interface PostVM {
    UserId: number,
    Plataform: PlataformVM,
    Topic: TopicVM,
    UserName: string,
    PostText: string
}

export interface TopicVM {
    value: number,
    text: string,
}

export interface PlataformVM {
    value: number,
    text: string,
}