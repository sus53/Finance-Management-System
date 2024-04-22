import axios from "axios";
import { CompanySearch } from "./company";

interface Response {
    data: CompanySearch[];
}

export const searchResponse = async (query: string) => {
    try {
        const data = await axios.get<Response>(`https://financialmodelingprep.com/api/v3/search-ticker?query=${query}&limit=10&exchange=NASDAQ`)
        return data;
    } catch (error) {
        console.log(error)
    }
}