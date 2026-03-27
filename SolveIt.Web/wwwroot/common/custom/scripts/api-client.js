import { Loading } from './loading.js';

export const ApiClient = {

/**
 * @template T
 * @param {string} url
 * @param {object|null} params
 * @returns {Promise<OperationResult<T>>}
 */

    async get(url, params = null, selector = 'body') {

        Loading.start(selector);

        if (params) {
            const query = new URLSearchParams(params).toString();
            url = `${url}?${query}`;
        }

        const response = await fetch(url, {
            method: 'GET'
        });

        const result = await response.json();

        Loading.stop(selector);

        return result;
    },

    async post(url, params = null, selector = 'body') {

        Loading.start(selector);

        if (params) {
            const query = new URLSearchParams(params).toString();
            url = `${url}?${query}`;
        }

        const response = await fetch(url, {
            method: 'POST'
        });

        const result = await response.json();

        Loading.stop(selector);

        return result;
    }
};
