<template>
    <div class="container">
        <p class="title">Nuevo Permiso</p>
        <form v-bind:class="{ 'was-validated': formValidated }">
            <div class="form-group">
                <label>Nombre</label>
                <input
                    class="form-control"
                    placeholder="Ingrese el nombre"
                    v-model="model.firstnameEmployee"
                    required
                />
            </div>
            <div class="form-group">
                <label>Apellido</label>
                <input
                    class="form-control"
                    placeholder="Ingrese el apellido"
                    v-model="model.lastnameEmployee"
                    required
                />
            </div>
            <div class="form-group">
                <label>Tipo de Permiso</label>
                <select class="form-select" v-model="model.permissionType">
                    <option 
                        v-for="item in permissionTypeList" 
                        v-bind:key="item.id"
                        v-bind:value="item"
                        >
                        {{ item.description }}
                    </option>
                </select>
            </div>
            <div class="form-group">
                <label>Fecha de Solicitud de Permiso</label>
                <input
                    class="form-control"
                    type="date"
                    placeholder="Ingrese el apellido"
                    v-model="model.date"
                    required
                />
            </div>
            <div class="buttons">
                <button 
                    class="btn btn-outline-secondary"
                    type="button" 
                    @click="cancel()"
                    >
                    Cancelar
                </button>
                <button 
                    class="btn btn-outline-primary"
                    type="button" 
                    @click="save()"
                    >
                    Guardar
                </button>
            </div>
        </form>
    </div>
</template>


<script>
    import { PermissionService } from "../../services/permission.service"
    import { PermissionTypeService } from "../../services/permissionType.service"
    import { AppContainer } from '../../infrastructure/appContainer'

    const permissionService = PermissionService()
    const permissionTypeService = PermissionTypeService()

    export default {
        data() {
            return {
                permissionTypeSelected: {},
                permissionTypeList: [],
                model: {
                    firstnameEmployee: '',
                    lastnameEmployee: '',
                    permissionType: {},
                    date: ''
                },
                formValidated: false
            }
        },

        async created() {
            this.permissionTypeList = await permissionTypeService.list()

            this.model.permissionType = this.permissionTypeList[0]
        },

        methods: {
            async save() {
                this.formValidated = true

                if (this.model.firstnameEmployee &&
                    this.model.lastnameEmployee &&
                    this.model.date) {

                    this.formValidated = false

                    const modifyModel = {
                        firstnameEmployee: this.model.firstnameEmployee,
                        lastnameEmployee: this.model.lastnameEmployee,
                        permissionTypeId: this.model.permissionType.id,
                        date: this.model.date
                    }

                    const isCreate = await permissionService.create(modifyModel)

                    if (isCreate.ok) {
                        AppContainer.showToast("Se agrego correctamente el registro.")
                    } else {
                        AppContainer.showToast("Ocurrio un error al agregar.")
                    }

                    this.$router.push(`/`)  
                }
            },
            cancel() {
                this.$router.push(`/`)         
            },
        }
    }
</script>

<style lang="scss" scoped>
    .container {
        max-width: 500px;
    }

    .title {
        text-align: center;
        margin: 30px;
        font-size: 16px;
    }

    label {
        color: #666;
    }

    .form-group {
        margin: 15px;
    }

    .buttons {
        display: flex;
        justify-content: center;
        gap: 20px;
        margin: 40px;
    }
</style>