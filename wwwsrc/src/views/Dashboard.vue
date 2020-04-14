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
      <planet :moreGameData="game" />
    </div>
    <div class="row side">
      <market />
      <div class="col-4">Stats tab</div>
    </div>
  </div>
</template>

<script>
import Profile from "@/components/ProfileSection.vue";
import Market from "@/components/Market.vue";
import Planet from "@/components/PlanetInfo.vue";
export default {
  name: "Dashboard",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getGame", this.$route.params.id);
    $("body").removeClass("modal-open");
    $(".modal-backdrop").remove();
    // this.$store.dispatch("getPlanets");
  },
  computed: {
    game() {
      return this.$store.state.game;
    }
    // planets() {
    //   return this.$store.state.planets;
    // }
  },
  components: {
    Profile,
    Market,
    Planet
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