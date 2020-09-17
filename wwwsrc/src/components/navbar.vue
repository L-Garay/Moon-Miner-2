<template>
  <nav
    v-if="
      ['CreateGame', 'Dashboard', 'Upgrades', 'MarketView'].indexOf(
        $route.name
      ) > -1
    "
    class="navbar navbar-expand-lg navbar-light bg-light"
  >
    <h2 class="title">MoonMiner</h2>
    <div class="collapse navbar-collapse" id="navbarNavDropdown">
      <ul class="navbar-nav">
        <li class="nav-item dropdown">
          <a
            class="nav-link dropdown-toggle"
            id="navbarDropdownMenuLink"
            role="button"
            data-toggle="dropdown"
          >
            <span>
              <i class="fas fa-gem fa-lg"></i>
            </span>
          </a>
          <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
            <p class="dropdown-item" @click="reset">Main Menu</p>
            <div
              v-if="
                this.$route.name !== 'Dashboard' &&
                  this.$route.name !== 'CreateGame'
              "
            >
              <router-link class="dropdown-item" :to="{ name: 'Dashboard' }"
                >Dashboard</router-link
              >
            </div>

            <a class="dropdown-item" href="#">Something else here</a>
          </div>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
export default {
  name: 'Navbar',
  data() {
    return {};
  },
  methods: {
    reset() {
      this.$store.dispatch('resetPlanets');
      // this.$store.dispatch('resetGame');
    },
  },
};
</script>

<style>
.navbar-collapse {
  place-content: flex-end;
}
.dropdown-menu {
  left: -130px;
}
.navbar .title {
  color: gold;
}
.nav-link {
  cursor: pointer;
}
.fa-gem {
  color: gold;
}
</style>
