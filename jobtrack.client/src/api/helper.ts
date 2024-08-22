import { DateTime } from 'luxon';

const APP_URL_ORIGIN = import.meta.env.VITE_APP_API_DEV_URL;

export function offlineResponse() {
	return new Response(null, { status: 503, statusText: 'Offline' });
}

export async function url(path: string, query: Record<string, any>) {
	let url = new URL(path, APP_URL_ORIGIN);
	for (const key in query) {
		if (Object.hasOwnProperty.call(query, key)) {
			let value = query[key];
			if (value instanceof DateTime) {
				value = value.isValid ? value.toISODate() : null;
			}
			if (value === null || value === undefined) {
				url.searchParams.delete(key);
			} else {
				url.searchParams.set(key, value);
			}
		}
	}
	return url;
}

export async function fetchWrap(url: string | URL, init?: RequestInit): Promise<Response> {
    url = new URL(url, APP_URL_ORIGIN);
	const response = await fetch(url, init);
	return response;
}