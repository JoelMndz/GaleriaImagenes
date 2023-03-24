<template>
  <div>
    <div v-for="i in images" :key="i.id" class="card">
      <img :src="i.url" alt="img">
      <h4>{{i.name}}</h4>
    </div>
  </div>
</template>

<script lang="ts">
import { useImageStore } from '@/stores/imageStore';
import {mapActions, mapState} from 'pinia'
import { defineComponent } from 'vue';

export default defineComponent({
  setup() {
    
    return{
      
    }
  },
  methods:{
    ...mapActions(useImageStore,['getAllImages']),
    
  },
  computed:{
    ...mapState(useImageStore, ['images']),
  },
  async mounted(){
    await this.getAllImages();
  }
})
</script>


<style>
.card {
  display: inline-block;
  margin: 10px;
  width: 300px;
  background-color: #ffffff;
  box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.1);
  border-radius: 5px;
}

.card img {
  width: 100%;
  height: 200px;
  object-fit: cover;
  border-top-left-radius: 5px;
  border-top-right-radius: 5px;
}

.card h4 {
  padding: 10px;
  font-size: 20px;
  font-weight: bold;
  color: #333333;
}

</style>