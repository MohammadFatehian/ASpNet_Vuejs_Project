<template>
<div class="container">
  <h1 class="mt-3 mb-3"></h1>
  <h3>Please Select Table</h3>
  <select type="button" class=" col-4 dropdown btn btn-secondary mt-3"
  v-model="selectedTanble" @change="selectTable($event)">
    
    <option value="" v-for="(table , index) in tables" :key=index>{{table}}</option>
  </select>
  <h3 class="mt-2 mb-2">Table : {{selectedTanble}}</h3>
  <h3>{{table}}</h3>
 
  </div>
</template>

<script>
import axios from 'axios'
import {ref} from 'vue'
export default {
  
    name:"Home",
    
    setup(){
        const tables = ref([])
        const table=ref([])
        const tablekey = ref({})
        const selectedTanble=ref("");
        function getTables(){
            axios.get("http://localhost:55604/api/tables")
                    .then(function (response) {
                        // handle success
                        tables.value=response.data;
                        console.log(response);
                    })
                    .catch(function (error) {
                        // handle error
                        console.log(error);
                    })
            console.log(tables.value)
        }
        getTables()

        function selectTable(event){
            console.log(event.target.options[event.target.options.selectedIndex].text)
            selectedTanble.value=event.target.options[event.target.options.selectedIndex].text;

            axios.get(`http://localhost:55604/api/tables/GetTable/${selectedTanble.value}`)
                    .then(function (response) {
                        // handle success
                        table.value=response.data;
                        tablekey.value=table.value[0]
                        console.log(response);
                    })
                    .catch(function (error) {
                        // handle error
                        console.log(error);
                    })
            console.log(table.value)
            console.log(tablekey.value)
            
        }
        return{tables , selectedTanble ,selectTable , table ,tablekey}
    }

}
</script>

<style>

</style>