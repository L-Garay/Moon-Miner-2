<template>
  <div class="col-7" id="profile">
    <div class="topProfile">
      <div>
        <img :src="gameData.profileImg" alt="should just be text" />
      </div>
      <div>
        <h3>{{gameData.playerName}}</h3>
        <p>This will be player xp</p>
      </div>
    </div>
    <div class="seperator"></div>
    <div class="bottomProfile">
      <p>Player Money: {{gameData.playerMoney}}</p>
      <p>Player Resource1:</p>
      <p>Player Resource2:</p>
      <p>Player Resource3:</p>
      <p>Player Resource4:</p>
      <p>Current Player Tool:</p>
      <p>Player Energy:</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "ProfileSection",
  props: ["gameData"],
  data() {
    return {};
  }
};
</script>

<style scoped>
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