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
import Profile from "@/components/ProfileSection.vue";
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
    Profile
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
</style>