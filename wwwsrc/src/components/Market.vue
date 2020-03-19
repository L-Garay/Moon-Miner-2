<template>
  <div class="col-5" id="market">
    <h2>Market</h2>
    <div class="seperator"></div>
    <div class="sections">
      <div class="S1 mb-2">
        <p>Resource Name:</p>
        <p>SellingPrice: $</p>
      </div>
      <div class="S2 mb-2">
        <p>Resource Name:</p>
        <p>SellingPrice: $</p>
      </div>
    </div>
    <router-link id="marketBtn" :to="{name: 'MarketView', params: {id: moreGameData.id}}">
      <button>Go to Market</button>
    </router-link>
  </div>
</template>

<script>
export default {
  name: "Market",
  props: ["moreGameData"],
  data() {
    return {};
  }
};
</script>

<style scoped>
.col-5#market {
  border: 2px solid black;
  background-color: sandybrown;
  width: 400px;
  max-width: 400px;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding-top: 5pt;
}
.sections {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}
.sections div {
  border: 1px solid black;
  width: 300px;
  height: 150px;
  color: black;
  display: flex;
  flex-direction: column;
  justify-content: center;
  text-align: left;
  padding-left: 8pt;
}
.S1 {
  background-color: aquamarine;
}
.S2 {
  background-color: lightblue;
}
.seperator {
  width: 75%;
  height: 1px;
  border-top: 3px solid lightseagreen;
  margin-bottom: 10pt;
}
button {
  margin-bottom: 5pt;
}
</style>