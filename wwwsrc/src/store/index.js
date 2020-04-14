import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000
  // withCredentials: true
});

export default new Vuex.Store({
  state: {
    game: {},
    savedGames: [],
    currentPlanet: {},
    planets: []
  },
  mutations: {
    setGame(state, newGame) {
      state.game = newGame;
    },
    setSavedGames(state, games) {
      state.savedGames = games;
    },
    setPlanets(state, planets) {
      state.planets = planets;
    },
    setCurrent(state, planet) {
      state.currentPlanet = planet;
    }
  },
  actions: {
    // game methods
    async createGame({ commit, dispatch }, newGame) {
      let res = await api.post("testgame", newGame);
      // dispatch("getGame", res.data.id);
      router.push({ name: "LoadingDashboard", params: { id: res.data.id } });
    },
    async getGame({ commit, dispatch }, id) {
      let res = await api.get("testgame/" + id);
      commit("setGame", res.data);
    },
    async getSavedGames({ commit, dispatch }) {
      let res = await api.get("testgame/all");
      commit("setSavedGames", res.data);
    },
    async purchasePlanet({ commit, dispatch }, purchaseInfo) {
      let res = await api.put("testgame/" + purchaseInfo.currentGame);
      commit("setGame", res.data);
    },
    // planet methods
    async getPlanets({ commit, dispatch }) {
      let res = await api.get("testplanets");
      commit("setPlanets", res.data);
      commit("setCurrent", res.data[0]);
    },
    async unlockPlanets({ commit, dispatch }, unlockedPlanet) {
      await api.put("testplanets/" + unlockedPlanet.planetId, unlockedPlanet);
      dispatch("getPlanets");
    }
  },
  modules: {}
});
