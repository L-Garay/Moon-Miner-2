<template>
  <div class="dashboard container-fluid">
    <div class="row side">
      <profile :gameData="game" />
      <div class="col-3">
        <router-link id="upgradeBtn" :to="{name: 'Upgrades', params: {id: game.id}}">
          <button>Upgrades</button>
        </router-link>
      </div>
    </div>
    <div class="row middle">
      <div class="col-8 gameSection">
        <div class="name">
          <i class="fas fa-arrow-circle-left fa-2x"></i>
          <h1>Planet Name</h1>
          <i class="fas fa-arrow-circle-right fa-2x"></i>
        </div>
        <div class="playSection">
          <button>Unlock Planet</button>
          <img src="../assets/Planets/earthlike.png" alt="should be planet" />
          <button>Begin Expidition</button>
        </div>
      </div>
      <div class="col-3 planetInfo">
        <div>
          <p>
            <b>Planet Information</b>
          </p>
        </div>
        <div class="stats">
          <p>Money needed to unlock:</p>
          <p>Expidition energy cost:</p>
          <p>Resource 1 estimate:</p>
          <p>Resource 2 estimate:</p>
          <p>Resource 3 estimate:</p>
          <p>Resource 4 estimate:</p>
        </div>
      </div>
    </div>
    <div class="row side">
      <market :moreGameData="game" />
      <div class="col-4">Stats tab</div>
    </div>
  </div>
</template>

<script>
import Profile from "@/components/ProfileSection.vue";
import Market from "@/components/Market.vue";
export default {
  name: "Dashboard",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getGame");
  },
  computed: {
    game() {
      return this.$store.state.game;
    }
  },
  components: {
    Profile,
    Market
  }
};
</script>

<style scoped>
/* Overall page layout */
.dashboard {
  display: flex;
  height: 100vh;
}
.row {
  flex-direction: column;
  align-content: center;
}
.side {
  width: 25vw;
  justify-content: space-around;
}
.middle {
  width: 50vw;
}
.name {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-bottom: 40pt;
}
.name h1 {
  padding: 0 15pt 0 15pt;
}
i:hover {
  cursor: pointer;
}
img {
  max-height: 600px;
  max-width: 650px;
}
.playSection {
  display: flex;
  flex-direction: row;
  align-items: center;
}
.playSection button {
  height: 70px;
  width: 100px;
}
.planetInfo {
  border: 1pt solid black;
  align-self: center;
}
.planetInfo b {
  border-bottom: 1pt solid red;
}
.stats {
  text-align: start;
}

/* Individual sections */
</style>