<template>
  <Navbar />
  <!-- <p>
    <strong>Current route path:</strong> {{ $route.fullPath }}
  </p>
  <nav>
    <RouterLink to="/">Go to Dashboard</RouterLink>
    <RouterLink to="/create">Create Application</RouterLink>
  </nav> -->
  <main>
    <RouterView />
  </main>
</template>

<script setup>
import { RouterView } from 'vue-router'
import Navbar from './components/Navbar.vue'
</script>

<style scoped>
main {
  margin-top: 60px; /* Adjust this value to match the height of your navbar */
}
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
