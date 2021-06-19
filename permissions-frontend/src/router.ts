import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const routes = [
    {
        path: "/",
        name: "Persmission",
        component: () =>
            import("./views/permission/PermissionList.vue"),
    },
    {
        path: '/permission-edit/:id',
        name: "PersmissionEdit",
        component: () =>
            import("./views/permission/PermissionEdit.vue"),
            
    },
    {
        path: '/permission-create',
        name: "PersmissionCreate",
        component: () =>
            import("./views/permission/PermissionCreate.vue"),
            
    },
];

const router = new VueRouter({
    mode: "history",
    routes,
});

export default router;