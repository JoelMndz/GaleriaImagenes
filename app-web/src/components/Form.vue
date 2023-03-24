<template>
  <div class="form-container">
    <form @submit.prevent="handleSubmit">
      <h1>Agregar Imagen</h1>
      <div>
        <input type="text" placeholder="Nombre" required v-model="formValues.name">
      </div>
      <div>
        <input @change="changeFile" type="file" required accept="image/*">
      </div>
      <button type="submit">Guardar</button>
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent, reactive, ref } from 'vue';
import { useImageStore } from '@/stores/imageStore';
import {mapActions} from 'pinia'

export default defineComponent({
  setup() {
    const formValues = reactive({
      name: '',
      file: null
    });

    return{
      formValues
    }
  },
  methods:{
    ...mapActions(useImageStore,['addImage']),
    async handleSubmit(){
      await this.addImage(this.formValues);
      this.formValues.file = null;
      this.formValues.name = '';
    },
    changeFile(e:any){
      if(e.target.files.length !== 0){
        this.formValues.file = e.target.files[0];
      }else{
        this.formValues.file = null;
      }
    }
  }
})
</script>


<style>
.form-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
  background-color: #f5f5f5;
}

form {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 400px;
  padding: 20px;
  background-color: #ffffff;
  border-radius: 5px;
}

input {
  margin-bottom: 10px;
  padding: 10px;
  border: 1px solid #cccccc;
  border-radius: 5px;
  width: 100%;
  box-sizing: border-box;
}

button {
  padding: 10px 20px;
  background-color: #4CAF50;
  color: #ffffff;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

button:hover {
  background-color: #3e8e41;
}

button:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

</style>