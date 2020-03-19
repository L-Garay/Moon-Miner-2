<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Welcome to your dashboard</h1>
        {{game}}
      </div>
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

<style>
</style>