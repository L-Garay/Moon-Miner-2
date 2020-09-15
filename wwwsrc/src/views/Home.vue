<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-md-6 offset-md-3">
        <img
          src="../assets/Moons/moon1.png"
          class="img-fluid"
          alt="should be a moon"
        />
      </div>
    </div>
    <div class="row">
      <div class="col-12 welcome">
        <h1>Welcome to Moon Miner 2.0</h1>
        <div class="buttons">
          <router-link to="LoadingNew">
            <div class="btn">Start New Game</div>
          </router-link>
          <button
            type="button"
            class="btn"
            data-toggle="modal"
            data-target=".bd-example-modal-lg"
          >
            Load Games
          </button>
        </div>
      </div>
    </div>
    <div
      class="modal fade bd-example-modal-lg"
      tabindex="-1"
      role="dialog"
      aria-labelledby="myLargeModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered modal-lg">
        <div class="modal-content">
          <div class="container-fluid">
            <div class="row">
              <div class="col-12">
                <h2>Select a saved game</h2>
              </div>
              <div class="col-8 offset-2">
                <ol v-if="savedGames">
                  <div v-for="game in games" :key="game.id" class="p-1">
                    <li>{{ game.playerName }}.....${{ game.playerMoney }}</li>
                    <button
                      type="button"
                      @click="loadGame(game.id)"
                      class="btn btn-sm loadBtn"
                    >
                      Load Game
                    </button>
                    <button
                      type="button"
                      @click="deleteGameById(game.id)"
                      class="btn btn-sm deleteBtn"
                    >
                      Delete Game
                    </button>
                  </div>
                  <!-- <li v-for="game in games" :key="game.id">
                    {{ game.playerName }}.....${{ game.playerMoney }}
                    <button
                      type="button"
                      @click="loadGame(game.id)"
                      class="btn btn-sm loadBtn"
                    >
                      Load Game
                    </button>
                    <button
                      type="button"
                      @click="deleteGameById(game.id)"
                      class="btn btn-sm deleteBtn"
                    >
                      Delete Game
                    </button>
                  </li> -->
                </ol>
                <p v-else>
                  Looks like you don't have any games saved yet, what are you
                  waiting for? Get mining!
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src

export default {
  name: 'Home',
  data() {
    return {
      savedGames: true,
    };
  },
  mounted() {
    // this.$store.dispatch('getSavedGames');
    this.getSavedGames();
  },
  computed: {
    games() {
      return this.$store.state.savedGames;
    },
  },
  methods: {
    async getSavedGames() {
      await this.$store.dispatch('getSavedGames');
      if (this.$store.state.savedGames.length > 0) {
        this.savedGames = true;
      } else if (this.$store.state.savedGames.length === 0) {
        this.savedGames = false;
      }
    },
    loadGame(gameId) {
      // this.$store.dispatch("loadGame", id);
      this.$router.push({ name: 'LoadingDashboard', params: { id: gameId } });
    },
    async deleteGameById(gameId) {
      await this.$store.dispatch('deleteGameById', gameId);
      this.getSavedGames();
    },
  },
};
</script>

<style scoped>
.home {
  height: 100vh;
  width: 100vw;
  display: flex;
  flex-direction: column;
  align-content: center;
  justify-content: center;
}
img {
  height: 500px;
  width: 500px;
}
.buttons {
  justify-content: space-around;
  flex-direction: column;
  display: inline-flex;
  margin: 5pt;
}
.btn {
  border: 1pt solid gold;
  margin: 10pt;
  padding: 10pt;
}

.btn.loadBtn {
  font-size: x-small;
  margin: 1pt;
  padding: 3pt;
  color: white;
  background-color: seagreen;
}
.btn.deleteBtn {
  font-size: x-small;
  margin: 1pt;
  padding: 3pt;
  color: white;
  background-color: red;
}

li:hover {
  cursor: pointer;
}
</style>
