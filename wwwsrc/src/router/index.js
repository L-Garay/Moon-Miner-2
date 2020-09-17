import Vue from 'vue';
import Router from 'vue-router';
// @ts-ignore
import Home from '../views/Home.vue';
// @ts-ignore
import LoadingNew from '../views/LoadingScreens/LoadingNew.vue';
// @ts-ignore
import LoadingDashboard from '../views/LoadingScreens/LoadingDashboard.vue';
// @ts-ignore
import LoadingMainMenu from '../views/LoadingScreens/LoadingMainMenu.vue';
// @ts-ignore
import Dashboard from '../views/Dashboard.vue';
// @ts-ignore
import CreateGame from '../views/CreateGame.vue';
// @ts-ignore
import Upgrades from '../views/Upgrades.vue';
// @ts-ignore
import Market from '../views/MarketView.vue';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home,
    },
    {
      path: '/loadingnew',
      name: 'LoadingNew',
      component: LoadingNew,
    },
    {
      path: '/loadingdashboard/:id',
      name: 'LoadingDashboard',
      component: LoadingDashboard,
    },
    {
      path: '/loadingmainmenu',
      name: 'LoadingMainMenu',
      component: LoadingMainMenu,
    },
    {
      path: '/creategame',
      name: 'CreateGame',
      component: CreateGame,
    },
    {
      path: '/dashboard/:id',
      name: 'Dashboard',
      component: Dashboard,
    },
    {
      path: '/upgrades/:id',
      name: 'Upgrades',
      component: Upgrades,
    },
    {
      path: '/market/:id',
      name: 'MarketView',
      component: Market,
    },
  ],
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
