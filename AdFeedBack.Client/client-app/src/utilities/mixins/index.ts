const GlobalMixins = {
    methods: {
        $IsNull(item: any): boolean {
            return item == null;
        }
    }
}

export default GlobalMixins;