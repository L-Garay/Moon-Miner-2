<template>
  <div class="dashboard container-fluid">
    <div class="row side">
      <div class="col-7" id="profile">
        <div class="topProfile">
          <div>
            <img :src="game.profileImg" alt="should just be text" />
          </div>
          <div>
            <h3>{{game.playerName}}</h3>
            <p>This will be player xp</p>
          </div>
        </div>
        <div class="seperator"></div>
        <div class="bottomProfile">
          <p>Player Money: {{game.playerMoney}}</p>
          <p>Player Resource1:</p>
          <p>Player Resource2:</p>
          <p>Player Resource3:</p>
          <p>Player Resource4:</p>
          <p>Current Player Tool:</p>
          <p>Player Energy:</p>
        </div>
      </div>
      <div class="col-3">
        <button>Upgrades</button>
      </div>
    </div>
    <div class="row middle">
      <div class="col-12">
        <h3>Planet Area</h3>
      </div>
    </div>
    <div class="row side">
      <div class="col-4">Market tab</div>
      <div class="col-4">Stats tab</div>
    </div>
  </div>
</template>

<script>
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

/* Individual sections */

/* Profile Section */
.col-7#profile {
  border: solid 1pt black;
  width: 350px;
  max-width: 350px !important;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  align-items: center;
}
.topProfile {
  display: flex;
  align-items: center;
  text-align: start;
}
.topProfile img {
  height: 150px;
  width: 150px;
  margin-right: 8px;
}
.seperator {
  width: 75%;
  height: 1px;
  border-top: 3px solid red;
}
.bottomProfile {
  text-align: start;
  align-self: flex-start;
}
</style>