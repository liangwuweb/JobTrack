<template>
    <div>
      <h1>Create Application</h1>
  
      <form @submit.prevent="submitForm">
        <div>
          <label for="companyName">Company Name (required):</label>
          <input type="text" id="companyName" v-model="formData.companyName" required>
        </div>
  
        <div>
          <label for="jobTitle">Job Title (required):</label>
          <input type="text" id="jobTitle" v-model="formData.jobTitle" required>
        </div>
  
        <div>
          <label for="jobLink">Job Link:</label>
          <input type="url" id="jobLink" v-model="formData.jobLink">
        </div>
  
        <div>
          <label for="jobDescription">Job Description:</label>
          <textarea id="jobDescription" v-model="formData.jobDescription"></textarea>
        </div>
  
        <button type="submit">Submit</button>
      </form>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  
  const message = ref('Start creating your application here!');
  const formData = ref({
    companyName: '',
    jobTitle: '',
    jobLink: '',
    jobDescription: ''
  });

  const devURIBase = 'https://localhost:7180';
  const prodURIBase = 'https://app-jobtrack-centralus-dev-001.azurewebsites.net';
  const submitForm = async () => {
    try {
      const response = await fetch(prodURIBase + '/applications', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData.value)
      });
  
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
  
      const result = await response.json();
      console.log('Form submitted successfully:', result);
      // Reset the form
      formData.value = {
        companyName: '',
        jobTitle: '',
        jobLink: '',
        jobDescription: ''
      };
    } catch (error) {
      console.error('Error submitting form:', error);
    }
  };
  </script>
  
  <style scoped>
  form {
    display: flex;
    flex-direction: column;
    gap: 1rem;
  }
  
  label {
    font-weight: bold;
  }
  
  input, textarea {
    padding: 0.5rem;
    border: 1px solid #ccc;
    border-radius: 4px;
    width: 100%;
  }
  
  button {
    background-color: #007bff;
    color: white;
    border: none;
    padding: 0.5rem 1rem;
    border-radius: 4px;
    cursor: pointer;
  }
  
  button:hover {
    background-color: #0056b3;
  }
  </style>
  