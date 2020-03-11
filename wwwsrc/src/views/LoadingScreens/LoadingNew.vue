<template>
  <div class="loading container-fluid">
    <div class="row">
      <div class="col-12 words">
        <h1>LoadingNew...</h1>
      </div>
    </div>
    <div class="row animation">
      <div>Loading animation will go here</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "LoadingNew",
  // methods: {
  //   routerPush() {
  //     router.push({ path: "/dashboard" });
  //   }
  // },
  mounted() {
    setTimeout(() => {
      this.$router.push({ path: "/dashboard" });
    }, 5000);
  }
};
</script>

<style>
</style>