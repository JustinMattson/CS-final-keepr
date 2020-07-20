import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
// import KeepDetails from "./views/KeepDetails.vue";
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
    },
    // REVIEW if time permits, add a KeepDetails vue.
    // {
    //   path: "/:keepId",
    //   name: "keepdetails",
    //   component: Home,
    // },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard,
      beforeEnter: authGuard,
    },
    // REVIEW if time permits, make a separate vue for vaults and keeps.
    // {
    //   path: "/dashboard/vaults",
    //   name: "myVaults",
    //   component: Dashboard,
    //   beforeEnter: authGuard,
    // },
    // {
    //   path: "/dashboard/keeps",
    //   name: "myKeeps",
    //   component: Dashboard,
    //   beforeEnter: authGuard,
    // },
  ],
});
