<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-6 offset-3">
        <img src="../assets/Moons/moon1.png" alt="should be a moon" />
      </div>
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
          >Load Games</button>
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
                <div class="col-8">
                  <p
                    v-for="game in games"
                    :key="game.id"
                  >{{game.playerName}}.....${{game.playerMoney}}</p>
                </div>
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
  name: "Home",
  mounted() {
    this.$store.dispatch("getSavedGames");
  },
  computed: {
    games() {
      return this.$store.state.savedGames;
    }
  }
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
</style>
