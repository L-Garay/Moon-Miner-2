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
});

export default new Vuex.Store({
  state: {
    game: {}
  },
  mutations: {},
  actions: {
    async createGame({ commit, dispatch }, newGame) {
      await api;
    }
  },
  modules: {}
});
