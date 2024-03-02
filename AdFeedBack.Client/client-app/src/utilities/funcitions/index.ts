export default {
    ToQueryString(obj: any) {
        const json = JSON.stringify(obj);
        const auxObj = JSON.parse(json);
        const urlParams = new URLSearchParams(auxObj);
        const queryString = urlParams.toString();

        return queryString;
    },
    tokenIsExpired() {
        const tokenExpiration = sessionStorage.getItem("tokenExpiration") ?? "0";
        return parseInt(tokenExpiration) < Date.now();
    }
}