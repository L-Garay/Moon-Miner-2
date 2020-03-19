<template>
  <div class="dashboard container-fluid">
    <div class="row side">
      <div class="col-7">
        <h1>Profile Section</h1>
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
</style>