<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-6 offset-3">
        <img src="../assets/Moons/moon1.png" alt="should be a moon" />
      </div>
      <div class="col-12 welcome">
        <h1>Welcome to Moon Miner 2.0</h1>
        <div class="buttons">
          <router-link to="LoadingNew">
            <div class="btn">Start New Game</div>
          </router-link>
          <div class="btn">Load Saved Game</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src

export default {
  name: "Home"
};
</script>

<style scoped>
.home {
  height: 100vh;
  width: 100vw;
  display: flex;
  flex-direction: column;
  align-content: center;
  justify-content: center;
}
img {
  height: 500px;
  width: 500px;
}
.buttons {
  justify-content: space-around;
  flex-direction: column;
  display: inline-flex;
  margin: 5pt;
}
.btn {
  border: 1pt solid gold;
  margin: 10pt;
  padding: 10pt;
}
</style>
