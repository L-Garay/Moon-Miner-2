import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

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
    game: {}
  },
  mutations: {
    setGames(state, newGame) {
      state.game = newGame;
    }
  },
  actions: {
    async createGame({ commit, dispatch }, newGame) {
      debugger;
      await api.post("testgame", newGame);
      dispatch("getGames");
    },
    async getGames({ commit, dispatch }) {
      let res = await api.get("testgame");
      commit("setGames", res.data);
    }
  },
  modules: {}
});
