import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';
import router from '../router';

Vue.use(Vuex);

let baseUrl = location.host.includes('localhost:8080')
  ? 'https://localhost:5001/'
  : '/';

let api = axios.create({
  baseURL: baseUrl + 'api/',
  timeout: 3000,
  // withCredentials: true
});

export default new Vuex.Store({
  state: {
    game: {},
    savedGames: [],
    currentPlanet: {},
    planets: [],
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
    },
    setPurchasedCurrent(state, planet) {
      state.currentPlanet = planet;
    },
  },
  actions: {
    // game methods
    async createGame({ commit, dispatch }, newGame) {
      let res = await api.post('testgame', newGame);
      // dispatch("getGame", res.data.id);
      router.push({ name: 'LoadingDashboard', params: { id: res.data.id } });
    },
    async getGame({ commit, dispatch }, id) {
      let res = await api.get('testgame/' + id);
      commit('setGame', res.data);
    },
    async getSavedGames({ commit, dispatch }) {
      let res = await api.get('testgame/all');
      commit('setSavedGames', res.data);
    },
    async deleteGameById({ commit, dispatch }, gameId) {
      console.log('game id being sent to sserver', gameId);
      await api.delete('testgame/' + gameId);
      // dispatch('getSavedGames');
    },
    async updateGame({ commit, dispatch }, updatedGame) {
      let res = await api.put('testgame/' + updatedGame.id, updatedGame);
      commit('setGame', res.data);
    },

    // planet methods
    async getPlanets({ commit, dispatch }) {
      let res = await api.get('testplanets');
      debugger;
      commit('setPlanets', res.data);
      // commit('setCurrent', res.data[0]);
    },
    async setCurrentPlanet({ commit, dispatch }, planetId) {
      let res = await api.get('testplanets/' + planetId);
      debugger;
      let unlocked = await api.put('testplanets/' + planetId, res.data);
      commit('setCurrent', unlocked);
    },
    async unlockPlanet({ commit, dispatch }, planet) {
      let res = await api.put('testplanets/' + planet.id, planet);
      // NOTE totally some WET Code, but I need to do it here to update the planets array without calling getPlanets which is used on first page load and will always set current to first planet; when I want the unlocked planet to be the current after purchasing
      let planets = await api.get('testplanets');
      commit('setPurchasedCurrent', res.data);
      commit('setPlanets', planets.data);
    },
  },
  modules: {},
});
