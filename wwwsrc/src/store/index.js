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
    planets: []
  },
  mutations: {
    setGame(state, newGame) {
      state.game = newGame;
    },
    setPlanets(state, planets) {
      state.planets = planets;
    }
  },
  actions: {
    async createGame({ commit, dispatch }, newGame) {
      let res = await api.post("testgame", newGame);
      // dispatch("getGame");
      router.push({ name: "LoadingDashboard", params: { id: res.data.id } });
    },
    async getGame({ commit, dispatch }) {
      let res = await api.get("testgame");
      commit("setGame", res.data);
    },
    async getPlanets({ commit, dispatch }) {
      let res = await api.get("testplanets");
      commit("setPlanets", res.data);
    }
  },
  modules: {}
});
