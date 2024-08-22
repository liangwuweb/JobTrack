<template>
    <div>
      <h1>Applications</h1>
      <div v-if="applications.length" class="card-container">
        <div v-for="app in applications" :key="app.id" class="card">
          <h1>{{ app.jobTitle }}</h1>
          <p>{{ app.companyName }}</p>
          <button @click="editApplication(app.id)">Edit</button>
        </div>
      </div>
      <p v-else>Loading applications...</p>
    </div>
</template>
  
  <script setup>
  import { ref, onMounted } from 'vue';
  import api from '@/api';

  const message = ref('Welcome to the Home Page!');
  const applications = ref([]);

  const fetchApplications = async () => {
    // try {
    //   const response = await fetch(import.meta.env.VITE_APP_API_DEV_URL + '/applications');
    //   if (!response.ok) {
    //     throw new Error('Network response was not ok');
    //   }
    //   const data = await response.json();
    //   applications.value = data;
    // } catch (error) {
    //   console.error('Error fetching applications:', error);
    // }
    api.application.getAll().then(x=>applications.value = x);
  };
  
  const editApplication = (id) => {
    // Handle the edit action here, e.g., navigate to an edit page
    console.log('Edit application with ID:', id);
  };
  
  onMounted(() => {
    fetchApplications();
    
  });

  </script>
  
  <style scoped>
  .card-container {
    display: flex;
    flex-direction: column;
    gap: 1rem;
  }
  
  .card {
    border: 1px solid #ccc;
    border-radius: 5px;
    padding: 1rem;
    width: 100%; /* Make the card take the full width of the container */
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  }
  
  .card h1 {
    font-size: 1.5rem;
    margin-bottom: 0.5rem;
  }
  
  .card p {
    font-size: 1rem;
    margin-bottom: 1rem;
  }
  
  .card button {
    background-color: #007bff;
    color: white;
    border: none;
    padding: 0.5rem 1rem;
    border-radius: 3px;
    cursor: pointer;
  }
  
  .card button:hover {
    background-color: #0056b3;
  }
  </style>
  