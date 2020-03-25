<template>
  <div class="col-12" style="text-align: -webkit-center;">
    <div class="gameSection">
      <div class="name">
        <i class="fas fa-arrow-circle-left fa-2x"></i>
        <h1>Planet Name</h1>
        <i class="fas fa-arrow-circle-right fa-2x"></i>
      </div>
      <div class="playSection">
        <button>Unlock Planet</button>
        <img src="../assets/Planets/earthlike.png" alt="should be planet" />
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
        <p>Money needed to unlock:</p>
        <p>Expidition energy cost:</p>
        <p>Resource 1 estimate:</p>
        <p>Resource 2 estimate:</p>
        <p>Resource 3 estimate:</p>
        <p>Resource 4 estimate:</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "PlanetInfo"
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
i:hover {
  cursor: pointer;
}

/* Picture and play buttons */
img {
  max-height: 500px;
  max-width: 650px;
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