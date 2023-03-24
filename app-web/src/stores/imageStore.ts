import { defineStore } from 'pinia'
import Axios from 'axios';
import { convertBase64 } from '@/utils/convertBase64';

interface IImage{
  id: number,
  name: string,
  ulr:string
}

interface IState{
  images:IImage[]
}

const API = 'http://localhost:5126';

export const useImageStore = defineStore('image', {
  state: ():IState => {
    return { images: [] }
  },
  
  actions: {
    async addImage(image:{name:string, file:File | null}) {
      try {
        //base64
        const base64 = await convertBase64(image.file!);
        //servidor}
        const response = await Axios({
          url: `${API}/image`,
          method:'POST',
          data:{
            name:image.name,
            base64
          }
        });
        if(response.status == 200){
          this.images.push(response.data);
          //this.images.push(response.data);         
        }
      } catch (error) {
        console.log(error);        
      }
    },
    async getAllImages(){
      const response = await Axios({
        url: `${API}/image`,
        method:'GET',
      });
      if(response.status == 200){
        console.log(response.data);
        this.images = response.data;
      }
    }
  },
})