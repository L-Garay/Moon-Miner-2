<template>
  <div class="col-12" style="text-align: -webkit-center;">
    <div class="gameSection">
      <div class="name">
        <i class="fas fa-arrow-circle-left fa-2x" @click="previousPlanet"></i>
        <h1>{{ currentPlanet.planetName }}</h1>
        <i class="fas fa-arrow-circle-right fa-2x" @click="nextPlanet"></i>
      </div>
      <div class="playSection">
        <button @click="unlockPlanet">Unlock Planet</button>
        <div>
          <img
            :src="currentPlanet.planetImg"
            class="planetImg"
            alt="should be planet"
          />
          <div v-if="isLocked" class="over-shadow" id="shadow"></div>
          <i v-if="isLocked" class="fas fa-lock fa-7x over-img" id="lock"></i>
        </div>
        <button>Begin Expidition</button>
      </div>
    </div>
    <div class="planetInfo">
      <div>
        <p>
          <b>Planet Information</b>
        </p>
      </div>
      <div class="stats">
        <p>Money needed to unlock: {{ currentPlanet.moneyNeeded }}</p>
        <p>Expidition energy cost: {{ currentPlanet.expiditionCost }}</p>
        <p>Resource 1 estimate: {{ currentPlanet.resource1 }}</p>
        <p>Resource 2 estimate: {{ currentPlanet.resource2 }}</p>
        <p>Resource 3 estimate: {{ currentPlanet.resource3 }}</p>
        <p>Resource 4 estimate: {{ currentPlanet.resource4 }}{{ planets }}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'PlanetInfo',
  props: ['moreGameData'],
  data: function() {
    return {
      current: {},
      isLocked: null,
    };
  },
  methods: {
    previousPlanet() {
      let lastIndex = this.$store.state.planets.length - 1;
      if (
        this.$store.state.currentPlanet.id == this.$store.state.planets[0].id
      ) {
        this.$store.state.currentPlanet = this.$store.state.planets[lastIndex];
      } else {
        let newIndex = this.current.id - 2;
        this.$store.state.currentPlanet = this.$store.state.planets[newIndex];
      }
    },
    nextPlanet() {
      let lastIndex = this.$store.state.planets.length - 1;
      if (
        this.$store.state.currentPlanet.id ==
        this.$store.state.planets[lastIndex].id
      ) {
        this.$store.state.currentPlanet = this.$store.state.planets[0];
      } else {
        let newIndex = this.current.id;
        this.$store.state.currentPlanet = this.$store.state.planets[newIndex];
      }
    },
    checkLocked() {
      if (this.$store.state.currentPlanet.isLocked) {
        this.isLocked = true;
      } else {
        this.isLocked = false;
      }
    },
    checkMoney() {
      if (this.$store.state.game.playerMoney < this.current.moneyNeeded) {
        return false;
      } else if (
        this.$store.state.game.playerMoney >= this.current.moneyNeeded
      ) {
        return true;
      }
    },
    unlockPlanet() {
      if (this.current.isLocked) {
        this.checkMoney();
        if (this.checkMoney()) {
          let updatedMoney =
            this.$store.state.game.playerMoney - this.current.moneyNeeded;
          this.$store.state.game.playerMoney = updatedMoney;
          let currentId = this.$store.state.currentPlanet.id;
          this.$store.state.game.planetId = currentId;
          this.$store.dispatch('unlockPlanet', this.$store.state.currentPlanet);
          this.$store.dispatch('updateGame', this.$store.state.game);
        } else {
          // NOTE trigger window pop up saying they don't have enough money
        }
      } else {
        return;
      }
    },
    findLastUnlocked() {
      let planetId = this.$store.state.game.planetId;
      console.log(planetId);
      this.$store.dispatch('setCurrentPlanet', planetId);
    },
  },
  mounted() {
    this.$store.dispatch('getPlanets');
    // this.checkLocked();
  },
  computed: {
    planets() {
      console.log('WORKS SO FAR');
      this.findLastUnlocked();
      console.log('WJWJWJ');
      return this.$store.state.planets;
    },
    currentPlanet() {
      this.current = this.$store.state.currentPlanet;
      this.checkLocked();
      return this.$store.state.currentPlanet;
    },
  },
};
</script>

<style scoped>
.gameSection {
  display: flex;
  flex-direction: column;
}
/* Planet Name and navigation */
.name {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: row;
  margin-bottom: 40pt;
}
.name h1 {
  padding: 0 15pt 0 15pt;
}
i.fa-2x:hover {
  cursor: pointer;
}

/* Picture and play buttons */
.planetImg {
  height: 500px;
  width: 550px;
  position: relative;
}
.over-img {
  position: absolute;
  top: 300px;
  left: 490px;
  color: gold;
}
.over-shadow {
  position: absolute;
  background-color: rgb(0, 0, 0, 0.6);
  height: 500px;
  width: 517px;
  top: 100px;
  left: 275px;
}
.playSection {
  display: flex;
  justify-content: center;
  align-items: center;
}
.playSection button {
  height: 70px;
  width: 100px;
}

/* Planet Information */
.planetInfo {
  border: 1pt solid black;
  width: 50%;
}
.planetInfo b {
  border-bottom: 1pt solid red;
}
.stats {
  text-align: start;
  padding-left: 10pt;
}
</style>
