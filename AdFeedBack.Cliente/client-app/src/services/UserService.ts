import { UserVM } from "@/viewmodels";
import axios from "axios";

export default {
    async $GetLoggedUser() {
        console.log("Hola");
        return axios.get<UserVM>("/api/User/GetLoggedUser");
    },
};