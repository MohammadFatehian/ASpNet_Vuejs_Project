<template>
<div>
  <header>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container-fluid">
            <router-link class="navbar-brand" to="/">Nikan Project</router-link>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                <li class="nav-item">
                <router-link class="nav-link active" aria-current="page" to="/">Home</router-link>
                </li>
                <li class="nav-item">
                <router-link class="nav-link" to="/table">Table</router-link>
                </li>
            </ul>    
            </div>
        </div>
    </nav>
  </header>
  <body>

    <router-view></router-view>

  </body>

</div>
</template>

<script>
export default {
    name: "Template"
}
</script>

<style>

    /* .router-link-active {
  
   color:rgb(0,0,0,0.9) !important; 
   border-bottom: 2px solid rgb(0,0,0,0.9) !important ; 

} */
/* .nav-link{
  color:rgb(0,0,0,0.9) !important;
} */

/* .footer{
  display : flex;
  height: 5rem;
  color: rgb(189, 183, 183);
  background: black;
  text-align: center;
  align-items: center;
  justify-content: center;
  margin-top: 5rem;
  
} */

</style>