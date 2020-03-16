<template>
  <div class="createGame container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Let's start a new game</h1>
        <h3>First off, who are you?</h3>
        <h5>Fill out the form below</h5>
      </div>
      <div class="col-6 offset-3">
        <form @submit="createGame">
          <label for="name">Name:</label>
          <br />
          <input type="text" id="name" v-model="name" />
          <br />
          <label for="profile">Profile Image:</label>
          <br />
          <input type="file" id="profile" @change="onFileSelected" />
          <button type="submit">Submit</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "CreateGame",
  data() {
    return {
      newGame: {
        name: "",
        profileImg: null
      }
    };
  },
  methods: {
    onFileSelected(event) {
      this.profileImg = event.target.files[0];
    },
    createGame() {
      this.$store.dispatch("createGame", this.newGame);
      this.newGame = {};
    }
  }
};
</script>

<style>
</style>