import axios from "axios";

export default {
    async $GetString() {
        console.log("Hola");
        return axios.get<string>("/api/Test/GetStrings");
    },
};