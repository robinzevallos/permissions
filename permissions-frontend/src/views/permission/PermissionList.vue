<template>
  <div class="main-container">
    <p class="title">Listado de Permisos</p>
    <table class="table">
    <thead>
      <tr>
        <th scope="col">#</th>
        <th scope="col">Nombre</th>
        <th scope="col">Apellido</th>
        <th scope="col">Tipo Permiso</th>
        <th scope="col">Fecha de Solicitud de Permiso</th>
        <th scope="col"></th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(item, index) in listPermission" v-bind:key="item.id">
        <td scope="row">{{ index + 1 }}</td>
        <td>{{ item.firstnameEmployee }}</td>
        <td>{{ item.lastnameEmployee }}</td>
        <td>{{ item.permissionType.description }}</td>
        <td>{{ new Date(item.date).toLocaleDateString() }}</td>
        <td>
          <div class="buttons">
            <button 
              class="btn btn-outline-success"
              type="button" 
              @click="edit(item.id)"
              >
              Editar
          </button>
          <button 
              class="btn btn-outline-danger"
              type="button" 
              @click="remove(item.id)"
              >
              Eliminar
          </button>
          </div>    
        </td>
      </tr>
    </tbody>
    </table>
    <button 
      class="btn btn-outline-primary"
      type="button" 
      @click="add()"
      >
      Agregar
    </button>  
  </div>
</template>

<script>
  import { PermissionService } from "../../services/permission.service"
  import { AppContainer } from '../../infrastructure/appContainer'

  const permissionService = PermissionService()

  export default {
    data() {
      return {
        listPermission: [],
      }
    },

    created() {
      this.setListPermission()
    },

    methods: {
      async setListPermission() {
        this.listPermission = await permissionService.list()
      },

      add() {
        this.$router.push(`/permission-create`)
      },

      edit(id) {
        this.$router.push(`/permission-edit/${id}`)
      },

      async remove(id) {
        const isConfirm = confirm("¿Está seguro de querer eliminar el registro?")

        if (!isConfirm) return

        const isRemove = await permissionService.remove(id)

        if (isRemove.ok) {
            AppContainer.showToast("Se eliminó correctamente el registro.")
        } else {
            AppContainer.showToast("Ocurrio un error al eliminar.")
        }

        this.setListPermission()
      },
    }
  }
</script>

<style lang="scss" scoped>
    .main-container {
      max-width: 900px;
      margin: 0 auto;
    }

    .title {
        text-align: center;
        margin: 30px;
        font-size: 22px;
    }

    .btn-outline-primary {
      margin-top: 10px;
    }

    .buttons {
        display: flex;
        justify-content: center;
        gap: 20px;
    }
    
</style>