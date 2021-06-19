import { environment } from "../enviroments/enviroment";

export function PermissionService() {
    const BASE_URL = environment.serviceApiEndPoint;

    return {
        async list() {
            const response = await fetch(`${BASE_URL}/permissions`)
            return await response.json()
        },

        async byId(id: number) {
            const response = await fetch(`${BASE_URL}/permissions/${id}`)
            return await response.json()
        },

        async create(data: any) {
            const response = await fetch(`${BASE_URL}/permissions`, {
                method: 'POST',
                body: JSON.stringify(data),
                headers: {
                    'Content-type': 'application/json'
                }
            })

            return response
        },

        async update(data: any) {
            const response = await fetch(`${BASE_URL}/permissions`, {
                method: 'PUT',
                body: JSON.stringify(data),
                headers: {
                    'Content-type': 'application/json'
                }
            })

            return response
        },

        async remove(id: number) {
            const response = await fetch(`${BASE_URL}/permissions/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-type': 'application/json'
                }
            })

            return response
        },
    }
}

