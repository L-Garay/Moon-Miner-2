import Vue from "vue";
import Router from "vue-router";
import Home from "../views/Home.vue";
import LoadingNew from "../views/LoadingScreens/LoadingNew.vue";
import Dashboard from "../views/Dashboard.vue";
import CreateGame from "../views/CreateGame.vue";
import LoadingDashboard from "../views/LoadingScreens/LoadingDashboard.vue";
import Upgrades from "../views/Upgrades.vue";
import Market from "../views/MarketView.vue";

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
    },
    {
      path: "/creategame",
      name: "CreateGame",
      component: CreateGame
    },
    {
      path: "/loadingdashboard/:id",
      name: "LoadingDashboard",
      component: LoadingDashboard
    },
    {
      path: "/dashboard/:id",
      name: "Dashboard",
      component: Dashboard
    },
    {
      path: "/upgrades/:id",
      name: "Upgrades",
      component: Upgrades
    },
    {
      path: "/market/:id",
      name: "MarketView",
      component: Market
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
