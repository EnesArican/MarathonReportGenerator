<template>
    <v-app>
        <v-app-bar dense app>
            <i class="svg-logo svg-lg mr-1"></i>
            <v-app-bar-nav-icon> </v-app-bar-nav-icon>
            <v-app-bar-title>Marathon Report Generator</v-app-bar-title>
        </v-app-bar>
        <v-main>
            <div id="content" class="container mt-4">
                <router-view></router-view>
            </div>
        </v-main>
    </v-app>
</template>

<script lang="ts">
import Vue from 'vue';
import { bus, store } from './shared';
import { Component, Prop } from 'vue-property-decorator';

@Component
export class App extends Vue {
  get store() { return store; }
}
export default App;
</script>
