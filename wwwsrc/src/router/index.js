import Vue from "vue";
import Router from "vue-router";
import Home from "../views/Home.vue";
import LoadingNew from "../views/LoadingScreens/LoadingNew.vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "Home",
      component: Home
    },
    {
      path: "/loadingnew",
      name: "LoadingNew",
      component: LoadingNew
    }
  ]
});
// const routes = [
//   {
//     path: "/",
//     name: "Home",
//     component: Home
//   }
// ];

// const router = new VueRouter({
//   mode: "history",
//   base: process.env.BASE_URL,
//   routes
// });

// export default router;
