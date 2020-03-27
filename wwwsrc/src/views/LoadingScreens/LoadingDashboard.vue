<template>
  <div class="loading container-fluid">
    <div class="row">
      <div class="col-12 words">
        <h1>Loading Dashboard...</h1>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <img src="../../assets/pickaxe.png" class="moveMe" alt="should be axe" />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "LoadingDashboard",
  mounted() {
    let gameId = this.$route.params.id;
    setTimeout(() => {
      this.$router.push({ name: "Dashboard", params: { id: gameId } });
    }, 3000);
    $("body").removeClass("modal-open");
    $(".modal-backdrop").remove();
  }
};
</script>

<style scoped>
img {
  height: 300px;
  width: 300px;
  animation-name: axe;
  animation-duration: 6s;
  animation-direction: alternate;
  animation-iteration-count: infinite;
  float: left;
}
@keyframes axe {
  0% {
    transform: translate(0px);
  }
  10% {
    transform: translate(350px);
  }
  20% {
    transform: translate(700px);
  }
  30% {
    transform: translate(1050px);
  }
  40% {
    transform: translate(1400px);
  }
  50% {
    transform: translate(1800px);
  }
  60% {
    transform: translate(1400px);
  }
  70% {
    transform: translate(1050px);
  }
  80% {
    transform: translate(700px);
  }
  90% {
    transform: translate(350px);
  }
  100% {
    transform: translate(0);
  }
}
</style>