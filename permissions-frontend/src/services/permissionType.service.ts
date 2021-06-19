import { environment } from "../enviroments/enviroment";

export function PermissionTypeService() {
    const BASE_URL = environment.serviceApiEndPoint;

    return {
        async list() {
            const response = await fetch(`${BASE_URL}/permissionTypes`)
            return await response.json()
        }
    }
}

