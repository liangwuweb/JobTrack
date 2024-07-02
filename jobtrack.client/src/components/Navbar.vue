<template>
    <nav class="navbar">
      <RouterLink to="/">Dashboard</RouterLink>
      <RouterLink to="/create">Create Application</RouterLink>
    </nav>
  </template>
  
  <script setup>
  import { RouterLink } from 'vue-router';
  </script>
  
<style scoped>
.navbar {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  display: flex;
  justify-content: space-around;
  padding: 1rem;
  background-color: #f8f9fa;
  border-bottom: 1px solid #dee2e6;
  z-index: 1000; /* Ensures the navbar stays on top of other content */
}

.navbar a {
  text-decoration: none;
  color: #007bff;
  font-weight: bold;
}

.navbar a:hover {
  color: #0056b3;
}
</style>
  