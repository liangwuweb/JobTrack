import { fetchWrap, url as urlHelper, offlineResponse } from "./helper";
import Application from "@/models/Application";

export default {
	/**
	 * Get all applications
	 * @param {Object} params request parameters.
	 * @returns (async) Returns an array of Applicaton objects if the request was successful, otherwise a Response.
	 */
	async getAll(params: Record<string, any> = {}): Promise<Application[]> {
		const query = {};
		const url = await urlHelper('/applications', query);
		let response, data: Application[] = [];
		try {
            response = await fetchWrap(url);		
        } catch {
			response = offlineResponse();
		}
		if (response.ok) {
			data = await response.json() as Application[];
			return data;
		} else {
			throw response;
		}
	},
}
