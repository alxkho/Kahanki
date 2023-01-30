import { MessageModel } from "./MessageModel";
import { UserModel } from "./userModel";

export class ChatModel {
    public id!: string;

    public messages!: MessageModel[];

    public users!: UserModel[];
}


