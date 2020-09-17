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
        <p>Resource 4 estimate: {{ currentPlanet.resource4 }}</p>
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
      isLocked: false,
      neverShow: false,
    };
  },
  mounted() {
    // this.$store.dispatch('getGame', this.moreGameData.id);
    this.findLastUnlocked();
  },
  computed: {
    // planets() {
    //   return this.$store.state.planets;
    //   // NOTE for some reason I have to invoke or call 'planets' within the template, otherwise I'm unable to access the 'findLastUnlocked' method. So I have put my invocation within a v-show element, and ensured it will never show to the user, but therefore I can still access the method.
    // },
    currentPlanet() {
      this.checkLocked();
      return this.$store.state.currentPlanet;
    },
  },
  methods: {
    previousPlanet() {
      let lastIndex = this.$store.state.planets.length - 1;
      if (
        this.$store.state.currentPlanet.id == this.$store.state.planets[0].id
      ) {
        this.$store.state.currentPlanet = this.$store.state.planets[lastIndex];
        this.checkLocked();
      } else {
        let newIndex = this.$store.state.currentPlanet.id - 2;
        this.$store.state.currentPlanet = this.$store.state.planets[newIndex];
        this.checkLocked();
      }
    },
    nextPlanet() {
      let lastIndex = this.$store.state.planets.length - 1;
      if (
        this.$store.state.currentPlanet.id ==
        this.$store.state.planets[lastIndex].id
      ) {
        this.$store.state.currentPlanet = this.$store.state.planets[0];
        this.checkLocked();
      } else {
        let newIndex = this.$store.state.currentPlanet.id;
        this.$store.state.currentPlanet = this.$store.state.planets[newIndex];
        this.checkLocked();
      }
    },
    checkLocked() {
      if (this.$store.state.currentPlanet.isLocked) {
        this.isLocked = true;
      } else {
        this.isLocked = false;
      }
    },
    unlockPlanet() {
      if (this.$store.state.currentPlanet.isLocked) {
        this.checkMoney();
        if (this.checkMoney()) {
          // calculates player's new money total
          let updatedMoney =
            this.$store.state.game.playerMoney -
            this.$store.state.currentPlanet.moneyNeeded;
          this.$store.state.game.playerMoney = updatedMoney;
          // set's whatever planet id the player just unlocked as the game's latest planet (planetId)
          let currentId = this.$store.state.currentPlanet.id;
          this.$store.state.game.planetId = currentId;
          // this will access the planet's server/database and update the isLocked property AND
          this.$store.dispatch('unlockPlanet', this.$store.state.currentPlanet);
          this.$store.dispatch('getPlanets');
          // will access the game's server/database and update the player's money total and planetId
          this.$store.dispatch('updateGame', this.$store.state.game);
        } else {
          // NOTE trigger window pop up saying they don't have enough money
        }
      } else {
        return;
      }
    },
    checkMoney() {
      if (
        this.$store.state.game.playerMoney <
        this.$store.state.currentPlanet.moneyNeeded
      ) {
        return false;
      } else if (
        this.$store.state.game.playerMoney >=
        this.$store.state.currentPlanet.moneyNeeded
      ) {
        return true;
      }
    },
    async findLastUnlocked() {
      await this.$store.dispatch('getPlanets');
      // NOTE the if statement is to basically provide a safety net and ensure that if for some reason the app gets here before the game is set in the store, this will make another call and try to set the game before unlocking planets (which the planetId from the game is necessary to do so)
      // debugger;
      if (!this.$store.state.game.planetId) {
        await this.$store.dispatch('getGame', this.$route.params.id);
        let planetId = this.$store.state.game.planetId;
        let planetsArr = this.$store.state.planets;

        planetsArr.forEach((planet) => {
          if (planet.id <= planetId) {
            this.$store.dispatch('unlockPlanet', planet);
            console.log(
              'this is the planet that should be getting unlocked',
              planet
            );
            this.$store.dispatch('getPlanets');
          } else {
            return;
          }
        });
      } else {
        // NOTE this is the exact same code (definetely some WET code) but this will be run if the game is already set by the time the app gets here
        let planetId = this.$store.state.game.planetId;
        let planetsArr = this.$store.state.planets;

        planetsArr.forEach((planet) => {
          if (planet.id <= planetId) {
            this.$store.dispatch('unlockPlanet', planet);
            console.log(
              'this is the planet that should be getting unlocked',
              planet
            );
            this.$store.dispatch('getPlanets');
          } else {
            return;
          }
        });
      }
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
