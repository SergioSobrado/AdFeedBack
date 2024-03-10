<template>
  <div id="app">
    <header class="header">
      <router-link class="link-title" to="/">
        <div class="brand-section">
          <svg width="20" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512"><path fill="#FFC700" d="M160 80c0-26.5 21.5-48 48-48h32c26.5 0 48 21.5 48 48V432c0 26.5-21.5 48-48 48H208c-26.5 0-48-21.5-48-48V80zM0 272c0-26.5 21.5-48 48-48H80c26.5 0 48 21.5 48 48V432c0 26.5-21.5 48-48 48H48c-26.5 0-48-21.5-48-48V272zM368 96h32c26.5 0 48 21.5 48 48V432c0 26.5-21.5 48-48 48H368c-26.5 0-48-21.5-48-48V144c0-26.5 21.5-48 48-48z"/></svg>      
          <span class="title">AdFeedBack</span>
        </div>
      </router-link>     
      <div class="navigation">
        <router-link class="links" to="/about">Statistics</router-link> 
        <router-link class="links" to="/user">
            <svg width="35" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><path fill="#FFFFFF" d="M399 384.2C376.9 345.8 335.4 320 288 320H224c-47.4 0-88.9 25.8-111 64.2c35.2 39.2 86.2 63.8 143 63.8s107.8-24.7 143-63.8zM0 256a256 256 0 1 1 512 0A256 256 0 1 1 0 256zm256 16a72 72 0 1 0 0-144 72 72 0 1 0 0 144z"/></svg>
        </router-link> 
      </div>
    </header>
    <div class="body">
      <router-view/>
    </div>
    <footer class="footer">
      <span class="footer-text">AdFeedback - {{ currentYear }} | Todos los derechos reservados</span>
    </footer>
  </div>
</template>

<script lang="ts">

export default ({
  data() {
    return {
      currentYear: new Date().getFullYear()
    }
}
});
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.footer-text {
  font-size: 16px;
  font-weight: 700;
}
nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}

.title {
  font-size: 20px;
  font-weight: 700;
}

.footer {
  display: flex;
  align-items: center;
  justify-content: center;
  background-color: #000;
  width: fixed 100%;
  color: white;
  height: 80px;
}

.header {
  display: flex;
  padding: 15px;
  align-items: center;
  justify-content: space-around;
  background-color: #000;
  width: fixed 100%;
  color: white;
  height: 51px;
}

.body{ 
  height: calc(100vh - 181px);
  margin-top: 20px;
}

* {
  padding: 0;
  margin: 0;
  font-family: Roboto, system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
}
.brand-section {
  display: flex;
  gap: 10px;
}
.navigation {
  display: flex;
  gap: 5px;   
}

.links {
  text-decoration: none;
  color: #fff;
  display: flex;
  align-items: center;
  padding: 8px;
}

.link-title {
  text-decoration: none;
  color: #fff;
}
</style>

